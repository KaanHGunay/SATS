using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.OlayKayit
{
    /// <summary>
    /// Olay Ekleme Formundayken yeni mağdur veya şüpheli ekleme durumunda zaten seçimi yapılmış olan bilgilerin saklanarak yeni mağdur/şüpheli ekleme bittikten sonra geri getirilmesini sağlayan kod
    /// </summary>
    public static class OlayEkle_Reverse
    {
        public static void Olustur(Grid g)
        {
            ItemCollection magdur_collection = null;
            ItemCollection supheli_collection = null;

            foreach (UIElement element in g.Children)
            {
                switch (element.Uid)
                {
                    case "magdurEkle_lwListe":
                        magdur_collection = ((SATSListView)element).Items;
                        break;
                    case "supheliEkle_lwListe":
                        supheli_collection = ((SATSListView)element).Items;
                        break;
                }
            }

            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 0.25, 2, 2, 2, 2, 2, 2, 2, 1);
            Islemler.ColumnOlustur(g, 1, 2, 4, 2, 2, 2, 1);

            List<UIElement> a = (List<UIElement>)g.Tag;
            g.Tag = null;

            foreach (UIElement element in a)
            {
                g.Children.Add(element);

                if (element.Uid == "lw_magdur" && magdur_collection != null)
                {
                    ((SATSListView)element).Items.Clear();
                    foreach (Magdur magdur in magdur_collection)
                    {
                        ((SATSListView)element).Items.Add(magdur);
                    }
                }
                else if (element.Uid == "lw_supheli" && supheli_collection != null)
                {
                    ((SATSListView)element).Items.Clear();
                    foreach (Supheli supheli in supheli_collection)
                    {
                        ((SATSListView)element).Items.Add(supheli);
                    }
                }
            }
        }
    }
}

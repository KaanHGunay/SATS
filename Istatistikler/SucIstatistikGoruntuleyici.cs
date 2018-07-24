using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.Istatistikler
{
    /// <summary>
    /// İstatistiği istenen suç tipinin verilerinin gösterildiği form
    /// </summary>
    public static class SucIstatistikGoruntuleyici
    {
        public static void Olustur(Grid g, int sucID, DateTime? basTarih, DateTime? bitTarih)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 2, 1, 1, 1, 5);
            Islemler.ColumnOlustur(g, 1, 2, 2, 1);

            SATSLabel lbl_OlaySayisi_Metin = new SATSLabel();
            lbl_OlaySayisi_Metin.Content = "Meydana Gelen Toplam Olay Sayısı:";
            Grid.SetRow(lbl_OlaySayisi_Metin, 1);
            Grid.SetColumn(lbl_OlaySayisi_Metin, 1);

            SATSLabel lbl_OlaySayisi = new SATSLabel();
            Grid.SetRow(lbl_OlaySayisi, 1);
            Grid.SetColumn(lbl_OlaySayisi, 2);

            SATSLabel lbl_FailiMechul_Metin = new SATSLabel();
            lbl_FailiMechul_Metin.Content = "Faili Meçhul Olan Olay Sayısı:";
            Grid.SetRow(lbl_FailiMechul_Metin, 2);
            Grid.SetColumn(lbl_FailiMechul_Metin, 1);

            SATSLabel lbl_FailiMechul = new SATSLabel();
            Grid.SetRow(lbl_FailiMechul, 2);
            Grid.SetColumn(lbl_FailiMechul, 2);

            SATSLabel lbl_enCokIslenenIl_Metin = new SATSLabel();
            lbl_enCokIslenenIl_Metin.Content = "Suçun En Çok İşlendiği İl:";
            Grid.SetRow(lbl_enCokIslenenIl_Metin, 3);
            Grid.SetColumn(lbl_enCokIslenenIl_Metin, 1);

            SATSLabel lbl_enCokIslenenIl = new SATSLabel();
            Grid.SetRow(lbl_enCokIslenenIl, 3);
            Grid.SetColumn(lbl_enCokIslenenIl, 2);

            try
            {
                using (var db = new Context())
                {
                    var sonuc = (from s in db.olaylar where s.suc.ID == sucID select s).ToList();
                    lbl_OlaySayisi.Content = sonuc.Count();

                    var failiMechul = (from s in sonuc where s.failDurum.failDurumu == "Faili Meçhul" select s).ToList();
                    lbl_FailiMechul.Content = failiMechul.Count();

                    var enCokIslenenIl = (from s in sonuc group s by s.mahalle.polisMerkezi.ilce.İl into a select new { il = a.Key, sayi = a.Count() }).OrderByDescending(c => c.sayi).ToList();
                    if (enCokIslenenIl.Count > 0)
                    {
                        lbl_enCokIslenenIl.Content = String.Format("{0} ({1})", enCokIslenenIl[0].il.adi, enCokIslenenIl[0].sayi);
                    }
                    else
                    {
                        lbl_enCokIslenenIl.Content = "- (-)";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }

            g.Children.Add(lbl_OlaySayisi_Metin);
            g.Children.Add(lbl_OlaySayisi);
            g.Children.Add(lbl_FailiMechul_Metin);
            g.Children.Add(lbl_FailiMechul);
            g.Children.Add(lbl_enCokIslenenIl_Metin);
            g.Children.Add(lbl_enCokIslenenIl);
        }
    }
}

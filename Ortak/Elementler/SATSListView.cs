using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using SATS.VeriTabani;

namespace SATS.Ortak.Elementler
{
    public class SATSListView : ListView
    {
        public SATSListView()
        {
            Background = Ayarlar.BeyazRenk;
            Foreground = Ayarlar.GriRenk;
            ((INotifyCollectionChanged)this.Items).CollectionChanged += SATSListView_CollectionChanged;
        }

        private void SATSListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems[0] is Magdur)
                {
                    List<string> magdurlar = new List<string>();

                    foreach (var item in Items)
                    {
                        magdurlar.Add((item as Magdur).TC);
                    }

                    int itemCount = 0;
                    foreach (string item in magdurlar)
                    {
                        if ((e.NewItems[0] as Magdur).TC == item)
                        {
                            itemCount++;
                        }
                    }

                    if (itemCount > 1)
                    {
                        Items.Remove(e.NewItems[0]);
                        MessageBox.Show("Aynı şahıs tekrar eklenemez.");
                    } 
                }
                else
                {
                    List<string> magdurlar = new List<string>();

                    foreach (var item in Items)
                    {
                        magdurlar.Add((item as Supheli).TC);
                    }

                    int itemCount = 0;
                    foreach (string item in magdurlar)
                    {
                        if ((e.NewItems[0] as Supheli).TC == item)
                        {
                            itemCount++;
                        }
                    }

                    if (itemCount > 1)
                    {
                        Items.Remove(e.NewItems[0]);
                        MessageBox.Show("Aynı şahıs tekrar eklenemez.");
                    }
                }
            }
        }
    }
}

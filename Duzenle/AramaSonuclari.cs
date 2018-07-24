using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Data;
using SATS.VeriTabani;
using SATS.Ortak;
using SATS.Ortak.Elementler;

namespace SATS.Duzenle
{
    /// <summary>
    /// Düzenlenme amacıyla sorgulanan olayların sıralandığı form
    /// </summary>
    public static class AramaSonuclari
    {
        public static void Olustur(Grid g, List<Olay> olaylar)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 0.5, 7, 1, 0.5);
            Islemler.ColumnOlustur(g, 0.5, 5, 1, 1, 0.5);

            DataGrid dg = new DataGrid
            {
                FontSize = Application.Current.MainWindow.FontSize,
                IsReadOnly = true,
                SelectionMode = DataGridSelectionMode.Single,
                Uid = "dg"
            };
            Grid.SetRow(dg, 1);
            Grid.SetColumn(dg, 1);
            Grid.SetColumnSpan(dg, 3);
            DataGridTextColumn cl_il = new DataGridTextColumn { Header = "İl", Binding = new Binding("il") };
            DataGridTextColumn cl_ilce = new DataGridTextColumn { Header = "İlçe", Binding = new Binding("ilce") };
            DataGridTextColumn cl_mahalle = new DataGridTextColumn { Header = "Mahalle", Binding = new Binding("mahalle") };
            DataGridTextColumn cl_polisMerkezi = new DataGridTextColumn { Header = "Polis Merkezi", Binding = new Binding("polisMerkezi") };
            DataGridTextColumn cl_suc = new DataGridTextColumn { Header = "Suç", Binding = new Binding("suc") };
            DataGridTextColumn cl_magdurSayisi = new DataGridTextColumn { Header = "Mağdur", Binding = new Binding("magdurSayisi") };
            DataGridTextColumn cl_supheliSayisi = new DataGridTextColumn { Header = "Şüpheli", Binding = new Binding("supheliSayisi") };
            DataGridTextColumn cl_tarih = new DataGridTextColumn { Header = "Tarih", Binding = new Binding("tarih") };
            DataGridTextColumn cl_ID = new DataGridTextColumn { Binding = new Binding("ID"), Visibility = Visibility.Hidden };
            dg.Columns.Add(cl_il);
            dg.Columns.Add(cl_ilce);
            dg.Columns.Add(cl_mahalle);
            dg.Columns.Add(cl_polisMerkezi);
            dg.Columns.Add(cl_suc);
            dg.Columns.Add(cl_magdurSayisi);
            dg.Columns.Add(cl_supheliSayisi);
            dg.Columns.Add(cl_tarih);
            dg.Columns.Add(cl_ID);

            SATSButton btn_duzenle = new SATSButton
            {
                Content = "Düzenle",
                Margin = new Thickness(0, 15, 10, 0)
            };
            Grid.SetRow(btn_duzenle, 2);
            Grid.SetColumn(btn_duzenle, 2);

            SATSButton btn_sil = new SATSButton
            {
                Content = "Sil",
                Margin = new Thickness(10, 15, 0, 0)
            };
            Grid.SetRow(btn_sil, 2);
            Grid.SetColumn(btn_sil, 3);

            foreach (Olay olay in olaylar)
            {
                try
                {
                    using (var db = new Context())
                    {
                        GosterilenOlaylar gosterilenOlaylar = new GosterilenOlaylar
                        {
                            ID = olay.ID,
                            il = olay.mahalle.polisMerkezi.ilce.İl.adi,
                            ilce = olay.mahalle.polisMerkezi.ilce.adi,
                            polisMerkezi = olay.mahalle.polisMerkezi.adi,
                            mahalle = olay.mahalle.adi,
                            suc = olay.suc.adi,
                            tarih = olay.tarih,
                            magdurSayisi = (from ms in db.olaylar where ms.ID == olay.ID select ms.magdurlar).ToList()[0].Count(),
                            supheliSayisi = (from ss in db.olaylar where ss.ID == olay.ID select ss.supheliler).ToList()[0].Count()
                        };

                        dg.Items.Add(gosterilenOlaylar);
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = MessageBox.Show(ex.Message);
                }
            }

            dg.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription { PropertyName = "tarih", Direction = System.ComponentModel.ListSortDirection.Ascending });
            dg.LoadingRow += Dg_LoadingRow;
            btn_sil.Click += Btn_sil_Click;
            btn_duzenle.Click += Btn_duzenle_Click;

            g.Children.Add(dg);
            g.Children.Add(btn_duzenle);
            g.Children.Add(btn_sil);
        }

        private static void Btn_duzenle_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
            {
                if (element.Uid == "dg")
                {
                    if ((element as DataGrid).SelectedItem != null)
                    {
                        OlayDuzenleme.Olustur((sender as SATSButton).Parent as Grid, ((element as DataGrid).SelectedItem as GosterilenOlaylar).ID);
                    }
                    break;
                }
            }
        }

        private static void Btn_sil_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
            {
                if (element.Uid == "dg")
                {
                    if ((element as DataGrid).SelectedItem != null)
                    {
                        using (var db = new Context())
                        {
                            int silinecekID = ((element as DataGrid).SelectedItem as GosterilenOlaylar).ID;
                            var silinecekOlay = (from oly in db.olaylar where oly.ID == silinecekID select oly).Single();
                            db.olaylar.Remove(silinecekOlay);
                            db.SaveChanges();
                        }
                        (element as DataGrid).Items.Remove((element as DataGrid).SelectedItem);
                    }
                    break;
                }
            }
        }

        private static void Dg_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}

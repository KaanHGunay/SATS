using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.Duzenle
{
    /// <summary>
    /// Düzenlenecek olayın özelliklerinin değiştirilebildiği form
    /// </summary>
    public static class OlayDuzenleme
    {
        public static void Olustur(Grid g, int ID)
        {
            g.Children.Clear();
            g.RowDefinitions.Clear();
            g.ColumnDefinitions.Clear();

            Islemler.RowOlustur(g, 0.25, 2, 2, 2, 2, 2, 2, 2, 1);
            Islemler.ColumnOlustur(g, 1, 2, 4, 2, 2, 2, 1);

            SATSLabel lbl_il = new SATSLabel();
            lbl_il.Content = "İl:";
            Grid.SetRow(lbl_il, 1);
            Grid.SetColumn(lbl_il, 1);

            SATSComboBox cb_il = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),                
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_il",
                IsReadOnly = true
            };
            Grid.SetRow(cb_il, 1);
            Grid.SetColumn(cb_il, 2);

            SATSLabel lbl_ilce = new SATSLabel();
            lbl_ilce.Content = "İlçe:";
            Grid.SetRow(lbl_ilce, 2);
            Grid.SetColumn(lbl_ilce, 1);

            SATSComboBox cb_ilce = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_ilce",
                IsReadOnly = true
            };
            Grid.SetRow(cb_ilce, 2);
            Grid.SetColumn(cb_ilce, 2);

            SATSLabel lbl_pm = new SATSLabel();
            lbl_pm.Content = "Polis Merkezi:";
            Grid.SetRow(lbl_pm, 3);
            Grid.SetColumn(lbl_pm, 1);

            SATSComboBox cb_pm = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_pm",
                IsReadOnly = true
            };
            Grid.SetRow(cb_pm, 3);
            Grid.SetColumn(cb_pm, 2);

            SATSLabel lbl_mh = new SATSLabel();
            lbl_mh.Content = "Mahalle:";
            Grid.SetRow(lbl_mh, 4);
            Grid.SetColumn(lbl_mh, 1);

            SATSComboBox cb_mh = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_mh"
            };
            Grid.SetRow(cb_mh, 4);
            Grid.SetColumn(cb_mh, 2);

            SATSLabel lbl_sn = new SATSLabel();
            lbl_sn.Content = "Suç Nevi:";
            Grid.SetRow(lbl_sn, 5);
            Grid.SetColumn(lbl_sn, 1);

            SATSComboBox cb_sn = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_sn"
            };
            Grid.SetRow(cb_sn, 5);
            Grid.SetColumn(cb_sn, 2);

            SATSLabel lbl_fd = new SATSLabel();
            lbl_fd.Content = "Fail Durumu:";
            Grid.SetRow(lbl_fd, 6);
            Grid.SetColumn(lbl_fd, 1);

            SATSComboBox cb_fd = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "failDurumu",
                Uid = "cb_fd"
            };
            Grid.SetRow(cb_fd, 6);
            Grid.SetColumn(cb_fd, 2);

            SATSLabel lbl_tarih = new SATSLabel();
            lbl_tarih.Content = "Tarih:";
            Grid.SetRow(lbl_tarih, 7);
            Grid.SetColumn(lbl_tarih, 1);

            SATSDatePicker dp = new SATSDatePicker();
            dp.Uid = "tarih";
            Grid.SetRow(dp, 7);
            Grid.SetColumn(dp, 2);

            SATSLabel lbl_magdur = new SATSLabel();
            lbl_magdur.Content = "Mağdur(lar):";
            Grid.SetRow(lbl_magdur, 1);
            Grid.SetColumn(lbl_magdur, 3);

            SATSListView lw_magdur = new SATSListView
            {
                Margin = new Thickness(0, 25, 0, 25),
                Uid = "lw_magdur"
            };
            Grid.SetRow(lw_magdur, 1);
            Grid.SetColumn(lw_magdur, 4);
            Grid.SetRowSpan(lw_magdur, 2);
            Grid.SetColumnSpan(lw_magdur, 2);

            SATSButton btn_magdur_ekle = new SATSButton
            {
                Content = "Ekle",
                Margin = new Thickness(0, 10, 10, 20),
                Uid = "btn_magdudrEkle"
            };
            Grid.SetRow(btn_magdur_ekle, 3);
            Grid.SetColumn(btn_magdur_ekle, 4);

            SATSButton btn_magdur_cikar = new SATSButton
            {
                Content = "Çıkar",
                Margin = new Thickness(10, 10, 0, 20)
            };
            Grid.SetRow(btn_magdur_cikar, 3);
            Grid.SetColumn(btn_magdur_cikar, 5);

            SATSLabel lbl_supheli = new SATSLabel();
            lbl_supheli.Content = "Şüpheli(ler):";
            Grid.SetRow(lbl_supheli, 4);
            Grid.SetColumn(lbl_supheli, 3);

            SATSListView lw_supheli = new SATSListView
            {
                Margin = new Thickness(0, 25, 0, 25),
                Uid = "lw_supheli"
            };
            Grid.SetRow(lw_supheli, 4);
            Grid.SetColumn(lw_supheli, 4);
            Grid.SetRowSpan(lw_supheli, 2);
            Grid.SetColumnSpan(lw_supheli, 2);

            SATSButton btn_supheli_ekle = new SATSButton
            {
                Content = "Ekle",
                Margin = new Thickness(0, 10, 10, 20),
                Uid = "btn_supheliEkle"
            };
            Grid.SetRow(btn_supheli_ekle, 6);
            Grid.SetColumn(btn_supheli_ekle, 4);

            SATSButton btn_supheli_cikar = new SATSButton
            {
                Content = "Çıkar",
                FontSize = Application.Current.MainWindow.FontSize,
                Foreground = Ayarlar.BeyazRenk,
                Background = Ayarlar.GriRenk,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 10, 0, 20)
            };
            Grid.SetRow(btn_supheli_cikar, 6);
            Grid.SetColumn(btn_supheli_cikar, 5);

            SATSButton btn_guncelle = new SATSButton
            {
                Content = "Güncelle",
                Margin = new Thickness(0, 0, 0, 7),
                Tag = ID
            };
            Grid.SetRow(btn_guncelle, 7);
            Grid.SetColumn(btn_guncelle, 4);
            Grid.SetColumnSpan(btn_guncelle, 2);

            cb_il.SelectionChanged += new SelectionChangedEventHandler((object sender, SelectionChangedEventArgs e) => { (sender as SATSComboBox).SelectedValue = (sender as SATSComboBox).Tag; });
            cb_il.SelectionChanged += Olaylar.Cb_il_SelectionChanged;
            cb_ilce.SelectionChanged += new SelectionChangedEventHandler((object sender, SelectionChangedEventArgs e) => { (sender as SATSComboBox).SelectedValue = (sender as SATSComboBox).Tag; });
            cb_ilce.SelectionChanged += Olaylar.Cb_ilce_SelectionChanged;
            cb_pm.SelectionChanged += new SelectionChangedEventHandler((object sender, SelectionChangedEventArgs e) => { (sender as SATSComboBox).SelectedValue = (sender as SATSComboBox).Tag; });
            cb_pm.SelectionChanged += Olaylar.Cb_pm_SelectionChanged;
            btn_magdur_cikar.Click += Olaylar.Btn_magdur_cikar_Click;
            btn_supheli_cikar.Click += Olaylar.Btn_supheli_cikar_Click;
            btn_magdur_ekle.Click += Btn_magdur_ekle_Click;
            btn_supheli_ekle.Click += Btn_supheli_ekle_Click;
            cb_fd.SelectionChanged += new SelectionChangedEventHandler((object sender, SelectionChangedEventArgs e) => { (sender as SATSComboBox).SelectedValue = (sender as SATSComboBox).Tag; });
            cb_fd.SelectionChanged += Olaylar.Cb_fd_SelectionChanged;
            btn_guncelle.Click += Btn_guncelle_Click;

            g.Children.Add(lbl_il);
            g.Children.Add(cb_il);
            g.Children.Add(lbl_ilce);
            g.Children.Add(cb_ilce);
            g.Children.Add(lbl_pm);
            g.Children.Add(cb_pm);
            g.Children.Add(lbl_mh);
            g.Children.Add(cb_mh);
            g.Children.Add(lbl_sn);
            g.Children.Add(cb_sn);
            g.Children.Add(lbl_fd);
            g.Children.Add(cb_fd);
            g.Children.Add(lbl_tarih);
            g.Children.Add(dp);
            g.Children.Add(lbl_magdur);
            g.Children.Add(lw_magdur);
            g.Children.Add(btn_magdur_ekle);
            g.Children.Add(btn_magdur_cikar);
            g.Children.Add(lbl_supheli);
            g.Children.Add(lw_supheli);
            g.Children.Add(btn_supheli_ekle);
            g.Children.Add(btn_supheli_cikar);
            g.Children.Add(btn_guncelle);

            try
            {
                using (var db = new Context())
                {
                    Olay duzenlenenOlay = (from olay in db.olaylar where olay.ID == ID select olay).SingleOrDefault();
                    var magdurlar = (from olay in db.olaylar where olay.ID == ID select olay.magdurlar).ToList()[0];
                    var supheliler = (from olay in db.olaylar where olay.ID == ID select olay.supheliler).ToList()[0];

                    cb_il.Tag = duzenlenenOlay.mahalle.polisMerkezi.ilce.İl.ID;
                    cb_ilce.Tag = duzenlenenOlay.mahalle.polisMerkezi.ilce.ID;
                    cb_pm.Tag = duzenlenenOlay.mahalle.polisMerkezi.ID;
                    cb_fd.Tag = duzenlenenOlay.failDurum.ID;

                    var iller = (from i in db.iller select i).ToList();
                    cb_il.ItemsSource = iller;

                    var suclar = (from s in db.suclar select s).ToList();
                    cb_sn.ItemsSource = suclar;

                    var fail = (from f in db.failDurumu select f).ToList();
                    cb_fd.ItemsSource = fail;

                    cb_il.SelectedValue = duzenlenenOlay.mahalle.polisMerkezi.ilce.İl.ID;
                    cb_ilce.SelectedValue = duzenlenenOlay.mahalle.polisMerkezi.ilce.ID;
                    cb_pm.SelectedValue = duzenlenenOlay.mahalle.polisMerkezi.ID;
                    cb_mh.SelectedValue = duzenlenenOlay.mahalle.ID;
                    cb_fd.SelectedValue = duzenlenenOlay.failDurum.ID;
                    cb_sn.SelectedValue = duzenlenenOlay.suc.ID;
                    dp.SelectedDate = duzenlenenOlay.tarih;

                    foreach (Magdur magdur in magdurlar)
                    {
                        lw_magdur.Items.Add(magdur);
                    }

                    foreach (Supheli supheli in supheliler)
                    {
                        lw_supheli.Items.Add(supheli);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }
        }

        private static void Btn_supheli_ekle_Click(object sender, RoutedEventArgs e)
        {
            OlayKayit.SupheliEkle.Olustur((sender as SATSButton).Parent as Grid);
        }

        private static void Btn_magdur_ekle_Click(object sender, RoutedEventArgs e)
        {
            OlayKayit.MagdurEkle.Olustur((sender as SATSButton).Parent as Grid);
        }

        private static void Btn_guncelle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new Context())
                {
                    int ID = (int)((sender as SATSButton).Tag);
                    Olay olay = db.olaylar.Include("supheliler").Include("magdurlar").Where(x => x.ID == ID).FirstOrDefault();
                    var supheliler = olay.supheliler.ToList();
                    supheliler.ForEach(x => olay.supheliler.Remove(x));
                    var magdurlar = db.magdurlar.ToList();
                    magdurlar.ForEach(x => olay.magdurlar.Remove(x));

                    foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                    {
                        switch (element.Uid)
                        {
                            case "cb_mh":
                                int mahID = (int)((SATSComboBox)element).SelectedValue;
                                olay.mahalle = db.mahalleler.SingleOrDefault(x => x.ID == mahID);
                                break;
                            case "cb_fd":
                                int failID = (int)((SATSComboBox)element).SelectedValue;
                                olay.failDurum = db.failDurumu.SingleOrDefault(x => x.ID == failID);
                                break;
                            case "cb_sn":
                                int sucID = (int)((SATSComboBox)element).SelectedValue;
                                olay.suc = db.suclar.SingleOrDefault(x => x.ID == sucID);
                                break;
                            case "lw_supheli":
                                if (((SATSListView)element).Items.Count > 0)
                                {
                                    foreach (Supheli supheli in ((SATSListView)element).Items)
                                    {
                                        if (supheli.ID != 0)
                                        {
                                            olay.supheliler.Add((from s in db.supheliler where s.ID == supheli.ID select s).First());
                                        }
                                        else
                                        {
                                            olay.supheliler.Add(supheli);
                                        }
                                    }
                                }
                                break;
                            case "lw_magdur":
                                if (((SATSListView)element).Items.Count > 0)
                                {
                                    foreach (Magdur magdur in ((SATSListView)element).Items)
                                    {
                                        if (magdur.ID != 0)
                                        {
                                            olay.magdurlar.Add((from m in db.magdurlar where m.ID == magdur.ID select m).First());
                                        }
                                        else
                                        {
                                            olay.magdurlar.Add(magdur);
                                        }
                                    }
                                }
                                break;
                            case "tarih":
                                olay.tarih = (DateTime)((SATSDatePicker)element).SelectedDate;
                                break;
                        }
                    }

                    db.SaveChanges();
                }
                Form.Olustur((sender as SATSButton).Parent as Grid);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.OlayKayit
{
    /// <summary>
    /// Olay Kayıt Formunun Oluşturulması
    /// </summary>
    public static class Form
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

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
                Uid = "cb_il"
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
                Uid = "cb_ilce"
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
                Uid = "cb_pm"
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
                Margin = new Thickness(10, 10, 0, 20)
            };
            Grid.SetRow(btn_supheli_cikar, 6);
            Grid.SetColumn(btn_supheli_cikar, 5);

            SATSButton btn_ekle = new SATSButton
            {
                Content = "Kayıt Ekle",
                Margin = new Thickness(0, 0, 0, 7)
            };
            Grid.SetRow(btn_ekle, 7);
            Grid.SetColumn(btn_ekle, 4);
            Grid.SetColumnSpan(btn_ekle, 2);

            try
            {
                using (var db = new Context())
                {
                    var iller = (from i in db.iller select i).ToList();
                    cb_il.ItemsSource = iller;

                    var suclar = (from s in db.suclar select s).ToList();
                    cb_sn.ItemsSource = suclar;

                    var fail = (from f in db.failDurumu select f).ToList();
                    cb_fd.ItemsSource = fail;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }

            btn_magdur_cikar.Click += Olaylar.Btn_magdur_cikar_Click;
            btn_supheli_cikar.Click += Olaylar.Btn_supheli_cikar_Click;
            btn_ekle.Click += Btn_ekle_Click;
            btn_magdur_ekle.Click += Btn_magdur_ekle_Click;
            btn_supheli_ekle.Click += Btn_supheli_ekle_Click;
            cb_il.SelectionChanged += Olaylar.Cb_il_SelectionChanged;
            cb_ilce.SelectionChanged += Olaylar.Cb_ilce_SelectionChanged;
            cb_pm.SelectionChanged += Olaylar.Cb_pm_SelectionChanged;
            cb_fd.SelectionChanged += Olaylar.Cb_fd_SelectionChanged;

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
            g.Children.Add(btn_ekle);
        }

        private static void Btn_magdur_ekle_Click(object sender, RoutedEventArgs e)
        {
            MagdurEkle.Olustur((sender as SATSButton).Parent as Grid);
        }

        private static void Btn_supheli_ekle_Click(object sender, RoutedEventArgs e)
        {
            SupheliEkle.Olustur((sender as SATSButton).Parent as Grid);
        }

        private static void Btn_ekle_Click(object sender, RoutedEventArgs e)
        {
            Olay olay = new Olay();
            int mahalle_ID = 0;
            int failDurum_ID = 0;
            int suc_ID = 0;
            ItemCollection magdurlar = null;
            ItemCollection supheliler = null;

            try
            {
                foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
                {
                    switch (element.Uid)
                    {
                        case "cb_mh":
                            mahalle_ID = (int)((SATSComboBox)element).SelectedValue;
                            break;
                        case "cb_fd":
                            failDurum_ID = (int)((SATSComboBox)element).SelectedValue;
                            break;
                        case "cb_sn":
                            suc_ID = (int)((SATSComboBox)element).SelectedValue;
                            break;
                        case "lw_supheli":
                            if (((SATSListView)element).Items.Count > 0)
                            {
                                supheliler = ((SATSListView)element).Items;
                            }
                            break;
                        case "lw_magdur":
                            if (((SATSListView)element).Items.Count > 0)
                            {
                                magdurlar = ((SATSListView)element).Items;
                            }
                            break;
                        case "tarih":
                            olay.tarih = (DateTime)((SATSDatePicker)element).SelectedDate;
                            break;
                    }
                }

                using (var db = new Context())
                {
                    olay.mahalle = (from mah in db.mahalleler where mah.ID == mahalle_ID select mah).First();
                    olay.suc = (from suc in db.suclar where suc.ID == suc_ID select suc).First();
                    olay.failDurum = (from fd in db.failDurumu where fd.ID == failDurum_ID select fd).First();

                    if (supheliler != null)
                    {
                        foreach (Supheli supheli in supheliler)
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

                    if (magdurlar != null)
                    {
                        foreach (Magdur magdur in magdurlar)
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

                    db.olaylar.Add(olay);
                    db.SaveChanges();
                }

                Olustur((Grid)((SATSButton)sender).Parent);
            }
            catch (NullReferenceException)
            {
                MessageBoxResult result = MessageBox.Show("Lütfen Bütün Alanları Doldurunuz");
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }            
        }
    }
}
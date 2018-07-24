using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.Duzenle
{
    /// <summary>
    /// Düzenle Formunun Oluşturulması
    /// </summary>
    public static class Form
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 2, 2, 2, 2, 2, 2, 2);
            Islemler.ColumnOlustur(g, 0.5, 2, 2, 2, 2, 0.5);

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
            Grid.SetRow(lbl_ilce, 1);
            Grid.SetColumn(lbl_ilce, 3);

            SATSComboBox cb_ilce = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_ilce"
            };
            Grid.SetRow(cb_ilce, 1);
            Grid.SetColumn(cb_ilce, 4);

            SATSLabel lbl_pm = new SATSLabel();
            lbl_pm.Content = "Polis Merkezi:";
            Grid.SetRow(lbl_pm, 2);
            Grid.SetColumn(lbl_pm, 1);

            SATSComboBox cb_pm = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_pm"
            };
            Grid.SetRow(cb_pm, 2);
            Grid.SetColumn(cb_pm, 2);

            SATSLabel lbl_mh = new SATSLabel();
            lbl_mh.Content = "Mahalle:";
            Grid.SetRow(lbl_mh, 2);
            Grid.SetColumn(lbl_mh, 3);

            SATSComboBox cb_mh = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_mh"
            };
            Grid.SetRow(cb_mh, 2);
            Grid.SetColumn(cb_mh, 4);

            SATSLabel lbl_sn = new SATSLabel();
            lbl_sn.Content = "Suç Nevi:";
            Grid.SetRow(lbl_sn, 3);
            Grid.SetColumn(lbl_sn, 1);

            SATSComboBox cb_sn = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_sn"
            };
            Grid.SetRow(cb_sn, 3);
            Grid.SetColumn(cb_sn, 2);

            SATSLabel lbl_fd = new SATSLabel();
            lbl_fd.Content = "Fail Durumu:";
            Grid.SetRow(lbl_fd, 3);
            Grid.SetColumn(lbl_fd, 3);

            SATSComboBox cb_fd = new SATSComboBox
            {
                Margin = new Thickness(0, 25, 25, 25),
                SelectedValuePath = "ID",
                DisplayMemberPath = "failDurumu",
                Uid = "cb_fd"
            };
            Grid.SetRow(cb_fd, 3);
            Grid.SetColumn(cb_fd, 4);

            SATSLabel lbl_tarih_bas = new SATSLabel();
            lbl_tarih_bas.Content = "Başlangıç Tarihi:";
            Grid.SetRow(lbl_tarih_bas, 4);
            Grid.SetColumn(lbl_tarih_bas, 1);

            SATSDatePicker dp_bas = new SATSDatePicker
            {
                Margin = new Thickness(0, 0, 25, 0),
                Uid = "dp_bas"
            };
            Grid.SetRow(dp_bas, 4);
            Grid.SetColumn(dp_bas, 2);

            SATSLabel lbl_tarih_bit = new SATSLabel();
            lbl_tarih_bit.Content = "Bitiş Tarihi:";
            Grid.SetRow(lbl_tarih_bit, 4);
            Grid.SetColumn(lbl_tarih_bit, 3);

            SATSDatePicker dp_bit = new SATSDatePicker
            {
                FontSize = Application.Current.MainWindow.FontSize,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 25, 0),
                Uid = "dp_bit"
            };
            Grid.SetRow(dp_bit, 4);
            Grid.SetColumn(dp_bit, 4);

            SATSButton btn_ara = new SATSButton
            {
                Content = "Ara",
                Margin = new Thickness(0, 25, 25, 0)
            };
            Grid.SetRow(btn_ara, 5);
            Grid.SetColumn(btn_ara, 3);
            Grid.SetColumnSpan(btn_ara, 2);

            btn_ara.Click += Btn_ara_Click;
            cb_il.SelectionChanged += Olaylar.Cb_il_SelectionChanged;
            cb_ilce.SelectionChanged += Olaylar.Cb_ilce_SelectionChanged;
            cb_pm.SelectionChanged += Olaylar.Cb_pm_SelectionChanged;
            dp_bit.SelectedDateChanged += Olaylar.Dp_bit_SelectedDateChanged;
            dp_bas.SelectedDateChanged += Olaylar.Dp_bas_SelectedDateChanged;

            try
            {
                using (var db = new Context())
                {
                    var iller = (from i in db.iller select i).ToListAsync();
                    cb_il.ItemsSource = iller.Result;

                    var suclar = (from s in db.suclar select s).ToListAsync();
                    cb_sn.ItemsSource = suclar.Result;

                    var fail = (from f in db.failDurumu select f).ToListAsync();
                    cb_fd.ItemsSource = fail.Result;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }

            g.Children.Add(lbl_il);
            g.Children.Add(cb_il);
            g.Children.Add(lbl_ilce);
            g.Children.Add(cb_ilce);
            g.Children.Add(lbl_pm);
            g.Children.Add(cb_pm);
            g.Children.Add(lbl_sn);
            g.Children.Add(cb_sn);
            g.Children.Add(lbl_fd);
            g.Children.Add(cb_fd);
            g.Children.Add(lbl_tarih_bas);
            g.Children.Add(dp_bas);
            g.Children.Add(lbl_tarih_bit);
            g.Children.Add(dp_bit);
            g.Children.Add(btn_ara);
            g.Children.Add(lbl_mh);
            g.Children.Add(cb_mh);
        }

        private static void Btn_ara_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int il_ID = 0;

                foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
                {
                    if (element.Uid == "cb_il")
                    {
                        il_ID = (int)((ComboBox)element).SelectedValue;
                        break;
                    }
                }
                        
                using (var db = new Context())
                {
                    var sonuc = from s in db.olaylar where s.mahalle.polisMerkezi.ilce.İl.ID == il_ID select s;

                    foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
                    {
                        switch (element.Uid)
                        {
                            case "cb_ilce":
                                if (((SATSComboBox)element).SelectedValue != null) sonuc = (from s in sonuc where s.mahalle.polisMerkezi.ilce.ID == (int)((SATSComboBox)element).SelectedValue select s);
                                break;
                            case "cb_pm":
                                if (((SATSComboBox)element).SelectedValue != null) sonuc = (from s in sonuc where s.mahalle.polisMerkezi.ID == (int)((SATSComboBox)element).SelectedValue select s);
                                break;
                            case "cb_mh":
                                if (((SATSComboBox)element).SelectedValue != null) sonuc = (from s in sonuc where s.mahalle.ID == (int)((SATSComboBox)element).SelectedValue select s);
                                break;
                            case "cb_sn":
                                if (((SATSComboBox)element).SelectedValue != null) sonuc = (from s in sonuc where s.suc.ID == (int)((SATSComboBox)element).SelectedValue select s);
                                break;
                            case "cb_fd":
                                if (((SATSComboBox)element).SelectedValue != null) sonuc = (from s in sonuc where s.failDurum.ID == (int)((SATSComboBox)element).SelectedValue select s);
                                break;
                            case "dp_bas":
                                if (((SATSDatePicker)element).SelectedDate != null) sonuc = (from s in sonuc where s.tarih >= ((SATSDatePicker)element).SelectedDate select s);
                                break;
                            case "dp_bit":
                                if (((SATSDatePicker)element).SelectedDate != null) sonuc = (from s in sonuc where s.tarih <= ((SATSDatePicker)element).SelectedDate select s);
                                break;
                        }
                    }

                    AramaSonuclari.Olustur(((Grid)((SATSButton)sender).Parent), sonuc.ToList());
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Lütfen gerekli alanları doldurup arama yapınız.");
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }
        }
    }
}

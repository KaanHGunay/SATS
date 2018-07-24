using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.VeriTabani;
using SATS.Ortak;
using SATS.Ortak.Elementler;

namespace SATS.Istatistikler
{
    /// <summary>
    /// Bölge bazlı istatistik için sorgulama formu
    /// </summary>
    public static class BolgeSorgulama
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 3, 2, 2, 2, 2, 3);
            Islemler.ColumnOlustur(g, 0.5, 2, 2, 2, 2, 0.5);

            SATSLabel lbl_baslik = new SATSLabel();
            lbl_baslik.Content = "Bölgeye Göre İstatistikler";
            Grid.SetRow(lbl_baslik, 0);
            Grid.SetColumn(lbl_baslik, 1);
            Grid.SetColumnSpan(lbl_baslik, 4);

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

            SATSLabel lbl_tarih_bas = new SATSLabel();
            lbl_tarih_bas.Content = "Başlangıç Tarihi:";
            Grid.SetRow(lbl_tarih_bas, 3);
            Grid.SetColumn(lbl_tarih_bas, 1);

            SATSDatePicker dp_bas = new SATSDatePicker
            {
                Margin = new Thickness(0, 0, 25, 0),
                Uid = "dp_bas"
            };
            Grid.SetRow(dp_bas, 3);
            Grid.SetColumn(dp_bas, 2);

            SATSLabel lbl_tarih_bit = new SATSLabel();
            lbl_tarih_bit.Content = "Bitiş Tarihi:";
            Grid.SetRow(lbl_tarih_bit, 3);
            Grid.SetColumn(lbl_tarih_bit, 3);

            SATSDatePicker dp_bit = new SATSDatePicker
            {
                Margin = new Thickness(0, 0, 25, 0),
                Uid = "dp_bit"
            };
            Grid.SetRow(dp_bit, 3);
            Grid.SetColumn(dp_bit, 4);

            SATSButton btn_ist = new SATSButton
            {
                Content = "İstatistik Göster",
                Margin = new Thickness(0, 25, 25, 0)
            };
            Grid.SetRow(btn_ist, 4);
            Grid.SetColumn(btn_ist, 3);
            Grid.SetColumnSpan(btn_ist, 2);

            cb_il.SelectionChanged += Olaylar.Cb_il_SelectionChanged;
            cb_ilce.SelectionChanged += Olaylar.Cb_ilce_SelectionChanged;
            cb_pm.SelectionChanged += Olaylar.Cb_pm_SelectionChanged;
            dp_bit.SelectedDateChanged += Olaylar.Dp_bit_SelectedDateChanged;
            dp_bas.SelectedDateChanged += Olaylar.Dp_bas_SelectedDateChanged;
            btn_ist.Click += Btn_ist_Click;

            try
            {
                using (var db = new Context())
                {
                    var iller = (from i in db.iller select i).ToListAsync();
                    cb_il.ItemsSource = iller.Result;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }

            g.Children.Add(lbl_baslik);
            g.Children.Add(lbl_il);
            g.Children.Add(cb_il);
            g.Children.Add(lbl_ilce);
            g.Children.Add(cb_ilce);
            g.Children.Add(lbl_pm);
            g.Children.Add(cb_pm);
            g.Children.Add(lbl_tarih_bas);
            g.Children.Add(dp_bas);
            g.Children.Add(lbl_tarih_bit);
            g.Children.Add(dp_bit);
            g.Children.Add(btn_ist);
            g.Children.Add(lbl_mh);
            g.Children.Add(cb_mh);
        }

        private static void Btn_ist_Click(object sender, RoutedEventArgs e)
        {
            int ilSecimi = 0, ilceSecimi = 0, polisMerkeziSecimi = 0, mahalleSecimi = 0;
            DateTime? basTarihSecimi = null, bitTarihSecimi = null;
            bool ilSeciliMi = false, ilceSeciliMi = false, polisMerkeziSeciliMi = false, mahalleSeciliMi = false, basTarihSeciliMi = false, bitTarihSeciliMi = false;

            foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
            {
                switch (element.Uid)
                {
                    case "cb_il":
                        if ((element as SATSComboBox).SelectedValue != null) { ilSeciliMi = true; ilSecimi = (int)(element as SATSComboBox).SelectedValue; }
                        break;
                    case "cb_ilce":
                        if ((element as SATSComboBox).SelectedValue != null) { ilceSeciliMi = true; ilceSecimi = (int)(element as SATSComboBox).SelectedValue; }
                        break;
                    case "cb_pm":
                        if ((element as SATSComboBox).SelectedValue != null) { polisMerkeziSeciliMi = true; polisMerkeziSecimi = (int)(element as SATSComboBox).SelectedValue; }
                        break;
                    case "cb_mh":
                        if ((element as SATSComboBox).SelectedValue != null) { mahalleSeciliMi = true; mahalleSecimi = (int)(element as SATSComboBox).SelectedValue; }
                        break;
                    case "dp_bas":
                        if ((element as SATSDatePicker).SelectedDate != null) { basTarihSeciliMi = true; basTarihSecimi = (element as SATSDatePicker).SelectedDate; }
                        break;
                    case "dp_bit":
                        if ((element as SATSDatePicker).SelectedDate != null) { bitTarihSeciliMi = true; bitTarihSecimi = (element as SATSDatePicker).SelectedDate; }
                        break;
                }
            }

            if (basTarihSeciliMi && bitTarihSeciliMi && ilSeciliMi)
            {
                if (ilSeciliMi && !ilceSeciliMi)
                {
                    IlIstatistikGoruntuleyici.Olustur((sender as SATSButton).Parent as Grid, ilSecimi, basTarihSecimi, bitTarihSecimi);
                }
                else if (ilceSeciliMi && !polisMerkeziSeciliMi)
                {
                    IlceIstatistikGoruntuleyici.Olustur((sender as SATSButton).Parent as Grid, ilceSecimi, basTarihSecimi, bitTarihSecimi);
                }
                else if (polisMerkeziSeciliMi && !mahalleSeciliMi)
                {
                    PolisMerkeziIstatistikGoruntuleyici.Olustur((sender as SATSButton).Parent as Grid, polisMerkeziSecimi, basTarihSecimi, bitTarihSecimi);
                }
                else
                {
                    MahalleIstatistikGoruntuleyici.Olustur((sender as SATSButton).Parent as Grid, mahalleSecimi, basTarihSecimi, bitTarihSecimi);
                }
            }
        }
    }
}

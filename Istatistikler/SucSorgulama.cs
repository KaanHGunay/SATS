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
    /// Suç bazlı sorgulama formu
    /// </summary>
    public static class SucSorgulama
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 3, 2, 2, 2, 3);
            Islemler.ColumnOlustur(g, 0.5, 2, 2, 2, 2, 0.5);

            SATSLabel lbl_baslik = new SATSLabel();
            lbl_baslik.Content = "Suça Göre İstatistikler";
            Grid.SetRow(lbl_baslik, 0);
            Grid.SetColumn(lbl_baslik, 1);
            Grid.SetColumnSpan(lbl_baslik, 4);

            SATSLabel lbl_suc = new SATSLabel();
            lbl_suc.Content = "Suç Tipi:";
            Grid.SetRow(lbl_suc, 1);
            Grid.SetColumn(lbl_suc, 1);

            SATSComboBox cb_suc = new SATSComboBox
            {
                Margin = new Thickness(0, 35, 25, 35),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_suc"
            };
            Grid.SetRow(cb_suc, 1);
            Grid.SetColumn(cb_suc, 2);

            SATSLabel lbl_tarih_bas = new SATSLabel();
            lbl_tarih_bas.Content = "Başlangıç Tarihi:";
            Grid.SetRow(lbl_tarih_bas, 2);
            Grid.SetColumn(lbl_tarih_bas, 1);

            SATSDatePicker dp_bas = new SATSDatePicker
            {
                Margin = new Thickness(0, 0, 25, 0),
                Uid = "dp_bas"
            };
            Grid.SetRow(dp_bas, 2);
            Grid.SetColumn(dp_bas, 2);

            SATSLabel lbl_tarih_bit = new SATSLabel();
            lbl_tarih_bit.Content = "Bitiş Tarihi:";
            Grid.SetRow(lbl_tarih_bit, 2);
            Grid.SetColumn(lbl_tarih_bit, 3);

            SATSDatePicker dp_bit = new SATSDatePicker
            {
                Margin = new Thickness(0, 0, 25, 0),
                Uid = "dp_bit"
            };
            Grid.SetRow(dp_bit, 2);
            Grid.SetColumn(dp_bit, 4);

            SATSButton btn_sucist = new SATSButton
            {
                Content = "İstatistik Göster",
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 25, 25, 0)
            };
            Grid.SetRow(btn_sucist, 3);
            Grid.SetColumn(btn_sucist, 4);

            try
            {
                using (var db = new Context())
                {
                    var suclar = (from s in db.suclar select s).ToList();
                    cb_suc.ItemsSource = suclar;
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }

            btn_sucist.Click += Btn_sucist_Click;

            g.Children.Add(lbl_baslik);
            g.Children.Add(lbl_suc);
            g.Children.Add(cb_suc);
            g.Children.Add(lbl_tarih_bas);
            g.Children.Add(dp_bas);
            g.Children.Add(lbl_tarih_bit);
            g.Children.Add(dp_bit);
            g.Children.Add(btn_sucist);
        }

        private static void Btn_sucist_Click(object sender, RoutedEventArgs e)
        {
            int sucSecimi = 0;
            DateTime? basTarihSecimi = null, bitTarihSecimi = null;
            bool sucSeciliMi = false, basTarihSeciliMi = false, bitTarihSeciliMi = false;

            foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
            {
                switch (element.Uid)
                {
                    case "cb_suc":
                        if ((element as SATSComboBox).SelectedValue != null) { sucSeciliMi = true; sucSecimi = (int)(element as SATSComboBox).SelectedValue; }
                        break;
                    case "dp_bas":
                        if ((element as SATSDatePicker).SelectedDate != null) { basTarihSeciliMi = true; basTarihSecimi = (element as SATSDatePicker).SelectedDate; }
                        break;
                    case "dp_bit":
                        if ((element as SATSDatePicker).SelectedDate != null) { bitTarihSeciliMi = true; bitTarihSecimi = (element as SATSDatePicker).SelectedDate; }
                        break;
                }
            }

            if (sucSeciliMi && basTarihSeciliMi && bitTarihSeciliMi)
            {
                SucIstatistikGoruntuleyici.Olustur((sender as SATSButton).Parent as Grid, sucSecimi, basTarihSecimi, bitTarihSecimi);
            }
        }
    }
}

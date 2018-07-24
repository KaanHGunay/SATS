using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.Profilim
{
    /// <summary>
    /// Profilim formunun oluşturulması
    /// </summary>
    public static class Form
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 5, 2, 2, 2, 2, 5);
            Islemler.ColumnOlustur(g, 2.5, 2, 2, 2.5);

            SATSLabel lbl_mev_sifre = new SATSLabel();
            lbl_mev_sifre.Content = "Mevcut Şifre:";
            Grid.SetRow(lbl_mev_sifre, 1);
            Grid.SetColumn(lbl_mev_sifre, 1);

            PasswordBox pss_mev_sifre = new PasswordBox
            {
                FontSize = Application.Current.MainWindow.FontSize,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10),
                Uid = "pss_mev_sifre"
            };
            Grid.SetRow(pss_mev_sifre, 1);
            Grid.SetColumn(pss_mev_sifre, 2);

            SATSLabel lbl_yeni_sifre = new SATSLabel();
            lbl_yeni_sifre.Content = "Yeni Şifre:";
            Grid.SetRow(lbl_yeni_sifre, 2);
            Grid.SetColumn(lbl_yeni_sifre, 1);

            PasswordBox pss_yeni_sifre = new PasswordBox
            {
                FontSize = Application.Current.MainWindow.FontSize,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10),
                Uid = "pss_yeni_sifre"
            };
            Grid.SetRow(pss_yeni_sifre, 2);
            Grid.SetColumn(pss_yeni_sifre, 2);

            SATSLabel lbl_yeni_sifre_tk = new SATSLabel();
            lbl_yeni_sifre_tk.Content = "Yeni Şifre:";
            Grid.SetRow(lbl_yeni_sifre_tk, 3);
            Grid.SetColumn(lbl_yeni_sifre_tk, 1);

            PasswordBox pss_yeni_sifre_tk = new PasswordBox
            {
                FontSize = Application.Current.MainWindow.FontSize,
                VerticalContentAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10),
                Uid = "pss_yeni_sifre_tk"
            };
            Grid.SetRow(pss_yeni_sifre_tk, 3);
            Grid.SetColumn(pss_yeni_sifre_tk, 2);

            SATSButton btn_kaydet = new SATSButton
            {
                Content = "Kaydet",
                Margin = new Thickness(10)
            };
            Grid.SetRow(btn_kaydet, 4);
            Grid.SetColumn(btn_kaydet, 2);

            btn_kaydet.Click += Btn_kaydet_Click;

            g.Children.Add(lbl_mev_sifre);
            g.Children.Add(pss_mev_sifre);
            g.Children.Add(lbl_yeni_sifre);
            g.Children.Add(pss_yeni_sifre);
            g.Children.Add(lbl_yeni_sifre_tk);
            g.Children.Add(pss_yeni_sifre_tk);
            g.Children.Add(btn_kaydet);
        }

        private static void Btn_kaydet_Click(object sender, RoutedEventArgs e)
        {
            string eskiSifre = "", yeniSifre = "", yeniSifreTekrar = "";

            foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
            {
                switch (element.Uid)
                {
                    case "pss_mev_sifre":
                        if ((element as PasswordBox).Password.Length > 0) eskiSifre = (element as PasswordBox).Password;
                        break;
                    case "pss_yeni_sifre":
                        if ((element as PasswordBox).Password.Length > 0) yeniSifre = (element as PasswordBox).Password;
                        break;
                    case "pss_yeni_sifre_tk":
                        if ((element as PasswordBox).Password.Length > 0) yeniSifreTekrar = (element as PasswordBox).Password;
                        break;
                }
            }

            try
            {
                using (var db = new Context())
                {
                    int sicil = (int)((((sender as SATSButton).Parent as Grid).Parent as Grid).Parent as Window).Tag;
                    if (eskiSifre == (from s in db.personeller where s.sicil == sicil select s.sifre).SingleOrDefault() && yeniSifre.Length > 5 && yeniSifre == yeniSifreTekrar)
                    {
                        var personel = (from p in db.personeller where p.sicil == sicil select p).SingleOrDefault();
                        personel.sifre = yeniSifre;
                        db.SaveChanges();
                    }
                }

                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is PasswordBox)
                    {
                        (element as PasswordBox).Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }
        }
    }
}

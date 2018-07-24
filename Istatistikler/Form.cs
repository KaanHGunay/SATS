using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;

namespace SATS.Istatistikler
{
    /// <summary>
    /// İstatistikler Formunun Oluşturulması
    /// </summary>
    public static class Form
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 1, 5, 1);
            Islemler.ColumnOlustur(g, 1, 8, 8, 1);

            SATSButton btn_bolge = new SATSButton
            {
                Content = "Bölgeye Göre İstatistikler",
                Margin = new Thickness(0, 0, 25, 0),
                BorderThickness = new Thickness(0)
            };
            Grid.SetRow(btn_bolge, 1);
            Grid.SetColumn(btn_bolge, 1);

            SATSButton btn_suc = new SATSButton
            {
                Content = "Suça Göre İstatistikler",
                Margin = new Thickness(25, 0, 0, 0),
                BorderThickness = new Thickness(0)
            };
            Grid.SetRow(btn_suc, 1);
            Grid.SetColumn(btn_suc, 2);

            btn_bolge.Click += Btn_bolge_Click;
            btn_suc.Click += Btn_suc_Click;

            g.Children.Add(btn_bolge);
            g.Children.Add(btn_suc);
        }

        private static void Btn_bolge_Click(object sender, RoutedEventArgs e)
        {
            (((sender as SATSButton).Parent as Grid).Parent as Grid).Tag = "Bölge";
            BolgeSorgulama.Olustur((sender as SATSButton).Parent as Grid);
        }

        private static void Btn_suc_Click(object sender, RoutedEventArgs e)
        {
            (((sender as SATSButton).Parent as Grid).Parent as Grid).Tag = "Suç";
            SucSorgulama.Olustur((sender as SATSButton).Parent as Grid);
        }
    }
}

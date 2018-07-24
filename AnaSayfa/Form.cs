using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.AnaSayfa
{
    public static class Form
    {
        public static void Olustur(Grid g)
        {
            WindowDuzenle(g);

            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 1, 1, 1, 1, 1, 1, 5);
            Islemler.ColumnOlustur(g, 2, 11);

            SATSButton btn_OlayKayit = new SATSButton();
            btn_OlayKayit.Content = "Olay Kayıt";
            Grid.SetRow(btn_OlayKayit, 1);
            Grid.SetColumn(btn_OlayKayit, 0);

            SATSButton btn_Duzenle = new SATSButton();
            btn_Duzenle.Content = "Düzenle/sil";
            Grid.SetRow(btn_Duzenle, 2);
            Grid.SetColumn(btn_Duzenle, 0);

            SATSButton btn_Istatistikler = new SATSButton();
            btn_Istatistikler.Content = "İstatistikler";
            Grid.SetRow(btn_Istatistikler, 3);
            Grid.SetColumn(btn_Istatistikler, 0);

            SATSButton btn_Profilim = new SATSButton();
            btn_Profilim.Content = "Profilim";
            Grid.SetRow(btn_Profilim, 4);
            Grid.SetColumn(btn_Profilim, 0);

            SATSButton btn_Iletisim = new SATSButton();
            btn_Iletisim.Content = "İletişim";
            Grid.SetRow(btn_Iletisim, 5);
            Grid.SetColumn(btn_Iletisim, 0);

            SATSLabel lbl_Isim = new SATSLabel();
            lbl_Isim.Margin = new Thickness(0, 0, 12, 0);
            lbl_Isim.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetRow(lbl_Isim, 0);
            Grid.SetColumn(lbl_Isim, 1);

            Grid grMenu = new Grid();
            Grid.SetRow(grMenu, 1);
            Grid.SetColumn(grMenu, 1);
            Grid.SetRowSpan(grMenu, 6);

            SATSLabel lbl_Hosgeldiniz = new SATSLabel();
            lbl_Hosgeldiniz.Content = "Hoşgeldiniz";

            int sicil = (int)(g.Parent as Window).Tag;
            using (var db = new Context())
            {
                var q = (from prs in db.personeller where prs.sicil == sicil select prs).FirstOrDefaultAsync();
                lbl_Isim.Content = string.Format("{0} {1} {2} / {3}", q.Result.rutbe.adi, q.Result.adi, q.Result.soyadi, q.Result.polisMerkezi.adi);
            }

            btn_OlayKayit.Click += Btn_OlayKayit_Click;
            btn_Duzenle.Click += Btn_Duzenle_Click;
            btn_Istatistikler.Click += Btn_Istatistikler_Click;
            btn_Profilim.Click += Btn_Profilim_Click;
            btn_Iletisim.Click += Btn_Iletisim_Click;

            grMenu.Children.Add(lbl_Hosgeldiniz);
            g.Children.Add(btn_OlayKayit);
            g.Children.Add(btn_Duzenle);
            g.Children.Add(btn_Istatistikler);
            g.Children.Add(btn_Profilim);
            g.Children.Add(btn_Iletisim);
            g.Children.Add(lbl_Isim);
            g.Children.Add(grMenu);
        }

        private static void Btn_Iletisim_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as SATSButton).Parent as Grid).Tag != (sender as SATSButton).Content)
            {
                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is Grid)
                    {
                        Iletisim.Form.Olustur(element as Grid);
                        break;
                    }                
                }
                ((sender as SATSButton).Parent as Grid).Tag = (sender as SATSButton).Content;
            }            
        }

        private static void Btn_Profilim_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as SATSButton).Parent as Grid).Tag != (sender as SATSButton).Content)
            {
                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is Grid)
                    {
                        Profilim.Form.Olustur(element as Grid);
                        break;
                    }
                }
                ((sender as SATSButton).Parent as Grid).Tag = (sender as SATSButton).Content;
            }
        }

        private static void Btn_Istatistikler_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as SATSButton).Parent as Grid).Tag != (sender as SATSButton).Content)
            {
                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is Grid)
                    {
                        Istatistikler.Form.Olustur(element as Grid);
                        break;
                    }
                }
                ((sender as SATSButton).Parent as Grid).Tag = (sender as SATSButton).Content;
            }
        }

        private static void Btn_Duzenle_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as SATSButton).Parent as Grid).Tag != (sender as SATSButton).Content)
            {
                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is Grid)
                    {
                        Duzenle.Form.Olustur(element as Grid);
                        break;
                    }
                }
                ((sender as SATSButton).Parent as Grid).Tag = (sender as SATSButton).Content;
            }
        }

        private static void Btn_OlayKayit_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as SATSButton).Parent as Grid).Tag != (sender as SATSButton).Content)
            {
                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is Grid)
                    {
                        OlayKayit.Form.Olustur(element as Grid);
                        break;
                    }
                }
                ((sender as SATSButton).Parent as Grid).Tag = (sender as SATSButton).Content;
            }
        }

        private static void WindowDuzenle(Grid g)
        {
            (g.Parent as Window).Background = Ayarlar.GriRenk;
            (g.Parent as Window).FontSize = Ayarlar.YaziBoyutu;
            (g.Parent as Window).Title = "SATS";
            (g.Parent as Window).WindowState = WindowState.Maximized;
            (g.Parent as Window).Closed += Form_Closed;
            g.Tag = "İlk Kullanım";
        }

        private static void Form_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

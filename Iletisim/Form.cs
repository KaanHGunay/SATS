using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.VeriTabani;
using SATS.Ortak;
using SATS.Ortak.Elementler;

namespace SATS.Iletisim
{
    /// <summary>
    /// İletişim Formunun Oluşturulması
    /// </summary>
    public static class Form
    {
        public static void Olustur(Grid g)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 0.5, 1, 1, 1, 6, 1, 1);
            Islemler.ColumnOlustur(g, 1, 8, 1);

            SATSLabel lbl_konu = new SATSLabel();
            lbl_konu.Content = "Konu:";
            lbl_konu.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(lbl_konu, 1);
            Grid.SetColumn(lbl_konu, 1);

            SATSTextBox txt_konu = new SATSTextBox
            {
                Margin = new Thickness(10),
                Uid = "txt_konu"
            };
            Grid.SetRow(txt_konu, 2);
            Grid.SetColumn(txt_konu, 1);

            SATSLabel lbl_mesaj = new SATSLabel();
            lbl_mesaj.Content = "Mesaj:";
            lbl_mesaj.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(lbl_mesaj, 3);
            Grid.SetColumn(lbl_mesaj, 1);

            SATSTextBox txt_mesaj = new SATSTextBox
            {
                Margin = new Thickness(10),
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                Uid = "txt_mesaj"
            };
            Grid.SetRow(txt_mesaj, 4);
            Grid.SetColumn(txt_mesaj, 1);

            SATSButton btn_gonder = new SATSButton
            {
                Content = "Gönder",
                Margin = new Thickness(10)
            };
            Grid.SetRow(btn_gonder, 5);
            Grid.SetColumn(btn_gonder, 1);

            btn_gonder.Click += Btn_gonder_Click;

            g.Children.Add(lbl_konu);
            g.Children.Add(txt_konu);
            g.Children.Add(lbl_mesaj);
            g.Children.Add(txt_mesaj);
            g.Children.Add(btn_gonder);
        }

        private static void Btn_gonder_Click(object sender, RoutedEventArgs e)
        {
            string konu = "", mesaj = "";

            foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
            {
                switch (element.Uid)
                {
                    case "txt_konu":
                        if ((element as SATSTextBox).Text.Length > 0) konu = (element as SATSTextBox).Text;
                        break;
                    case "txt_mesaj":
                        if ((element as SATSTextBox).Text.Length > 0) mesaj = (element as SATSTextBox).Text;
                        break;
                }
            }

            try
            {
                using (var db = new Context())
                {
                    Mesaj msj = new Mesaj();
                    msj.Konu = konu;
                    msj.Ileti = mesaj;
                    int sicil = (int)((((sender as SATSButton).Parent as Grid).Parent as Grid).Parent as Window).Tag;
                    msj.Personel = (from p in db.personeller where p.sicil == sicil select p).SingleOrDefault();
                    db.mesajlar.Add(msj);
                    db.SaveChanges();
                }

                foreach (UIElement element in ((sender as SATSButton).Parent as Grid).Children)
                {
                    if (element is SATSTextBox)
                    {
                        (element as SATSTextBox).Clear();
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

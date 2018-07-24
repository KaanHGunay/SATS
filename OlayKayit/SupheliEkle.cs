using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.OlayKayit
{
    /// <summary>
    /// Olay Ekleme Formunda oluşturulan yeni olaya şüpheli ekleme formu
    /// </summary>
    public static class SupheliEkle
    {
        private static ItemCollection supheliCollection;

        public static void Olustur(Grid g)
        {
            List<UIElement> olayEkle = new List<UIElement>();
            foreach (UIElement element in g.Children)
            {
                if (element.Uid == "lw_supheli")
                {
                    supheliCollection = ((SATSListView)element).Items;
                }
                olayEkle.Add(element);
            }

            g.Children.Clear();

            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.ColumnOlustur(g, 0.1, 1, 1, 1, 0.1, 0.7);
            Islemler.RowOlustur(g, 0.5, 0.1, 0.1, 0.3, 0.3, 0.3, 0.3, 0.3, 0.5, 0.5);


            SATSLabel lbl_TC = new SATSLabel();
            lbl_TC.Content = "TC Kimlik No:";
            Grid.SetRow(lbl_TC, 3);
            Grid.SetColumn(lbl_TC, 1);

            SATSLabel lbl_isim = new SATSLabel();
            lbl_isim.Content = "İsim:";
            Grid.SetRow(lbl_isim, 4);
            Grid.SetColumn(lbl_isim, 1);

            SATSLabel lbl_soyisim = new SATSLabel();
            lbl_soyisim.Content = "Soyisim:";
            Grid.SetRow(lbl_soyisim, 5);
            Grid.SetColumn(lbl_soyisim, 1);

            SATSTextBox txt_TC = new SATSTextBox
            {
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(15),
                Uid = "supheliEkle_txtTC"
            };
            Grid.SetRow(txt_TC, 3);
            Grid.SetColumn(txt_TC, 2);

            SATSTextBox txt_isim = new SATSTextBox
            {
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(15),
                Uid = "supheliEkle_txtIsim"
            };
            Grid.SetRow(txt_isim, 4);
            Grid.SetColumn(txt_isim, 2);

            SATSTextBox txt_soyisim = new SATSTextBox
            {
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(15),
                Uid = "supheliEkle_txtSoyisim"
            };
            Grid.SetRow(txt_soyisim, 5);
            Grid.SetColumn(txt_soyisim, 2);

            SATSLabel lbl_supheliDurum = new SATSLabel();
            lbl_supheliDurum.Content = "Şüpheli Durumu:";
            Grid.SetRow(lbl_supheliDurum, 6);
            Grid.SetColumn(lbl_supheliDurum, 1);

            SATSComboBox cb_supheliDurum = new SATSComboBox
            {
                Margin = new Thickness(15),
                SelectedValuePath = "ID",
                DisplayMemberPath = "adi",
                Uid = "cb_supheliDurum"
            };
            Grid.SetRow(cb_supheliDurum, 6);
            Grid.SetColumn(cb_supheliDurum, 2);

            SATSListView lw_liste = new SATSListView();
            lw_liste.Uid = "supheliEkle_lwListe";
            Grid.SetRowSpan(lw_liste, 6);
            Grid.SetRow(lw_liste, 2);
            Grid.SetColumn(lw_liste, 3);
            if (supheliCollection != null)
            {
                foreach (Supheli item in supheliCollection)
                {
                    lw_liste.Items.Add(item);
                }
            }

            SATSButton btn_ekle = new SATSButton
            {
                Content = "Ekle",
                Margin = new Thickness(15)
            };
            Grid.SetRow(btn_ekle, 7);
            Grid.SetColumn(btn_ekle, 2);

            SATSButton btn_cikar = new SATSButton
            {
                Content = "-",
                VerticalContentAlignment = VerticalAlignment.Top,
                Margin = new Thickness(2, 0, 0, 0)
            };
            Grid.SetRow(btn_cikar, 2);
            Grid.SetColumn(btn_cikar, 4);

            SATSButton btn_tamam = new SATSButton
            {
                Content = "Tamam",
                Margin = new Thickness(0, 15, 0, 15)
            };
            Grid.SetRow(btn_tamam, 8);
            Grid.SetColumn(btn_tamam, 3);

            /*using (var db = new Context())
            {
                var durum = (from f in db.supheliDurumlari select f).ToList();
                cb_supheliDurum.ItemsSource = durum;
            }*/

            g.Tag = olayEkle;

            txt_TC.PreviewTextInput += Txt_TC_PreviewTextInput;
            txt_TC.IsKeyboardFocusedChanged += Txt_TC_IsKeyboardFocusedChanged;
            btn_ekle.Click += Btn_ekle_Click;
            btn_cikar.Click += Btn_cikar_Click;
            btn_tamam.Click += Btn_tamam_Click;

            g.Children.Add(lbl_TC);
            g.Children.Add(lbl_isim);
            g.Children.Add(lbl_soyisim);
            g.Children.Add(txt_TC);
            g.Children.Add(txt_isim);
            g.Children.Add(txt_soyisim);
            g.Children.Add(lw_liste);
            g.Children.Add(btn_ekle);
            g.Children.Add(btn_cikar);
            g.Children.Add(btn_tamam);
            g.Children.Add(lbl_supheliDurum);
            g.Children.Add(cb_supheliDurum);
        }

        private static void Btn_tamam_Click(object sender, RoutedEventArgs e)
        {
            OlayEkle_Reverse.Olustur(((Grid)((SATSButton)sender).Parent));
        }

        private static void Btn_cikar_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
            {
                if (element is SATSListView)
                {
                    ((SATSListView)element).Items.Remove(((SATSListView)element).SelectedItem);
                }
            }
        }

        private static void Btn_ekle_Click(object sender, RoutedEventArgs e)
        {
            Supheli supheli = new Supheli();

            foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
            {
                switch (element.Uid)
                {
                    case "supheliEkle_txtIsim":
                        supheli.adi = ((SATSTextBox)element).Text;
                        ((SATSTextBox)element).Clear();
                        break;
                    case "supheliEkle_txtSoyisim":
                        supheli.soyadi = ((SATSTextBox)element).Text;
                        ((SATSTextBox)element).Clear();
                        break;
                    case "supheliEkle_txtTC":
                        supheli.TC = ((SATSTextBox)element).Text;
                        ((SATSTextBox)element).Clear();
                        break;
                        /*case "cb_supheliDurum":
                            using(var db = new Context())
                            {
                                supheli.supheliDurum = (from sd in db.supheliDurumlari where sd.ID == (int)((SATSComboBox)element).SelectedValue select sd).First();
                            }
                            break;*/
                }
            }

            foreach (UIElement element in ((Grid)((SATSButton)sender).Parent).Children)
            {
                if (element is SATSListView && supheli.TC.Length == 11 && supheli.adi != null && supheli.soyadi != null /*&& supheli.supheliDurum != null*/)
                {
                    try
                    {
                        using (var db = new Context())
                        {
                            var sp = (from s in db.supheliler where s.TC == supheli.TC select s).First();
                            supheli = sp;
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        //do_nothing
                    }
                    catch (Exception ex)
                    {
                        MessageBoxResult result = MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        ((SATSListView)element).Items.Add(supheli);
                    }
                    break;
                }
            }
        }

        private static void Txt_TC_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if ((!char.IsDigit(e.Text, e.Text.Length - 1)))
            {
                e.Handled = true;
            }
        }

        private static void Txt_TC_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (((SATSTextBox)sender).Text.Length == 11)
            {
                try
                {
                    using (var db = new Context())
                    {
                        var supheli = (from sahis in db.supheliler where sahis.TC == ((SATSTextBox)sender).Text select sahis).FirstOrDefault();

                        if (supheli != null)
                        {
                            foreach (UIElement element in ((Grid)((SATSTextBox)sender).Parent).Children)
                            {
                                switch (element.Uid)
                                {
                                    case "supheliEkle_txtIsim":
                                        ((SATSTextBox)element).Text = supheli.adi;
                                        break;
                                    case "supheliEkle_txtSoyisim":
                                        ((SATSTextBox)element).Text = supheli.soyadi;
                                        break;
                                }
                            }
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
}

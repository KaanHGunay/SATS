using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.VeriTabani;
using SATS.Ortak.Elementler;

namespace SATS.Ortak
{
    /// <summary>
    /// Formlarda ortak kullanılacak olan eventlerin tanımlanması
    /// </summary>
    public static class Olaylar
    {
        public static void Cb_il_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSComboBox)sender).Parent).Children)
            {
                if (element.Uid == "cb_ilce")
                {
                    if (((SATSComboBox)element).Items.Count > 0)
                    {
                        ((SATSComboBox)element).ItemsSource = null;
                    }
                    using (var db = new Context())
                    {
                        var ilce = (from ilceler in db.ilceler where ilceler.İl.ID == (int)((SATSComboBox)sender).SelectedValue select ilceler).ToListAsync();
                        ((SATSComboBox)element).ItemsSource = ilce.Result;
                    }
                    break;
                }
            }
        }

        public static void Cb_ilce_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSComboBox)sender).Parent).Children)
            {
                if (element.Uid == "cb_pm")
                {
                    if (((SATSComboBox)element).Items.Count > 0)
                    {
                        ((SATSComboBox)element).ItemsSource = null;
                    }
                    else
                    {
                        using (var db = new Context())
                        {
                            var pm = (from polismerkezi in db.polisMerkezleri where polismerkezi.ilce.ID == (int)((SATSComboBox)sender).SelectedValue select polismerkezi).ToListAsync();
                            ((SATSComboBox)element).ItemsSource = pm.Result;
                        }
                        break;
                    }
                }
            }
        }

        public static void Cb_pm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSComboBox)sender).Parent).Children)
            {
                if (element.Uid == "cb_mh")
                {
                    if (((SATSComboBox)element).Items.Count > 0)
                    {
                        ((SATSComboBox)element).ItemsSource = null;
                    }
                    else
                    {
                        using (var db = new Context())
                        {
                            var mh = (from mahalle in db.mahalleler where mahalle.polisMerkezi.ID == (int)((SATSComboBox)sender).SelectedValue select mahalle).ToListAsync();
                            ((SATSComboBox)element).ItemsSource = mh.Result;
                        }
                        break;
                    }
                }
            }
        }

        public static void Btn_supheli_cikar_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((Button)sender).Parent).Children)
            {
                if (element.Uid == "lw_supheli")
                {
                    ((SATSListView)element).Items.Remove(((SATSListView)element).SelectedItem);
                }
            }
        }

        public static void Btn_magdur_cikar_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((Button)sender).Parent).Children)
            {
                if (element.Uid == "lw_magdur")
                {
                    ((SATSListView)element).Items.Remove(((SATSListView)element).SelectedItem);
                }
            }
        }

        public static void Cb_fd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((int)((SATSComboBox)sender).SelectedValue == 1) //Faili Meçhul
            {
                foreach (UIElement element in ((Grid)((SATSComboBox)sender).Parent).Children)
                {
                    if (element.Uid == "btn_supheliEkle")
                    {
                        element.IsEnabled = false;
                    }
                    if (element.Uid == "lw_supheli")
                    {
                        ((SATSListView)element).Items.Clear();
                    }
                }
            }
            else
            {
                foreach (UIElement element in ((Grid)((SATSComboBox)sender).Parent).Children)
                {
                    if (element.Uid == "btn_supheliEkle")
                    {
                        element.IsEnabled = true;
                        break;
                    }
                }
            }
        }

        public static void Dp_bas_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSDatePicker)sender).Parent).Children)
            {
                if (element.Uid == "dp_bit")
                {
                    if (((SATSDatePicker)element).SelectedDate != null)
                    {
                        if (((SATSDatePicker)sender).SelectedDate > ((SATSDatePicker)element).SelectedDate)
                        {
                            ((SATSDatePicker)sender).SelectedDate = ((SATSDatePicker)element).SelectedDate;
                        }
                    }
                    break;
                }
            }
        }

        public static void Dp_bit_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (UIElement element in ((Grid)((SATSDatePicker)sender).Parent).Children)
            {
                if (element.Uid == "dp_bas")
                {
                    if (((SATSDatePicker)element).SelectedDate != null)
                    {
                        if (((DatePicker)sender).SelectedDate < ((SATSDatePicker)element).SelectedDate)
                        {
                            ((SATSDatePicker)sender).SelectedDate = ((SATSDatePicker)element).SelectedDate;
                        }
                    }
                    break;
                }
            }
        }
    }
}

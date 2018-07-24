using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SATS.VeriTabani;

namespace SATS.AnaProje
{
    /// <summary>
    /// GirisEkrani.xaml etkileşim mantığı
    /// </summary>
    public partial class GirisEkrani : Window
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void txt_sicil_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((!char.IsDigit(e.Text, e.Text.Length - 1)))
            {
                e.Handled = true;
            }
        }

        private void btnGiris_Click(object sender, RoutedEventArgs e)
        {
            if (txt_sicil.Text.Length >= 5 && pass.Password.Length > 0)
            {
                int sicil = Convert.ToInt32(txt_sicil.Text);
                try
                {
                    using (var db = new Context())
                    {
                        var personel = (from p in db.personeller where p.sicil == sicil select p).SingleOrDefault();

                        if (pass.Password == personel.sifre)
                        {
                            Program p = new Program(sicil);
                            p.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen sicil ve şifrenizi kontrol edin.");
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Lütfen sicil ve şifrenizi kontrol edin.");
                }
                catch (Exception ex)
                {
                    MessageBoxResult result = MessageBox.Show(ex.Message);
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

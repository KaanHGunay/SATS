using System;
using System.Windows;

namespace SATS.AnaProje
{
    /// <summary>
    /// Program.xaml etkileşim mantığı
    /// </summary>
    public partial class Program : Window
    {
        public Program(int sicil)
        {
            Tag = sicil;
            InitializeComponent();            
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            AnaSayfa.Form.Olustur(g);
        }
    }
}

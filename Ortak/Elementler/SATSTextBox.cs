using System.Windows;
using System.Windows.Controls;

namespace SATS.Ortak.Elementler
{
    public class SATSTextBox : TextBox
    {
        public SATSTextBox()
        {
            FontSize = Ayarlar.YaziBoyutu;
            VerticalContentAlignment = VerticalAlignment.Center;
        }
    }
}

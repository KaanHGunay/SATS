using System.Windows;
using System.Windows.Controls;

namespace SATS.Ortak.Elementler
{
    public class SATSComboBox : ComboBox
    {
        public SATSComboBox()
        {
            FontSize = Ayarlar.YaziBoyutu;
            VerticalContentAlignment = VerticalAlignment.Center;
        }
    }
}

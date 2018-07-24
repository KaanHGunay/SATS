using System.Windows;
using System.Windows.Controls;

namespace SATS.Ortak.Elementler
{
    public class SATSDatePicker : DatePicker
    {
        public SATSDatePicker()
        {
            FontSize = Ayarlar.YaziBoyutu;
            VerticalAlignment = VerticalAlignment.Center;
        }
    }
}

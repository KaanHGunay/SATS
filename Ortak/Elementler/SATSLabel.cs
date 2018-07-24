using System.Windows;
using System.Windows.Controls;

namespace SATS.Ortak.Elementler
{
    public class SATSLabel : Label
    {
        public SATSLabel()
        {
            Foreground = Ayarlar.BeyazRenk;
            Background = Ayarlar.GriRenk;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            FontSize = Ayarlar.YaziBoyutu;
        }
    }
}

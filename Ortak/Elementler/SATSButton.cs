using System.Windows.Controls;

namespace SATS.Ortak.Elementler
{
    public class SATSButton : Button
    {
        public SATSButton()
        {
            FontSize = Ayarlar.YaziBoyutu;
            Foreground = Ayarlar.BeyazRenk;
            Background = Ayarlar.GriRenk;
        }
    }
}

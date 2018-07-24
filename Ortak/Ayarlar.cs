using System.Windows.Media;

namespace SATS.Ortak
{
    /// <summary>
    /// Formlarda ortak kullanılacak olan propertylerin tanımlanması
    /// </summary>
    public static class Ayarlar
    {
        public static Brush BeyazRenk
        {
            get { return new SolidColorBrush(Color.FromRgb(255, 255, 255)); }
        }

        public static Brush GriRenk
        {
            get { return new SolidColorBrush(Color.FromRgb(51, 51, 51)); }
        }

        public static double YaziBoyutu
        {
            get { return 25; }
        }
    }
}

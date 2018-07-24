using System.Windows;
using System.Windows.Controls;

namespace SATS.Ortak
{
    /// <summary>
    /// Formlarda kullanılacak olan metotların tanımlanması
    /// </summary>
    public static class Islemler
    {
        public static void RowOlustur(Grid g, params double[] RowAralik)
        {
            foreach (double yukseklik in RowAralik)
            {
                RowDefinition rd = new RowDefinition
                {
                    Height = new GridLength(yukseklik, GridUnitType.Star)
                };
                g.RowDefinitions.Add(rd);
            }
        }

        public static void ColumnOlustur(Grid g, params double[] ColumnAralik)
        {
            foreach (double genislik in ColumnAralik)
            {
                ColumnDefinition cd = new ColumnDefinition
                {
                    Width = new GridLength(genislik, GridUnitType.Star)
                };
                g.ColumnDefinitions.Add(cd);
            }
        }
    }
}

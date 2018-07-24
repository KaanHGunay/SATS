using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SATS.Ortak;
using SATS.Ortak.Elementler;
using SATS.VeriTabani;

namespace SATS.Istatistikler
{
    /// <summary>
    /// İstatistiği istenen polis merkezinin verilerinin gösterildiği form
    /// </summary>
    public static class PolisMerkeziIstatistikGoruntuleyici
    {
        public static void Olustur(Grid g, int polisMerkeziID, DateTime? basTarih, DateTime? bitTarih)
        {
            g.Children.Clear();
            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            Islemler.RowOlustur(g, 2, 1, 1, 1, 5);
            Islemler.ColumnOlustur(g, 1, 2, 2, 1);

            SATSLabel lbl_OlaySayisi_Metin = new SATSLabel();
            lbl_OlaySayisi_Metin.Content = "Meydana Gelen Toplam Olay Sayısı:";
            Grid.SetRow(lbl_OlaySayisi_Metin, 1);
            Grid.SetColumn(lbl_OlaySayisi_Metin, 1);

            SATSLabel lbl_OlaySayisi = new SATSLabel();
            Grid.SetRow(lbl_OlaySayisi, 1);
            Grid.SetColumn(lbl_OlaySayisi, 2);

            SATSLabel lbl_FailiMechul_Metin = new SATSLabel();
            lbl_FailiMechul_Metin.Content = "Faili Meçhul Olan Olay Sayısı:";
            Grid.SetRow(lbl_FailiMechul_Metin, 2);
            Grid.SetColumn(lbl_FailiMechul_Metin, 1);

            SATSLabel lbl_FailiMechul = new SATSLabel();
            Grid.SetRow(lbl_FailiMechul, 2);
            Grid.SetColumn(lbl_FailiMechul, 2);

            SATSLabel lbl_enCokIslenenSuc_Metin = new SATSLabel();
            lbl_enCokIslenenSuc_Metin.Content = "En Çok İşlenen Suç:";
            Grid.SetRow(lbl_enCokIslenenSuc_Metin, 3);
            Grid.SetColumn(lbl_enCokIslenenSuc_Metin, 1);

            SATSLabel lbl_enCokIslenenSuc = new SATSLabel();
            Grid.SetRow(lbl_enCokIslenenSuc, 3);
            Grid.SetColumn(lbl_enCokIslenenSuc, 2);

            try
            {
                using (var db = new Context())
                {
                    var sonuc = (from s in db.olaylar where s.mahalle.polisMerkezi.ID == polisMerkeziID && s.tarih >= basTarih && s.tarih <= bitTarih select s);
                    lbl_OlaySayisi.Content = sonuc.Count();
                    var failiMechul = (from s in sonuc where s.failDurum.failDurumu == "Faili Meçhul" select s).ToList();
                    lbl_FailiMechul.Content = failiMechul.Count();
                    var enCokIslenenSuc = ((from s in sonuc group s by s.suc into a select new { suc = a.Key, sayi = a.Count() }).OrderByDescending(c => c.sayi).ToList())[0];
                    lbl_enCokIslenenSuc.Content = String.Format("{0} ({1})", enCokIslenenSuc.suc.adi, enCokIslenenSuc.sayi);
                }
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show(ex.Message);
            }

            g.Children.Add(lbl_OlaySayisi_Metin);
            g.Children.Add(lbl_OlaySayisi);
            g.Children.Add(lbl_FailiMechul_Metin);
            g.Children.Add(lbl_FailiMechul);
            g.Children.Add(lbl_enCokIslenenSuc_Metin);
            g.Children.Add(lbl_enCokIslenenSuc);
        }
    }
}

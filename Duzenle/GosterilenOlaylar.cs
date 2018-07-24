using System;

namespace SATS.Duzenle
{
    /// <summary>
    /// Veri tabanından yapılan sorgualama sonucunda elde edilen olayların entitylerinin Data Grid de gösterilmesini sağlayan ara sınıf
    /// </summary>
    class GosterilenOlaylar
    {
        public int ID { get; set; }
        public string il { get; set; }
        public string ilce { get; set; }
        public string mahalle { get; set; }
        public string polisMerkezi { get; set; }
        public string suc { get; set; }
        public int magdurSayisi { get; set; }
        public int supheliSayisi { get; set; }
        public DateTime tarih { get; set; }
    }
}

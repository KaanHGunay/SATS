using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Personel
    {
        [Key]
        public int sicil { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string sifre { get; set; }

        public virtual PolisMerkezi polisMerkezi { get; set; }
        public virtual Rutbe rutbe { get; set; }
        public virtual List<Mesaj> mesajlar { get; set; }
    }
}

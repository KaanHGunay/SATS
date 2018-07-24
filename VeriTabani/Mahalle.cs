using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Mahalle
    {
        public Mahalle()
        {
            olaylar = new List<Olay>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public virtual PolisMerkezi polisMerkezi { get; set; }
        public virtual List<Olay> olaylar { get; set; }
    }
}

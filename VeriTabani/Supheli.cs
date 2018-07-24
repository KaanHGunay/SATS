using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Supheli
    {
        public Supheli()
        {
            olaylar = new HashSet<Olay>();
        }

        [Key]
        public int ID { get; set; }
        [MaxLength(11)]
        public string TC { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }

        public ICollection<Olay> olaylar { get; set; }

        public override string ToString()
        {
            return adi + " " + soyadi;
        }
    }
}

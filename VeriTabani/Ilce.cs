using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Ilce
    {
        public Ilce()
        {
            PolisMerkezleri = new List<PolisMerkezi>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public virtual Il İl { get; set; }
        public virtual List<PolisMerkezi> PolisMerkezleri { get; set; }
    }
}

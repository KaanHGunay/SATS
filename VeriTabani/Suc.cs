using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Suc
    {
        public Suc()
        {
            olaylar = new List<Olay>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public List<Olay> olaylar { get; set; }
    }
}

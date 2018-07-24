using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class FailDurum
    {
        public FailDurum()
        {
            olaylar = new List<Olay>();
        }

        [Key]
        public int ID { get; set; }
        public string failDurumu { get; set; }

        public List<Olay> olaylar { get; set; }
    }
}

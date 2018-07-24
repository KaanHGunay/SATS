using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Il
    {
        public Il()
        {
            ilceler = new List<Ilce>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public virtual List<Ilce> ilceler { get; set; }
    }
}

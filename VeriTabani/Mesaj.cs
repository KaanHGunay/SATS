using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATS.VeriTabani
{
    public class Mesaj
    {
        [Key]
        public int ID { get; set; }
        public string Konu { get; set; }
        public string Ileti { get; set; }

        public virtual Personel Personel { get; set; }
    }
}

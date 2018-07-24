using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATS.VeriTabani
{
    public class supheliDurum
    {
        public supheliDurum()
        {
            supheliler = new List<supheli>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public List<supheli> supheliler { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Olay
    {
        public Olay()
        {
            magdurlar = new HashSet<Magdur>();
            supheliler = new HashSet<Supheli>();
        }

        [Key]
        public int ID { get; set; }
        public DateTime tarih { get; set; }

        public virtual Mahalle mahalle { get; set; }
        public virtual Suc suc { get; set; }
        public ICollection<Magdur> magdurlar { get; set; }
        public ICollection<Supheli> supheliler { get; set; }
        public virtual FailDurum failDurum { get; set; }
    }
}

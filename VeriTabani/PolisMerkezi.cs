using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class PolisMerkezi
    {
        public PolisMerkezi()
        {
            mahalleler = new List<Mahalle>();
            personeller = new List<Personel>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public virtual Ilce ilce { get; set; }
        public virtual List<Mahalle> mahalleler { get; set; }
        public virtual List<Personel> personeller { get; set; }
    }
}

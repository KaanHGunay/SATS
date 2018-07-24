using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SATS.VeriTabani
{
    public class Rutbe
    {
        public Rutbe()
        {
            personeller = new List<Personel>();
        }

        [Key]
        public int ID { get; set; }
        public string adi { get; set; }

        public List<Personel> personeller { get; set; }
    }
}

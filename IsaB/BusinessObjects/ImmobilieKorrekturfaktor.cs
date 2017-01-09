using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    public class ImmobilieKorrekturfaktor
    {
        public int ID { get; set; }
        public int ImmoId { get; set; }
        public int FaktorTyp { get; set; }
        public double Faktor { get; set; }
        public double? Faktorkriterium { get; set; }
        public int? FaktorId { get; set; }
        public bool Anwenden { get; set; }
    }
}

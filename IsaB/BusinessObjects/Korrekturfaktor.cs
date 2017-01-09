using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    public class Korrekturfaktor
    {
        public int GebArtId { get; set; }
        public int TypId { get; set; }
        public string Beschreibung { get; set; }
        public double? XVal { get; set; }
        public double Faktor { get; set; }
    }
}

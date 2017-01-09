using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    public class Gebaeudestandardstufe 
    {
        public int Stufe { get; set; }
        public string Beschreibung { get; set; }
        public int GebTeilId { get; set; }
        public int TabellenId { get; set; }
    }
}

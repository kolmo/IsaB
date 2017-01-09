using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    public class Baupreisindex 
    {
        public int TabellenId { get; set; }
        public int Jahr { get; set; }
        public int Quartal { get; set; }
        public double Index { get; set; }
        public bool Aenderbar { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    /// <summary>
    /// Waegungsanteil eines Gebäudeteils, je nach Standardtabelle
    /// </summary>
    public class Waegungsanteil
    {
        public int TabellenId { get; set; }
        public int GebTeilId { get; set; }
        public int Waegung { get; set; }
    }
}

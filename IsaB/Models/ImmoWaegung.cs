using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    /// <summary>
    /// Waegungsanteil eines Gebäudeteils, je nach Standardtabelle
    /// </summary>
    public class ImmoWaegung
    {
        public int TabellenId { get; set; }
        public int GebTeilId { get; set; }
        public int Waegung { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IsaB.Model
{
    public class ImmoNHKosten
    {
        public int? BauweiseId { get; set; }
        public int? AusbZustandId { get; set; }
        public int GebArtId { get; set; }
        public int Standardstufe { get; set; }
        public double KostenProM2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    public class Korrekturfaktortyp
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Interpolierbar { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.BusinessObjects
{
    public class Bauweise 
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public override string ToString()
        {
            return Bezeichnung;
        }
    }
}

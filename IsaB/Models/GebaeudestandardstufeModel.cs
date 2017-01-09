using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public class GebaeudestandardstufeModel
    {
        public GebaeudestandardstufeModel(Gebaeudestandardstufe standardStufe)
        {
            Stufe = standardStufe.Stufe;
            Beschreibung = standardStufe.Beschreibung;
        }
        public int Stufe { get; private set; }
        public string Beschreibung { get; private set; }
    }
}

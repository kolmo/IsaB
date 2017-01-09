using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public class AusbauModel : GebaeudeBaseModel
    {
        #region Fields
        Ausbauzustand _ausbau;
        #endregion
        #region Construction
        public AusbauModel(Ausbauzustand ausbau)
        {
            _ausbau = ausbau;
            ID = _ausbau.ID;
            Bezeichnung = _ausbau.Bezeichnung;
        }
        #endregion
    }
}

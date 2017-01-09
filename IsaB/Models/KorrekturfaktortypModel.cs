using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public class KorrekturfaktortypModel
    {
        #region Fields
        Korrekturfaktortyp _faktorTyp;
        #endregion
        public int Id { get { return _faktorTyp.Id; } }
        public string Bezeichnung { get { return _faktorTyp.Bezeichnung; } }
        public bool Interpolierbar { get { return _faktorTyp.Interpolierbar; } }
        #region Construction
        public KorrekturfaktortypModel(Korrekturfaktortyp faktorTyp)
        {
            _faktorTyp = faktorTyp;
        }
        #endregion
    }
}

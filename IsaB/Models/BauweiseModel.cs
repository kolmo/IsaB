using IsaB.Common;
using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public class BauweiseModel : GebaeudeBaseModel
    {
        #region Fields
        Bauweise _bauweise;
        #endregion

        #region Construction
        public BauweiseModel(Bauweise bauweise)
        {
            _bauweise = bauweise;
            ID = _bauweise.ID;
            Bezeichnung = _bauweise.Bezeichnung;
        }
        #endregion
    }
}

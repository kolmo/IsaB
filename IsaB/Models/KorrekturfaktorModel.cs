using IsaB.Common;
using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.StoreApps;

namespace IsaB.Model
{
    public class KorrekturfaktorModel : BindableBase
    {
        #region Fields
        Korrekturfaktor _korrekturfaktor;
        #endregion
        private bool _isSelected;
        /// <summary>
        /// Gets or sets the IsSelected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                Set(ref _isSelected, value);
            }
        }

        public string Beschreibung { get { return _korrekturfaktor.Beschreibung; } }
        public double? XVal { get { return _korrekturfaktor.XVal; } }
        public double Faktor { get { return _korrekturfaktor.Faktor; } }
        public KorrekturfaktortypModel FaktorTyp { get; private set; }

        #region Construction
        public KorrekturfaktorModel(Korrekturfaktor kfac, Korrekturfaktortyp faktorTyp)
        {
            _korrekturfaktor = kfac;
            FaktorTyp = new KorrekturfaktortypModel(faktorTyp);
        }
        #endregion
    }
}

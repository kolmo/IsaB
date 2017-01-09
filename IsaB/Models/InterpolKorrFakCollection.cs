using IsaB.BusinessObjects;
using IsaB.Helper;
using IsaB.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    /// <summary>
    /// Faktorkollektion für Faktoren mit Zwischenwerten
    /// </summary>
    public class InterpolKorrFakCollection : KorrFakCollectionBase
    {
        #region Fields
        private Dictionary<double, double> _korrFunction = new Dictionary<double, double>();
        #endregion
        private double _selectedXValue;
        /// <summary>
        /// Gets or sets the SelectedXValue.
        /// </summary>
        public double SelectedXValue
        {
            get { return _selectedXValue; }
            set
            {
                if (_selectedXValue != value)
                {
                    _selectedXValue = value;
                    SelectedFaktorkriterium = _selectedXValue;
                    if (_korrFunction != null && _korrFunction.Any())
                        Faktorwert = ImmoRechner.LocateAndInterpolate(_korrFunction, _selectedXValue);
                }
            }
        }

        public InterpolKorrFakCollection()
        {
        }
        public InterpolKorrFakCollection(Korrekturfaktortyp typ,
            IEnumerable<Korrekturfaktor> list)
            : base(typ, list)
        {
            _korrFunction.Clear();
            foreach (Korrekturfaktor item in list)
            {
                if (item.XVal.HasValue)
                    _korrFunction[item.XVal.Value] = item.Faktor;
            }
        }

        public override void SetFaktorWert(ImmobilieKorrekturfaktor wert)
        {
            if (wert.Faktorkriterium.HasValue)
                SelectedXValue = wert.Faktorkriterium.Value;
        }
    }
}

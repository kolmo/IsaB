using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Model
{
    public class GebaeudeteilModel : BaseModel
    {
        Gebaeudeteil _gebaeudeteil;
        ImmobilieTeilStandard _teileStandard;
        /// <summary>
        /// Der gesetzte Wert der Standardstufe
        /// </summary>
        public double Stufe
        {
            get { return _teileStandard.Wert; }
            set
            {
                if (_teileStandard.Wert != value)
                {
                    _teileStandard.Wert = value;
                    Repository.SaveTeilStandard(_teileStandard);
                }
            }
        }
        public ImmobilieTeilStandard Teilstandard { get { return _teileStandard; } }
        /// <summary>
        /// Die Stufe kann hier eine Fließkommazahl sein!
        /// </summary>
        public int? Waegungsanteil { get; set; }
        public GebaeudeteilModel(Gebaeudeteil gTeil, ImmobilieTeilStandard its)
        {
            _gebaeudeteil = gTeil;
            _teileStandard = its;
        }
        public int ID { get { return _gebaeudeteil.ID; } }
        public string Bezeichnung { get { return _gebaeudeteil.Bezeichnung; } }
        public int ImmoId { get { return _teileStandard.ImmoId; } }
    }
}

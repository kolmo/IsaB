using IsaB.Common;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IsaB.Interfaces;
using IsaB.BusinessObjects;

namespace IsaB.Model
{
    public class GebaeudestandardModel : BaseModel
    {
        #region Fields
        ImmobilieTeilStandard _immobilieTeilStandard;
        Immobilie _immobilie;
        #endregion
        #region Properties
        public IList<GebaeudestandardstufeModel> Stufen { get; private set; }
        /// <summary>
        /// Der gesetzte Wert der Standardstufe
        /// </summary>
        public double Stufe
        {
            get { return _immobilieTeilStandard.Wert; }
            set
            {
                if (_immobilieTeilStandard.Wert != value)
                {
                    _immobilieTeilStandard.Wert = value;
                    Repository.SaveTeilStandard(_immobilieTeilStandard);
                }
            }
        }
        public GebaeudeteilModel Gebaeudeteil { get; private set; }
        /// <summary>
        /// Die Stufe kann hier eine Fließkommazahl sein!
        /// </summary>
        public int? Waegungsanteil { get; set; }
        /// <summary>
        /// Stufen und deren Beschreibung
        /// </summary>
        #endregion
        public GebaeudestandardModel(
            ImmobilieTeilStandard its, 
            Immobilie immobilie)
        {
            _immobilieTeilStandard = its;
            _immobilie = immobilie;
            var gt = Repository.ListAllGebaeudeteile();
            //Gebaeudeteil = new GebaeudeteilModel(gt.First(x => x.ID == _immobilieTeilStandard.TeileId));
            var waegung = Repository.ListWaegungsanteileByGebArtId(_immobilie.GebaeudeartId).FirstOrDefault(x => x.GebTeilId == Gebaeudeteil.ID);
            Waegungsanteil = waegung != null ? waegung.Waegung : default(int?);
            var stufen = Repository.ListStandardstufenByTeilIdAndGebArtId(its.TeileId, immobilie.GebaeudeartId);
            Stufen = new List<GebaeudestandardstufeModel>();
            foreach (Gebaeudestandardstufe item in stufen)
            {
                Stufen.Add(new GebaeudestandardstufeModel(item));
            }
        }

        #region Private Methods
       
        #endregion
    }
}

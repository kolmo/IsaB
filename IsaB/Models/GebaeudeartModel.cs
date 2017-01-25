using IsaB.BusinessObjects;
using System.Linq;

namespace IsaB.Model
{
    /// <summary>
    /// Repräsentiert die lokale Klasse für Gebäudeart
    /// </summary>
    public class GebaeudeartModel : GebaeudeBaseModel
    {
        #region Static fields
        #endregion
        #region Fields
        Gebaeudeart _gebaeudeart;
        #endregion
        #region Props

        private bool _hasKorrFaks;
        /// <summary>
        /// Gets or sets the HasKorrekturfaktoren.
        /// </summary>
        public bool HasKorrekturfaktoren
        {
            get { return _hasKorrFaks; }
            set
            {
                Set(ref _hasKorrFaks, value);
            }
        }

        #endregion
        #region Construction
        public GebaeudeartModel(Gebaeudeart gebaeudeart, IKorrfaktorService korrfakService)
        {
            _gebaeudeart = gebaeudeart;
            this.ID = _gebaeudeart.ID;
            Bezeichnung = _gebaeudeart.Bezeichnung;

            var korrFaks = korrfakService.LoadKorrekturfaktorenByGebArtId(ID);
            HasKorrekturfaktoren = korrFaks.Any();
        }
        #endregion

    }
}

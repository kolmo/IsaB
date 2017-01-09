using IsaB.BusinessObjects;
using System.Collections.Generic;
using Template10.Mvvm;

namespace IsaB.Model
{
    /// <summary>
    /// Basisklasse für die unterschiedlichen Korrekturfaktorlisten
    /// </summary>
    public abstract class KorrFakCollectionBase : BindableBase
    {
        #region Fields
        private double? _faktorwert;
        private List<KorrekturfaktorModel> _korrFaktorListe = new List<KorrekturfaktorModel>();
        #endregion
        public Korrekturfaktortyp KorrFakTyp { get; set; }
        public double? SelectedFaktorkriterium { get; set; }
        public string SelectedFaktorName { get; set; }
        /// <summary>
        /// Der selektierte Wert des Korrekturfaktors
        /// </summary>
        public double? Faktorwert
        {
            get { return _faktorwert; }
            set
            {
                Set(ref _faktorwert, value);
            }
        }

        private bool _anwenden;
        /// <summary>
        /// TRUE wenn der Korrekturfaktor anzuwenden ist.
        /// </summary>
        public bool Anwenden
        {
            get { return _anwenden; }
            set
            {
                Set(ref _anwenden, value);
            }
        }

        public List<KorrekturfaktorModel> KorrFaktorListe { get { return _korrFaktorListe; }  }
        public KorrFakCollectionBase()
        {
        }
        public KorrFakCollectionBase(Korrekturfaktortyp typ, 
            IEnumerable<Korrekturfaktor> korrfaktorListe):this()
        {
            KorrFakTyp = typ;
            foreach (Korrekturfaktor item in korrfaktorListe)
            {
                KorrekturfaktorModel modell = new KorrekturfaktorModel(item, KorrFakTyp);
                KorrFaktorListe.Add(modell);
            };
        }
        /// <summary>
        /// Beim Initialisieren
        /// </summary>
        /// <param name="wert"></param>
        public abstract void SetFaktorWert(ImmobilieKorrekturfaktor wert);
    }
}

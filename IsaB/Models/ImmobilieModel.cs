using System;
using System.Collections.Generic;
using IsaB.BusinessObjects;
using Windows.UI.Xaml.Media;
using Template10.Mvvm;

namespace IsaB.Model
{
    /// <summary>
    /// Repraesentiert eine Immobilie (kurz Immo)
    /// </summary>
    public class ImmobilieModel : BindableBase
    {
        #region Fields
        private Immobilie _immobilie;
        #endregion

        #region Properties
        private ImageSource _titelbild;
        public ImageSource Titelbild
        {
            get { return _titelbild; }
            set
            {
                Set(ref _titelbild, value);
            }
        }
        /// <summary>
        /// Gets or sets the Restnutzungsdauer.
        /// </summary>
        public int? Restnutzungsdauer
        {
            get { return _immobilie.Restnutzungsdauer; }
        }
        public IList<TeilStandard> TeileStandards { get; private set; }
        /// <summary>
        /// Gets or sets the GewichtetStandard.
        /// </summary>
        public double GewichtetStandard
        {
            get { return _immobilie.GewichtetStandard; }
        }
  
        /// <summary>
        /// Gets or sets the Grundstuecksflaeche.
        /// </summary>
        public float? Grundstuecksflaeche
        {
            get { return _immobilie.Grundstuecksflaeche; }
        }
         /// <summary>
        /// Bruttogesamtflaeche (BGF).
        /// </summary>
        public float? Bruttogrundflaeche
        {
            get { return _immobilie.Bruttogrundflaeche; }
        }
        /// <summary>
        /// Der Verkaufspreis
        /// </summary>
        public double? Verkaufspreis
        {
            get { return _immobilie.Verkaufspreis; }
        }
        /// <summary>
        /// Der vorlaeufige Sachwert.
        /// </summary>
        public double? VorlSachwert
        {
            get { return _immobilie.VorlSachwert; }
        }

        /// <summary>
        /// Der eindeutige Identifier der Immo
        /// </summary>
        public int ID { get { return _immobilie.ID;} }

        public string DisplayName
        {
            get
            {
                string ort = Ort ?? "<Ort>";
                string strasse = Strasse ?? "<Strasse>";
                return string.Format("{0}, {1}", ort, strasse);
            }
        }
        /// <summary>
        /// Gets or sets the Strasse.
        /// </summary>
        public string Strasse
        {
            get { return _immobilie.Strasse; }
        }
        /// <summary>
        /// Adresse - Ort
        /// </summary>
        public string Ort
        {
            get { return _immobilie.Ort; }
        }
        /// <summary>
        /// Adresse - Postleitzahl
        /// </summary>
        public string PLZ
        {
            get { return _immobilie.PLZ; }
        }
        /// <summary>
        /// ID der zugeordneten Gebäudeart
        /// </summary>
        public int? GebaeudeartId { get; set; }
        /// <summary>
        /// Gets or sets the bauweise identifier.
        /// </summary>
        public int? BauweiseId { get; set; }
        /// <summary>
        /// Gets or sets the ausbauzustand identifier.
        /// </summary>
        public int? AusbauzustandId { get; set; }
        /// <summary>
        /// Dient zur Anzeige in den Item-Panels
        /// </summary>
        byte[] _bilddaten;
        public byte[] Bilddaten
        {
            get { return _bilddaten; }
            set
            {
                if (_bilddaten != value)
                {
                    _bilddaten = value;
                }
            }
        }
        /// <summary>
        /// Der Bodenrichtwert in EUR/qm
        /// </summary>
        public float? Bodenrichtwert
        {
            get
            {
                return _immobilie.Bodenrichtwert;
            }
        }
        /// <summary>
        /// Das Baujahr
        /// </summary>
        public int? Baujahr
        {
            get
            {
                return _immobilie.Baujahr;
            }
        }
        /// <summary>
        /// Anlegedatum des Datensatzes
        /// </summary>
        public DateTime ErzeugtAm { get; set; }
        #endregion
        #region Constructor
        public ImmobilieModel(Immobilie immobilie)
        {
            _immobilie = immobilie;
            this.TeileStandards = new List<TeilStandard>();
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string result = string.Empty;
            if (!String.IsNullOrWhiteSpace(Strasse))
                result = Strasse;
            if (!String.IsNullOrWhiteSpace(Ort))
                result = Ort + ", " + result;
            if (!String.IsNullOrWhiteSpace(PLZ))
                result = PLZ + " " + result;
            if (String.IsNullOrWhiteSpace(result))
                result = "<Unbekannt>";
            return result;
        }
        #endregion
    }
}

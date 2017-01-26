using System;

namespace IsaB.Entities
{
    /// <summary>
    /// Repraesentiert eine Immobilie (kurz Immo)
    /// </summary>
    [SQLite.Table("Immobilie")]
    public class ImmobilieEntity : IsaB.Base.Entity
    {
        #region Constructor
        //public ImmobilieEntity()
        //{

        //}
        #endregion

        #region Fields
        private float? _bruttogrundflaeche;
        private float? _grundstuecksflaeche;
        #endregion

        #region Properties

        private int? _restnutzungsdauer;
        /// <summary>
        /// Gets or sets the Restnutzungsdauer.
        /// </summary>
        public int? Restnutzungsdauer
        {
            get { return _restnutzungsdauer; }
            set
            {
                if (_restnutzungsdauer != value)
                {
                    _restnutzungsdauer = value;
                }
            }
        }

        private DateTime? _verfuegbarAb;
        /// <summary>
        /// Ab wann ist die Immobilie frei
        /// </summary>
        public DateTime? VerfuegbarAb
        {
            get { return _verfuegbarAb; }
            set
            {
                if (_verfuegbarAb != value)
                {
                    _verfuegbarAb = value;
                }
            }
        }

        private double _globalStandard;
        /// <summary>
        /// Gets or sets the GewichtetStandard.
        /// </summary>
        public double GlobalStandard
        {
            get { return _globalStandard; }
            set
            {
                if (_globalStandard != value)
                {
                    _globalStandard = value;
                }
            }
        }
        private bool? _useExpertStandardSettings;
        /// <summary>
        /// Zeigt an ob für das Gebäude der Standardwert aus den detaillierten Festlegungen
        /// der betreffenden Standardmerkmale ermittelt werden soll.
        /// </summary>
        public bool? UseExpertStandardSettings
        {
            get { return _useExpertStandardSettings; }
            set { _useExpertStandardSettings = value; }
        }

        /// <summary>
        /// Gets or sets the Grundstuecksflaeche.
        /// </summary>
        public float? Grundstuecksflaeche
        {
            get { return _grundstuecksflaeche; }
            set
            {
                if (_grundstuecksflaeche != value)
                {
                    _grundstuecksflaeche = value;
                }
            }
        }
        /// <summary>
        /// Bruttogesamtflaeche (BGF).
        /// </summary>
        public float? Bruttogrundflaeche
        {
            get { return _bruttogrundflaeche; }
            set
            {
                if (_bruttogrundflaeche != value)
                {
                    _bruttogrundflaeche = value;
                }
            }
        }
        private double? _verkaufspreis;
        /// <summary>
        /// Der Verkaufspreis
        /// </summary>
        public double? Verkaufspreis
        {
            get { return _verkaufspreis; }
            set
            {
                if (_verkaufspreis != value)
                {
                    _verkaufspreis = value;
                }
            }
        }

        private double? _vorlSachwert;
        /// <summary>
        /// Der vorlaeufige Sachwert.
        /// </summary>
        public double? VorlSachwert
        {
            get { return _vorlSachwert; }
            set
            {
                if (_vorlSachwert != value)
                {
                    _vorlSachwert = value;
                }
            }
        }
        private string _strasse;
        /// <summary>
        /// Gets or sets the Strasse.
        /// </summary>
        public string Strasse
        {
            get { return _strasse; }
            set
            {
                if (_strasse != value)
                {
                    _strasse = value;
                }
            }
        }
        private string _ort;
        /// <summary>
        /// Adresse - Ort
        /// </summary>
        public string Ort
        {
            get { return _ort; }
            set
            {
                if (_ort != value)
                {
                    _ort = value;
                }
            }
        }
        private string _plz;
        /// <summary>
        /// Adresse - Postleitzahl
        /// </summary>
        public string PLZ
        {
            get { return _plz; }
            set
            {
                if (_plz != value)
                {
                    _plz = value;
                }
            }
        }
        /// <summary>
        /// ID der zugeordneten Gebäudeart
        /// </summary>
        public int GebaeudeartId { get; set; }
        /// <summary>
        /// Gets or sets the bauweise identifier.
        /// </summary>
        public int? BauweiseId { get; set; }
        /// <summary>
        /// Gets or sets the ausbauzustand identifier.
        /// </summary>
        public int? AusbauzustandId { get; set; }
        /// <summary>
        /// Der Bodenrichtwert in EUR/qm
        /// </summary>
        public float? Bodenrichtwert { get; set; }
        /// <summary>
        /// Das Baujahr
        /// </summary>
        public int? Baujahr { get; set; }
        /// <summary>
        /// Anlegedatum des Datensatzes
        /// </summary>
        public DateTime ErzeugtAm { get; set; }
        /// <summary>
        /// ID des Titelbildes
        /// </summary>
        public int? TitlePictureId { get; set; }
        #endregion

        #region Factory
        public class Factory
        {
            public static ImmobilieEntity CreateNewInstance(string newStreet, string newCity, int buildingKind, int construction, int fittingOut)
            {
                return new ImmobilieEntity()
                {
                    GebaeudeartId = buildingKind,
                    BauweiseId = construction,
                    AusbauzustandId=fittingOut,
                    Strasse = newStreet,
                    Ort = newCity
                };
            }
        }
        #endregion
    }
}

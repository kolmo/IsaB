namespace IsaB.Entities
{
    [SQLite.Table("Korrekturfaktor")]
    public class KorrekturfaktorEntity
    {
        public int GebArtId { get; set; }
        public int TypId { get; set; }
        public string Beschreibung { get; set; }
        public double Faktor { get; set; }
        /// <summary>
        /// Repräsentiert den Absziessenwert des Faktors zur Interpolation.
        /// Muss in double convertiert werden
        /// </summary>
        private string _xValString;
        [SQLite.Ignore]
        public string XValString
        {
            get
            {
                return _xValString;
            }
            set
            {
                _xValString = value;
                double xval;
                if (double.TryParse(_xValString, out xval))
                    XVal = xval;

            }
        }
        public double? XVal { get; set; }
    }
}

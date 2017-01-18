namespace IsaB.Entities
{
    [SQLite.Table("Standardstufe")]
    public class StandardstufeEntity
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int StufenId { get; set; }
        public int Stufe { get; set; }
        public string Beschreibung { get; set; }
        public int GebTeilId { get; set; }
        public int TabellenId { get; set; }
    }
}

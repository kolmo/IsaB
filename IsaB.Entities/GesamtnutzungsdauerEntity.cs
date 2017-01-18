namespace IsaB.Entities
{
    [SQLite.Table("Gesamtnutzungsdauer")]
    public class GesamtnutzungsdauerEntity
    {
        public int GebArtId { get; set; }
        public string StdStufe { get; set; }
        public int Dauer { get; set; }
    }
}

namespace IsaB.Entities
{
    [SQLite.Table("NHKosten")]
    public class NHKostenEntity
    {
        public int? BauweiseId { get; set; }
        public int? AusbZustandId { get; set; }
        public int GebArtId { get; set; }
        public int Standardstufe { get; set; }
        public double KostenProM2 { get; set; }
    }
}

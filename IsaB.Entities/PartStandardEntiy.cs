namespace IsaB.Entities
{
    [SQLite.Table("PartStandardEntity")]
    public class PartStandardEntity : Base.Entity
    {
        public int ImmoId { get; set; }
        public int TeileId { get; set; }
        public double Wert { get; set; }
    }
}

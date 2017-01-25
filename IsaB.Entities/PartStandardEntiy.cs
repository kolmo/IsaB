namespace IsaB.Entities
{
    [SQLite.Table("PartStandardEntity")]
    public class PartStandardEntity
    {
        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public int ImmoId { get; set; }
        public int TeileId { get; set; }
        public double Wert { get; set; }
    }
}

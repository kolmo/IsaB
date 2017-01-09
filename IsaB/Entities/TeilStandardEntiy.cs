namespace IsaB.Entities
{
    [SQLite.Table("TeilStandard")]
    public class TeilStandardEntity
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int ID { get; set; }
        public int ImmoId { get; set; }
        public int TeileId { get; set; }
        public double Wert { get; set; }
    }
}

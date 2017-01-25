namespace IsaB.Entities
{
    [SQLite.Table("Gebaeudeart")]
    public class GebaeudeartEntity
    {
        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
        public int StandardTableId { get; set; }
    }
}

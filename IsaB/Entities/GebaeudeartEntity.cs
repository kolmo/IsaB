namespace IsaB.Entities
{
    [SQLite.Table("Gebaeudeart")]
    public class GebaeudeartEntity
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
    }
}

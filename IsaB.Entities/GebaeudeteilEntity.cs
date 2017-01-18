namespace IsaB.Entities
{
    [SQLite.Table("Gebaeudeteil")]
    public class GebaeudeteilEntity
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
    }
}

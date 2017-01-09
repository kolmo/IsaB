namespace IsaB.Entities
{
    [SQLite.Table("Bauweise")]
    public class GebBauweiseEntity
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
    }
}

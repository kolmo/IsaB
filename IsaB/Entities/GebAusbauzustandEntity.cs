
namespace IsaB.Entities
{
    [SQLite.Table("Ausbauzustand")]
    public class GebAusbauzustandEntity
    {
        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
    }
}


using System.Xml.Serialization;
namespace IsaB.Entities
{
    [SQLite.Table("Baupreisindex")]
    public class BaupreisindexEntity
    {
        public int StdTabellenId { get; set; }
        public int Jahr { get; set; }
        public int Quartal { get; set; }
        public double Index { get; set; }
        public bool Aenderbar { get; set; }
    }
}

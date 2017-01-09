
using System.Xml.Serialization;
namespace IsaB.Entities
{
    [SQLite.Table("Baupreisindex")]
    [XmlType(TypeName = "Baupreisindex")]
    public class BaupreisindexEntity
    {
        [XmlAttribute(AttributeName = "TabellenId", DataType = "int")]
        public int TabellenId { get; set; }
        [XmlAttribute(AttributeName = "Jahr", DataType = "int")]
        public int Jahr { get; set; }
        [XmlAttribute(AttributeName = "Quartal", DataType = "int")]
        public int Quartal { get; set; }
        [XmlAttribute(AttributeName = "Index", DataType = "double")]
        public double Index { get; set; }
        public bool Aenderbar { get; set; }
    }
}

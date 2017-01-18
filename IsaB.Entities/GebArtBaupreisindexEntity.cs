using System.Xml.Serialization;

namespace IsaB.Entities
{
    [SQLite.Table("GebArtBaupreisindex")]
    [XmlType(TypeName = "GebArtBaupreisindex")]
    public class GebArtBaupreisindexEntity
    {
        [XmlAttribute(AttributeName = "GebArtId", DataType = "int")]
        public int GebArtId { get; set; }
        [XmlAttribute(AttributeName = "TabellenId", DataType = "int")]
        public int TabellenId { get; set; }
    }
}


namespace IsaB.Entities
{
    /// <summary>
    /// Zuordnung Gebaeudeart zur Standardstufentabelle
    /// </summary>
    [SQLite.Table("GebArtStandard")]
    public class GebArtStandardEntity
    {
        public int GebArtId { get; set; }
        public int StdTabellenId { get; set; }
    }
}

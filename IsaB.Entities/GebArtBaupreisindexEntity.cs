namespace IsaB.Entities
{
    [SQLite.Table("GebArtBaupreisindex")]
    public class GebArtBaupreisindexEntity
    {
        public int GebArtId { get; set; }
        public int StdTabellenId { get; set; }
    }
}

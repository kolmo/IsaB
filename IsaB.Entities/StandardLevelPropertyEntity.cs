namespace IsaB.Entities
{
    [SQLite.Table("StandardLevelProperty")]
    public class StandardLevelPropertyEntity : Base.Entity
    {
        public int Stufe { get; set; }
        public string Beschreibung { get; set; }
        public int GebTeilId { get; set; }
        public int StdTabellenId { get; set; }
    }
}

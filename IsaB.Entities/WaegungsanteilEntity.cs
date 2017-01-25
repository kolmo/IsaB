namespace IsaB.Entities
{
    [SQLite.Table("GebTeilWaegung")]
    public class WaegungsanteilEntity
    {
        public int StdTabellenId { get; set; }
        public int GebTeilId { get; set; }
        public int Waegung { get; set; }
    }
}

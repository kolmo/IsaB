namespace IsaB.Entities
{
    [SQLite.Table("GebTeilWaegung")]
    public class WaegungsanteilEntity
    {
        public int TabellenId { get; set; }
        public int GebTeilId { get; set; }
        public int Waegung { get; set; }
    }
}

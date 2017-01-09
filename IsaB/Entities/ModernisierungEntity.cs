namespace IsaB.Entities
{
    [SQLite.Table("Modernisierung")]
    public class ModernisierungEntity
    {
        public int ID { get; set; }
        public int MaxPunkte { get; set; }
        public string ModernElement { get; set; }
    }
}

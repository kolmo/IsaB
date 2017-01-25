
namespace IsaB.Entities
{
    [SQLite.Table("ImmobilieModernisierung")]
    public class ImmobilieModernisierungEntity
    {
        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public int ImmoID { get; set; }
        public int ModernId { get; set; }
        public double Punkte { get; set; }
        public string Bemerkung { get; set; }
    }
}


namespace IsaB.Entities
{
    [SQLite.Table("ImmobilieKorrFaktor")]
    public class ImmobilieKorrFaktorEntity
    {
        [SQLite.PrimaryKey]
        public int ID { get; set; }
        public int ImmoId { get; set; }
        public int FaktorTyp { get; set; }
        public double Faktor { get; set; }
        public double? Faktorkriterium { get; set; }
        public bool Anwenden { get; set; }
    }
}

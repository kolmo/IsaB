namespace IsaB.Entities
{
    [SQLite.Table("Korrekturfaktortyp")]
    public class KorrekturfaktortypEntity
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Interpolierbar { get; set; }
    }
}

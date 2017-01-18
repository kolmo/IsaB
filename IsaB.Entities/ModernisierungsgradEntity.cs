namespace IsaB.Entities
{
    [SQLite.Table("Modernisierungsgrad")]
    public class ModernisierungsgradEntity
    {
        public int Punkte { get; set; }
        public string Grad { get; set; }
        public double Koeffa { get; set; }
        public double Koeffb { get; set; }
        public double Koeffc { get; set; }
        public int AbRelAlter { get; set; }
    }
}

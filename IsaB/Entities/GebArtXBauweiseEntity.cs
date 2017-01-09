
/// <summary>
/// Assoziation der Gebaeudeart mit der Bauweise
/// </summary>
namespace IsaB.Entities
{
    [SQLite.Table("GebArtXBauweise")]
    public class GebArtXBauweiseEntity
    {
        public int GebArtId { get; set; }
        public int BauweiseId { get; set; }
    }
}

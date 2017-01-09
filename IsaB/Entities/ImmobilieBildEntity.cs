using System;

namespace IsaB.Entities
{
    [SQLite.Table("ImmobilieBild")]
    public class ImmobilieBildEntity
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public int ImmobilieId { get; set; }
        public byte[] Bilddaten { get; set; }
        public string Beschriftung { get; set; }
        public DateTime Created { get; set; }
        public DateTime? SetAsTitlePictureDate { get; set; }
    }
}

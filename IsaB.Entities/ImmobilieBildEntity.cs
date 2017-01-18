using System;

namespace IsaB.Entities
{
    [SQLite.Table("ImmobilieBild")]
    public class ImmobilieBildEntity : Entity
    {
        #region Factory
        public class Factory
        {
            public static ImmobilieBildEntity CreateNewInstance(int estateId, byte[] pictureData)
            {
                return new ImmobilieBildEntity()
                {
                    ImmobilieId = estateId,
                    Bilddaten = pictureData,
                    Created = DateTime.Now,
                    Beschriftung = "Ein Bild"
                };
            }
        }
        #endregion
        public int ImmobilieId { get; set; }
        public byte[] Bilddaten { get; set; }
        public string Beschriftung { get; set; }
        public DateTime Created { get; set; }
        public DateTime? SetAsTitlePictureDate { get; set; }
    }
}

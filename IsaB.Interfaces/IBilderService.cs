using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsaB.Interfaces.Services
{
    public interface IBilderService
    {
        #region Bilder
        ImmobilieBild LoadFirstBildByImmoId(int immoId);
        Task<IList<ImmobilieBild>> LoadBilderByImmoId(int immoId);
        ImmobilieBild LoadBildById(int bildId);
        Task SaveBild(ImmobilieBild bild);
        Task DeleteBild(ImmobilieBild bild);
        void UpdateSetAsTitlePictureDate(ImmobilieBild bild, DateTime? date);
        #endregion
    }
}

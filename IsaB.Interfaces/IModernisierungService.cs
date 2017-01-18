using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.BusinessObjects;
namespace IsaB.Interfaces.Services
{
    public interface IModernisierungService
    {
        #region Modernisierungen
        Task<IList<Modernisierung>> LoadAllModernisierungen();
        Task SaveModernisierung(ImmobilieModernisierung modernisierung);
        Task<IList<ImmobilieModernisierung>> LoadImmoModernisierungenId(int id);
        Task<IList<Modernisierungsgrad>> ListAllModernisierungsgrade();
        Task<IList<Modernisierung>> LoadModernisierungenByImmoId(int immoId);
        #endregion
    }
}

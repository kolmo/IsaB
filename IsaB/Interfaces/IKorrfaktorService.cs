using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.BusinessObjects;

namespace IsaB.Interfaces.Services
{
    public interface IKorrfaktorService
    {
        #region Korrekturfaktoren
        IList<Korrekturfaktortyp> ListAllKorrekturfaktortypen();
        IList<Korrekturfaktor> LoadKorrekturfaktorenByGebArtId(int gebArtId);
        IList<ImmobilieKorrekturfaktor> LoadKorrFaktorenByImmoId(int id);
        Task SaveKorrekturfaktor(ImmobilieKorrekturfaktor korrFak);
        #endregion
    }
}

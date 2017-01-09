using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.BusinessObjects;

namespace IsaB.Interfaces.Services
{
    public interface IImmobilienService
    {
        Task<Immobilie> LoadImmobilieById(int id);
        IList<Immobilie> ListImmobilienByGebaeudeartId(int gebaeudeartId);
        Task<IList<Immobilie>> ListImmobilienPaged(int pageNumber, int pageSize);
        int AddNewImmobilie(Immobilie immobilie);
        Task UpdateImmobilie(Immobilie immobilie);
        Task<bool> DeleteImmobilie(Immobilie immobilie);
    }
}

using IsaB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Interfaces
{
    public interface IEstateService
    {
        IQueryable<ImmobilieEntity> AllEStates { get; }
        IQueryable<ImmobilieModernisierungEntity> AllModernizations { get; }
        ImmobilieEntity GetEstate(int id);
        IList<ImmobilieBildEntity> GetEstatePics(int estateID);
        ImmobilieBildEntity GetEstatePic(int picID);
    }
}

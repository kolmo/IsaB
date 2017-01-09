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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.QueryStack
{
    public interface IStaticsService
    {
        IList<Entities.GebaeudeartEntity> BuildingKinds { get; }
    }
}

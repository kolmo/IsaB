using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.Entities;

namespace IsaB.QueryStack.Services
{
    public class StaticsService : IStaticsService
    {
        IQueryModelDatabase _dbService;
        public StaticsService(IQueryModelDatabase dbService)
        {
            _dbService = dbService;
        }
        private IList<GebaeudeartEntity> _buildingKinds = null;
        public IList<GebaeudeartEntity> BuildingKinds
        {
            get
            {
                return _buildingKinds ?? (_buildingKinds = _dbService.BuildingKinds.ToList());
            }
        }
    }
}

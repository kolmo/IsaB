using System.Collections.Generic;
using System.Linq;
using IsaB.Entities;
using SQLite;

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
        public TableQuery<GebaeudeteilEntity> BuildingParts
        {
            get
            {
                return  _dbService.BuildingParts;
            }
        }

        public TableQuery<StandardLevelPropertyEntity> StandardLevelProperties
        {
            get
            {
                return _dbService.StandardLevelProperties;
            }
        }
        private IList<GebBauweiseEntity> _constructions;
        public IList<GebBauweiseEntity> Constructions
        {
            get
            {
                return _constructions ?? (_constructions = _dbService.Constructions.ToList());
            }
        }
        private IList<GebAusbauzustandEntity> _fittingOuts;
        public IList<GebAusbauzustandEntity> FittingOuts
        {
            get
            {
                return _fittingOuts ?? (_fittingOuts=_dbService.FittingOuts.ToList());
            }
        }
    }
}

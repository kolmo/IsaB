using System;
using System.Collections.Generic;
using System.Linq;
using IsaB.Entities;
using SQLite;

namespace IsaB.QueryStack.Services
{
    public class StaticsService : IStaticsService
    {
        #region Private members
        IQueryModelDatabase _queryDb;
        private readonly Dictionary<int, IList<GebBauweiseEntity>> _constructionsByBuildingKind;
        private readonly Dictionary<int, IList<GebAusbauzustandEntity>> _fittingOutsByBuildingKind;
        #endregion

        #region Constructor
        public StaticsService(IQueryModelDatabase queryDb)
        {
            _queryDb = queryDb;
            _constructionsByBuildingKind = new Dictionary<int, IList<GebBauweiseEntity>>();
            _fittingOutsByBuildingKind = new Dictionary<int, IList<GebAusbauzustandEntity>>();
        }
        #endregion

        #region Interface member implementation
        private IList<GebaeudeartEntity> _buildingKinds = null;
        public IList<GebaeudeartEntity> BuildingKinds
        {
            get { return _buildingKinds ?? (_buildingKinds = _queryDb.BuildingKinds.ToList()); }
        }
        public TableQuery<GebaeudeteilEntity> BuildingParts
        {
            get { return _queryDb.BuildingParts; }
        }
        private IList<StandardTableEntity> _standardTables = null;
        public IList<StandardTableEntity> StandardTables
        {
            get { return _standardTables ?? (_standardTables = _queryDb.StandardTables.ToList()); }
        }
        public TableQuery<StandardLevelPropertyEntity> StandardLevelProperties
        {
            get { return _queryDb.StandardLevelProperties; }
        }
        private IList<GebBauweiseEntity> _constructions;
        public IList<GebBauweiseEntity> Constructions
        {
            get { return _constructions ?? (_constructions = _queryDb.Constructions.ToList()); }
        }
        private IList<GebAusbauzustandEntity> _fittingOuts;
        public IList<GebAusbauzustandEntity> FittingOuts
        {
            get { return _fittingOuts ?? (_fittingOuts = _queryDb.FittingOuts.ToList()); }
        }
        private IList<ModernisierungEntity> _modernizations;
        public IList<ModernisierungEntity> Modernizations
        {
            get { return _modernizations ?? (_modernizations = _queryDb.Modernizations.ToList()); }
        }
        public IList<GebBauweiseEntity> ConstructionsByBuildingKind(int buildingKindId)
        {
            if (!_constructionsByBuildingKind.ContainsKey(buildingKindId))
            {
                var cons = _queryDb.Constructions.ToList();
                var matching = _queryDb.BuildingKindXConstruction.ToList();
                var query = from c in cons
                            join bkxc in matching on c.ID equals bkxc.BauweiseId
                            where bkxc.GebArtId == buildingKindId
                            select c;
                _constructionsByBuildingKind[buildingKindId] = query.ToList();
            }
            return _constructionsByBuildingKind[buildingKindId];
        }
        public IList<GebAusbauzustandEntity> FittingOutsByBuildingKind(int buildingKindId)
        {
            if (!_fittingOutsByBuildingKind.ContainsKey(buildingKindId))
            {
                var fittingOuts = _queryDb.FittingOuts.ToList();
                var matching = _queryDb.FittingOutXConstruction.ToList();
                var query = from c in fittingOuts
                            join bkxfo in matching on c.ID equals bkxfo.ZustandId
                            where bkxfo.GebArtId == buildingKindId
                            select c;
                _fittingOutsByBuildingKind[buildingKindId] = query.ToList();
            }
            return _fittingOutsByBuildingKind[buildingKindId];
        }
        #endregion
    }
}

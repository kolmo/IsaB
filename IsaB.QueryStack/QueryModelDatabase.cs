using System;
using IsaB.Entities;
using SQLite;
using IsaB.Infrastructure;

namespace IsaB.QueryStack
{
    public class QueryModelDatabase : IQueryModelDatabase
    {
        IDatabaseService _dataService;
        private SQLiteConnection _context;
        public QueryModelDatabase(IDatabaseService dataService)
        {
            _dataService = dataService;
            _context = new SQLiteConnection(_dataService.ConnectionString);
            _estates = _context.Table<ImmobilieEntity>();
            _buildingKinds = _context.Table<GebaeudeartEntity>();
            _constructions = _context.Table<GebBauweiseEntity>();
            _fittingOuts = _context.Table<GebAusbauzustandEntity>();
            _modernizations = _context.Table<ModernisierungEntity>();
            _estateModernizations = _context.Table<ImmobilieModernisierungEntity>();
            _pictures = _context.Table<ImmobilieBildEntity>();
            _buildingParts = _context.Table<GebaeudeteilEntity>();
            _partStandards = _context.Table<PartStandardEntity>();
            _standardLevelProperties = _context.Table<StandardLevelPropertyEntity>();
            _estateStandardLevelPropertyEntities = _context.Table<EstateStandardLevelPropertyEntity>();
            _buildingKindXConstruction = _context.Table<GebArtXBauweiseEntity>();
            _fittingOutXConstruction = _context.Table<GebArtXAusbauEntity>();
            _standardTables = _context.Table<StandardTableEntity>();
        }
        private readonly TableQuery<StandardTableEntity> _standardTables = null;
        private readonly TableQuery<GebBauweiseEntity> _constructions = null;
        private readonly TableQuery<GebAusbauzustandEntity> _fittingOuts = null;
        private readonly TableQuery<GebArtXBauweiseEntity> _buildingKindXConstruction = null;
        private readonly TableQuery<GebArtXAusbauEntity> _fittingOutXConstruction = null;
        private readonly TableQuery<ModernisierungEntity> _modernizations = null;
        private readonly TableQuery<ImmobilieEntity> _estates = null;
        private readonly TableQuery<GebaeudeartEntity> _buildingKinds = null;
        private readonly TableQuery<ImmobilieModernisierungEntity> _estateModernizations = null;
        private readonly TableQuery<ImmobilieBildEntity> _pictures = null;
        private readonly TableQuery<GebaeudeteilEntity> _buildingParts = null;
        private readonly TableQuery<PartStandardEntity> _partStandards = null;
        private readonly TableQuery<StandardLevelPropertyEntity> _standardLevelProperties = null;
        private readonly TableQuery<EstateStandardLevelPropertyEntity> _estateStandardLevelPropertyEntities = null;
        public TableQuery<ImmobilieEntity> Estates
        {
            get { return this._estates; }
        }

        public TableQuery<GebaeudeartEntity> BuildingKinds
        {
            get { return _buildingKinds; }
        }

        public TableQuery<ImmobilieModernisierungEntity> EstateModernizations
        {
            get { return _estateModernizations; }
        }

        public TableQuery<ImmobilieBildEntity> Pictures
        {
            get { return _pictures; }
        }

        public TableQuery<PartStandardEntity> PartStandards
        {
            get { return _partStandards; }
        }

        public TableQuery<GebaeudeteilEntity> BuildingParts
        {
            get { return _buildingParts; }
        }

        public TableQuery<StandardLevelPropertyEntity> StandardLevelProperties
        {
            get { return _standardLevelProperties; }
        }

        public TableQuery<EstateStandardLevelPropertyEntity> EstateStandardLevelProperties
        {
            get { return _estateStandardLevelPropertyEntities; }
        }

        public TableQuery<GebBauweiseEntity> Constructions
        {
            get { return _constructions; }
        }

        public TableQuery<GebAusbauzustandEntity> FittingOuts
        {
            get { return _fittingOuts; }
        }

        public TableQuery<GebArtXBauweiseEntity> BuildingKindXConstruction
        {
            get { return _buildingKindXConstruction; }
        }

        public TableQuery<GebArtXAusbauEntity> FittingOutXConstruction
        {
            get { return _fittingOutXConstruction; }
        }

        public TableQuery<ModernisierungEntity> Modernizations
        {
            get { return _modernizations; }
        }

        public TableQuery<StandardTableEntity> StandardTables
        {
            get { return _standardTables; }
        }
    }
}

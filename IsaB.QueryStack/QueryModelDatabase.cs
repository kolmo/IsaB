using System;
using IsaB.Entities;
using SQLite;

namespace IsaB.QueryStack
{
    public class QueryModelDatabase : IQueryModelDatabase
    {
        IDatabaseService _dataService;
        private SQLiteConnection _context;
        public QueryModelDatabase(IDatabaseService dataService)
        {
            _dataService = dataService;
            _context = new SQLiteConnection(_dataService.DatabasePath);
            _estates = _context.Table<ImmobilieEntity>();
            _buildingKinds = _context.Table<GebaeudeartEntity>();
            _modernizations = _context.Table<ImmobilieModernisierungEntity>();
            _pictures = _context.Table<ImmobilieBildEntity>();
            _buildingParts = _context.Table<GebaeudeteilEntity>();
            _partStandards = _context.Table<PartStandardEntity>();
            _standardLevelProperties = _context.Table<StandardLevelPropertyEntity>();
            _estateStandardLevelPropertyEntities = _context.Table<EstateStandardLevelPropertyEntity>();
        }
        private readonly TableQuery<ImmobilieEntity> _estates = null;
        private readonly TableQuery<GebaeudeartEntity> _buildingKinds = null;
        private readonly TableQuery<ImmobilieModernisierungEntity> _modernizations = null;
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
            get
            {
                return _buildingKinds;
            }
        }

        public TableQuery<ImmobilieModernisierungEntity> Modernizations
        {
            get
            {
                return _modernizations;
            }
        }

        public TableQuery<ImmobilieBildEntity> Pictures
        {
            get
            {
                return _pictures;
            }
        }

        public TableQuery<PartStandardEntity> PartStandards
        {
            get
            {
                return _partStandards;
            }
        }

        public TableQuery<GebaeudeteilEntity> BuildingParts
        {
            get
            {
                return _buildingParts;
            }
        }

        public TableQuery<StandardLevelPropertyEntity> StandardLevelProperties
        {
            get
            {
                return _standardLevelProperties;
            }
        }

        public TableQuery<EstateStandardLevelPropertyEntity> EstateStandardLevelProperties
        {
            get
            {
                return _estateStandardLevelPropertyEntities;
            }
        }
    }
}

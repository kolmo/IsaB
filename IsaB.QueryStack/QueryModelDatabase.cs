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
        }
        private readonly TableQuery<ImmobilieEntity> _estates = null;
        private readonly TableQuery<GebaeudeartEntity> _buildingKinds = null;
        private readonly TableQuery<ImmobilieModernisierungEntity> _modernizations = null;
        private readonly TableQuery<ImmobilieBildEntity> _pictures = null;
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
    }
}

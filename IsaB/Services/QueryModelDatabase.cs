using IsaB.Entities;
using IsaB.Interfaces.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class QueryModelDatabase : IQueryModelDatabase
    {
        ISeedLoaderService _dataService;
        private SQLiteConnection _context;
        public QueryModelDatabase(ISeedLoaderService dataService)
        {
            _dataService = dataService;
            _context = new SQLiteConnection(_dataService.DatabasePath);
            _estates = _context.Table<ImmobilieEntity>();
        }
        private readonly TableQuery<ImmobilieEntity> _estates = null;
        public TableQuery<ImmobilieEntity> Estates
        {
            get { return this._estates; }
        }

    }
}

using IsaB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.Entities;
using SQLite;
using IsaB.Interfaces.Services;

namespace IsaB.Services
{
    public class EstateService : IEstateService
    {
        IQueryModelDatabase _dbService;
        public EstateService(IQueryModelDatabase dbService)
        {
            _dbService = dbService;
        }

        public IQueryable<ImmobilieEntity> AllEStates
        {
            get
            {
                return _dbService.Estates.AsQueryable();
            }
        }
    }
}

using IsaB.Interfaces;
using System.Linq;
using IsaB.Entities;
using System;
using System.Collections.Generic;

namespace IsaB.QueryStack.Services
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

        public IQueryable<ImmobilieModernisierungEntity> AllModernizations
        {
            get
            {
                return _dbService.Modernizations.AsQueryable();
            }
        }

        public ImmobilieEntity GetEstate(int id)
        {
            return _dbService.Estates.FirstOrDefault(x => x.ID == id);
        }

        public ImmobilieBildEntity GetEstatePic(int picID)
        {
            return _dbService.Pictures.FirstOrDefault(x => x.ID == picID);
        }

        public IList<ImmobilieBildEntity> GetEstatePics(int estateID)
        {
            return _dbService.Pictures.Where(x => x.ImmobilieId == estateID).ToList();
        }
    }
}

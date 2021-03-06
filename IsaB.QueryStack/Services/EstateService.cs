﻿using System.Linq;
using IsaB.Entities;
using System.Collections.Generic;
using System;

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

        public IQueryable<ImmobilieModernisierungEntity> EstateModernizations
        {
            get
            {
                return _dbService.EstateModernizations.AsQueryable();
            }
        }

        public IQueryable<EstateStandardLevelPropertyEntity> EstateStandardLevelPropertyEntities
        {
            get
            {
                return _dbService.EstateStandardLevelProperties.AsQueryable();
            }
        }

        public IQueryable<PartStandardEntity> PartStandards
        {
            get
            {
                return _dbService.PartStandards.AsQueryable();
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

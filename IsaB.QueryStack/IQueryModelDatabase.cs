﻿using IsaB.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.QueryStack
{
    public interface IQueryModelDatabase
    {
        TableQuery<ImmobilieEntity> Estates { get; }
        TableQuery<GebaeudeartEntity> BuildingKinds { get; }
        TableQuery<ImmobilieModernisierungEntity> Modernizations { get; }
        TableQuery<ImmobilieBildEntity> Pictures { get; }
        TableQuery<PartStandardEntity> PartStandards { get; }
        TableQuery<GebaeudeteilEntity> BuildingParts { get; }
        TableQuery<StandardLevelPropertyEntity> StandardLevelProperties { get; }
        TableQuery<EstateStandardLevelPropertyEntity> EstateStandardLevelProperties { get; }
    }
}

using IsaB.Entities;
using SQLite;
using System.Collections.Generic;

namespace IsaB.QueryStack
{
    public interface IStaticsService
    {
        IList<GebaeudeartEntity> BuildingKinds { get; }
        TableQuery<GebaeudeteilEntity> BuildingParts { get; }
        TableQuery<StandardLevelPropertyEntity> StandardLevelProperties { get; }
    }
}

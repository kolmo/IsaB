using IsaB.Entities;
using SQLite;
using System.Collections.Generic;

namespace IsaB.QueryStack
{
    public interface IStaticsService
    {
        IList<GebaeudeartEntity> BuildingKinds { get; }
        IList<GebBauweiseEntity> Constructions { get; }
        IList<GebAusbauzustandEntity> FittingOuts { get; }
        TableQuery<GebaeudeteilEntity> BuildingParts { get; }
        TableQuery<StandardLevelPropertyEntity> StandardLevelProperties { get; }
    }
}

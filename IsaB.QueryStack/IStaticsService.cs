using IsaB.Entities;
using SQLite;
using System.Collections.Generic;

namespace IsaB.QueryStack
{
    public interface IStaticsService
    {
        IList<StandardTableEntity> StandardTables { get; }
        IList<GebaeudeartEntity> BuildingKinds { get; }
        IList<GebBauweiseEntity> Constructions { get; }
        IList<GebAusbauzustandEntity> FittingOuts { get; }
        IList<ModernisierungEntity> Modernizations { get; }
        IList<GebBauweiseEntity> ConstructionsByBuildingKind(int buildingKindId);
        IList<GebAusbauzustandEntity> FittingOutsByBuildingKind(int buildingKindId);
        TableQuery<GebaeudeteilEntity> BuildingParts { get; }
        TableQuery<StandardLevelPropertyEntity> StandardLevelProperties { get; }
    }
}

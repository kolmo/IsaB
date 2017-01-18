using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsaB.BusinessObjects;

namespace IsaB.Interfaces.Services
{
    public interface IGebaeudeartService
    {
        IList<Gebaeudeart> ListAllGebaeudearten();
        IList<Bauweise> ListAllBauweisen();
        IList<Ausbauzustand> ListAllAusbauzustaende();
        IList<Baupreisindex> ListBaupreisindizes();
        IList<Gesamtnutzungsdauer> ListGesamtnutzungsdauer();
        IList<Normalherstellungskosten> LoadNHKostenByGebArtId(int gebArtId);
        IList<Bauweise> LoadBauweisenByGebArtID(int gebartId);
        IList<Ausbauzustand> LoadAusbauByGebArtID(int gebartId);
        IList<Gebaeudeteil> ListAllGebaeudeteile();
        IList<Gebaeudeteil> ListGebaeudeteileByGebArtId(int gebArtId);
        #region Teilestandard
        Task SaveTeilStandard(ImmobilieTeilStandard teilStandard);
        IList<ImmobilieTeilStandard> LoadTeilStandardsByImmoId(int id);
        Task<ImmobilieTeilStandard> LoadTeilStandardByImmoIdAndTeil(int id, int teileId);
        IList<Gebaeudestandardstufe> ListStandardstufenByGebArtId(int id);
        IList<Gebaeudestandardstufe> ListStandardstufenByTeilIdAndGebArtId(int teilId, int gebArtId);
        IList<Waegungsanteil> ListWaegungsanteileByGebArtId(int gebArtId);
        #endregion
   }
}

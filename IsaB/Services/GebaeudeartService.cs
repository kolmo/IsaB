using IsaB.BusinessObjects;
using IsaB.Interfaces.Services;
using IsaB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class GebaeudeartService : ServiceBase, IGebaeudeartService
    {
        #region Construction
        public GebaeudeartService(IDatabaseService dbService)
            : base(dbService.DatabasePath)
        { }
        #endregion
        public IList<Gesamtnutzungsdauer> ListGesamtnutzungsdauer()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var result = db.Table<GesamtnutzungsdauerEntity>();
            return result.Convert();
        }
        public IList<Baupreisindex> ListBaupreisindizes()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var result = db.Table<BaupreisindexEntity>();
            return result.Convert();
        }
        public IList<Gebaeudeteil> ListAllGebaeudeteile()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var result = db.Table<GebaeudeteilEntity>();
            return result.Convert();
        }

        public IList<Gebaeudeart> ListAllGebaeudearten()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            IList<GebaeudeartEntity> artList = db.Table<GebaeudeartEntity>().ToList();
            return artList.Convert();
        }
        public IList<Ausbauzustand> ListAllAusbauzustaende()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            IList<GebAusbauzustandEntity> artList = db.Table<GebAusbauzustandEntity>().ToList();
            return artList.Convert();
        }
        public IList<Bauweise> ListAllBauweisen()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            IList<GebBauweiseEntity> artList = db.Table<GebBauweiseEntity>().ToList();
            return artList.Convert();
        }
        public IList<Normalherstellungskosten> LoadNHKostenByGebArtId(int gebArtId)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            return db.Table<NHKostenEntity>().Where(x => x.GebArtId == gebArtId).ToList().Convert();
        }
        /// <summary>
        /// Lädt alle zu einer Gebäudeart zugeordneten Bauweisen
        /// </summary>
        /// <param name="gebartId"></param>
        /// <returns></returns>
        public IList<Bauweise> LoadBauweisenByGebArtID(int gebartId)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var matching = db.Table<GebArtXBauweiseEntity>().Where(x => x.GebArtId == gebartId).ToList();
            if (matching != null && matching.Any())
            {
                var bauweiseList = db.Table<GebBauweiseEntity>().ToList();
                return bauweiseList.Where(x => matching.Any(y => y.BauweiseId == x.ID)).ToList().Convert();
            }
            else
                return null;
        }
        /// <summary>
        /// Lädt alle zu einer Gebäudeart zugeordneten Ausbauzustände
        /// </summary>
        /// <param name="gebartId"></param>
        /// <returns></returns>
        public IList<Ausbauzustand> LoadAusbauByGebArtID(int gebartId)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var matching = db.Table<GebArtXAusbauEntity>().Where(x => x.GebArtId == gebartId).ToList();
            if (matching != null && matching.Any())
            {
                var ausbauList = db.Table<GebAusbauzustandEntity>().ToList();
                return ausbauList.Where(x => matching.Any(y => y.ZustandId == x.ID)).ToList().Convert();
            }
            else
                return new List<Ausbauzustand>();
        }
      
        public IList<ImmobilieTeilStandard> LoadTeilStandardsByImmoId(int id)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var list = db.Table<TeilStandardEntity>().Where(x => x.ImmoId == id).ToList();
            return list.Convert();
        }
        public async Task<ImmobilieTeilStandard> LoadTeilStandardByImmoIdAndTeil(int id, int teileId)
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var result = await db.Table<TeilStandardEntity>().Where(x => x.ImmoId == id && x.TeileId == teileId).FirstOrDefaultAsync();
            return result.Convert();
        }
        public async Task SaveTeilStandard(ImmobilieTeilStandard teilStandard)
        {
            var entity = teilStandard.Convert();
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            int rowsAffected = await db.UpdateAsync(entity);
            if (rowsAffected != 1)
            {
                await db.InsertAsync(entity);
            }
        }
        public IList<Gebaeudestandardstufe> ListStandardstufenByGebArtId(int gebArtId)
        {
            IList<Gebaeudestandardstufe> result = null;
            var db = new SQLite.SQLiteConnection(DbPath);
            var mapping = db.Table<GebArtStandardEntity>().Where(x => x.GebArtId == gebArtId).SingleOrDefault();
            if (mapping != null)
            {
                var list = db.Table<StandardstufeEntity>().Where(x => x.TabellenId == mapping.StdTabellenId);
                result = list.Convert();
            }
            return result;
        }
        public IList<Gebaeudeteil> ListGebaeudeteileByGebArtId(int gebArtId)
        {
            IList<Gebaeudeteil> result = null;
            var db = new SQLite.SQLiteConnection(DbPath);
            var mapping = db.Table<GebArtStandardEntity>().Where(x => x.GebArtId == gebArtId).SingleOrDefault();
            if (mapping != null)
            {
                var glist = db.Table<GebaeudeteilEntity>().ToList();
                var list = db.Table<StandardstufeEntity>().Where(x => x.TabellenId == mapping.StdTabellenId).GroupBy(x => x.GebTeilId).ToList(); ;
                var entityList = glist.Where(x => list.Any(xx => xx.Key == x.ID)).ToList();
                result = entityList.Convert();
            }
            return result;

        }
        public IList<Gebaeudestandardstufe> ListStandardstufenByTeilIdAndGebArtId(int teilId, int gebArtId)
        {
            IList<Gebaeudestandardstufe> result = null;
            var db = new SQLite.SQLiteConnection(DbPath);
            var mapping = db.Table<GebArtStandardEntity>().Where(x => x.GebArtId == gebArtId).SingleOrDefault();
            if (mapping != null)
            {
                var list = db.Table<StandardstufeEntity>().Where(x =>
                     x.TabellenId == mapping.StdTabellenId && x.GebTeilId == teilId);
                result = list.Convert();
            }
            return result;
        }
        public IList<Waegungsanteil> ListWaegungsanteileByGebArtId(int gebArtId)
        {
            IList<Waegungsanteil> result = null;
            var db = new SQLite.SQLiteConnection(DbPath);
            var mapping = db.Table<GebArtStandardEntity>().Where(x => x.GebArtId == gebArtId).SingleOrDefault();
            if (mapping != null)
            {
                var list = db.Table<WaegungsanteilEntity>().Where(x => x.TabellenId == mapping.StdTabellenId);
                result = list.Convert();
            }
            return result;
        }
    }
}

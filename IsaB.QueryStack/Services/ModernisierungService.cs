using IsaB.Interfaces.Services;
using IsaB.Entities;
using IsaB.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class ModernisierungService : ServiceBase, IModernisierungService
    {
        #region Construction
        public ModernisierungService(IDatabaseService dbService)
            : base(dbService.DatabasePath)
        { }
        #endregion
        public async Task<IList<ImmobilieModernisierung>> LoadImmoModernisierungenId(int id)
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var list = await db.Table<ImmobilieModernisierungEntity>().Where(x => x.ImmoID == id).ToListAsync();
            return list.Convert();
        }

        public async Task SaveModernisierung(ImmobilieModernisierung modernisierung)
        {
            var entity = modernisierung.Convert();
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            int rowsAffected = await db.UpdateAsync(entity);
            if (rowsAffected != 1)
            {
                await db.InsertAsync(entity);
            }
        }
        /// <summary>
        /// Akutalisiert die Modernisierungsinfos
        /// Allerdings sollte hier ein Transaktion verwendet werden, die es jedoch nur synchron gibt!
        /// </summary>
        /// <param name="immoId"></param>
        /// <param name="immoXModern"></param>
        /// <returns></returns>
        public async Task UpdadeImmoModernisierung(int immoId, IEnumerable<ImmobilieModernisierung> immoXModern)
        {
            if (immoXModern == null)
                return;
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            // Lade zuerst den Datenbestand
            var dbContent = await LoadImmoModernisierungenId(immoId);
            foreach (ImmobilieModernisierung item in dbContent)
            {
                if (!immoXModern.Any(x => x.ModernId == item.ModernId))
                {
                    await db.DeleteAsync(item);
                }
            }
            foreach (ImmobilieModernisierung item in immoXModern)
            {
                var entity = item.Convert();
                int rowsAffected = await db.UpdateAsync(entity);
                if (rowsAffected != 1)
                {
                    await db.InsertAsync(entity);
                }
            }
        }
        public async Task<IList<Modernisierung>> LoadAllModernisierungen()
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var modernList = await db.Table<ModernisierungEntity>().ToListAsync();
            var resultList = modernList.Convert();
            return resultList;
        }
        public async Task<IList<Modernisierungsgrad>> ListAllModernisierungsgrade()
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var result = await db.Table<ModernisierungsgradEntity>().ToListAsync();
            return result.Convert();
        }
        public async Task<IList<Modernisierung>> LoadModernisierungenByImmoId(int immoId)
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var list = await db.Table<ImmobilieModernisierungEntity>().Where(x => x.ImmoID == immoId && x.Punkte > 0).ToListAsync();
            var modernList = await db.Table<ModernisierungEntity>().ToListAsync();
            var resultList = modernList.Where(x => list.Any(xx => xx.ModernId == x.ID)).Convert();
            return resultList;
        }
    }
}

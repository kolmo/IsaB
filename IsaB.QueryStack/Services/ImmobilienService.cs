using IsaB.Entities;
using IsaB.BusinessObjects;
using IsaB.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class ImmobilienService : ServiceBase, IImmobilienService
    {
        #region Construction
        public ImmobilienService(IDatabaseService dbService)
            : base(dbService.DatabasePath)
        { }
        #endregion
        public IList<Immobilie> ListImmobilienByGebaeudeartId(int gebaeudeartId)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var entityList = db.Table<ImmobilieEntity>().Where(x => x.GebaeudeartId == gebaeudeartId).ToList();
            return entityList.Convert();
        }
        public async Task<Immobilie> LoadImmobilieById(int id)
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var entity = await db.Table<ImmobilieEntity>().Where(x => x.ID == id).FirstAsync();
            var immobilie = entity.Convert();
            immobilie.Bilderanzahl = await db.Table<ImmobilieBildEntity>().Where(x => x.ImmobilieId == immobilie.ID).CountAsync();
            return immobilie;
        }
        public async Task UpdateImmobilie(Immobilie immobilie)
        {
            var entity = immobilie.Convert();
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            int rowsAfftected = await db.UpdateAsync(entity);
            return;
        }
        public int AddNewImmobilie(Immobilie immobilie)
        {
            if (immobilie == null)
                throw new ArgumentNullException("immobilie");
            var entity = immobilie.Convert();
            var db = new SQLite.SQLiteConnection(DbPath);
            int count = db.Insert(entity);
            immobilie.ID = entity.ID;
            return count;
        }
        /// <summary>
        /// Löscht eine Immobilie und alle verknüpften Daten
        /// </summary>
        /// <param name="immobilie"></param>
        /// <returns></returns>
        public async Task<bool> DeleteImmobilie(Immobilie immobilie)
        {
            Func<object, bool> func = (arg) =>
            {
                bool ok = false;
                Immobilie immo = arg as Immobilie;
                if (immo == null)
                    return ok;
                ImmobilieEntity entity = immo.Convert();
                var db = new SQLite.SQLiteConnection(DbPath);
                try
                {
                    db.BeginTransaction();
                    var bilder = db.Table<ImmobilieBildEntity>().Where(x => x.ImmobilieId == entity.ID).ToList();
                    foreach (var bild in bilder)
                        db.Delete(bild);
                    var standards = db.Table<TeilStandardEntity>().Where(x => x.ImmoId == entity.ID).ToList();
                    foreach (var std in standards)
                        db.Delete(std);
                    var modern = db.Table<ImmobilieModernisierungEntity>().Where(x => x.ImmoID == entity.ID).ToList();
                    foreach (var md in modern)
                        db.Delete(md);
                    db.Delete(entity);
                    db.Commit();
                    ok = true;
                }
                catch (Exception)
                {
                    db.Rollback();
                    ok = false;
                }
                return ok;
            };
            bool result = await Task<bool>.Factory.StartNew(func, immobilie);
            return result;
        }
        public async Task<IList<Immobilie>> ListImmobilienPaged(int pageNumber, int pageSize)
        {
            pageSize = Math.Max(0, pageSize);
            pageNumber = Math.Max(1, pageNumber);
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var entityList = await db.Table<ImmobilieEntity>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return entityList.Convert();
        }
    }
}

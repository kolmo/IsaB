using IsaB.Entities;
using System;
using System.Linq;
using SQLiteWrapper = SQLite;

namespace IsaB.Infrastructure.SQLite
{
    public class SQLiteRepository : IRepository
    {
        private readonly string _dbPath;
        public SQLiteRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        #region Interface methods
        public T GetById<T>(int id) where T : Base.Entity, new()
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                return db.Table<T>().Where(x => x.ID == id).First();
            }
        }
        public void Save<T>(T item) where T : Base.Entity, new()
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                if (db.Table<T>().Any(x => x.ID == item.ID))
                    db.Update(item);
                else
                {
                    db.Insert(item);
                }
            }
        }
        public void Delete<T>(T item) where T : Base.Entity, new()
        {
            if (typeof(T) == typeof(ImmobilieBildEntity) ||
                typeof(T) == typeof(ImmobilieEntity))
            {
                Delete((dynamic)item);
            }
            else
            {
                using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
                {
                    db.Delete(item);
                }
            }
        }

        #endregion

        #region Private methods
        private void Delete(ImmobilieBildEntity item)
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                try
                {
                    db.BeginTransaction();
                    var estateWithPicAsTitle = db.Table<ImmobilieEntity>().FirstOrDefault(x => x.TitlePictureId == item.ID);
                    if (estateWithPicAsTitle != null)
                    {
                        estateWithPicAsTitle.TitlePictureId = null;
                        db.Update(estateWithPicAsTitle);
                    }
                    db.Delete(item);
                    db.Commit();
                }
                catch (Exception)
                {
                    db.Rollback();
                }
            }
        }
        private void Delete(ImmobilieEntity estate)
        {

            using (var db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                try
                {
                    db.BeginTransaction();
                    var bilder = db.Table<ImmobilieBildEntity>().Where(x => x.ImmobilieId == estate.ID).ToList();
                    foreach (var bild in bilder)
                        db.Delete(bild);
                    var standards = db.Table<PartStandardEntity>().Where(x => x.ImmoId == estate.ID).ToList();
                    foreach (var std in standards)
                        db.Delete(std);
                    var esxl = db.Table<EstateStandardLevelPropertyEntity>().Where(x => x.EstateId == estate.ID).ToList();
                    foreach (var item in esxl)
                    {
                        db.Delete(item);
                    }
                    var modern = db.Table<ImmobilieModernisierungEntity>().Where(x => x.ImmoID == estate.ID).ToList();
                    foreach (var md in modern)
                        db.Delete(md);
                    db.Delete(estate);
                    db.Commit();
                }
                catch (Exception)
                {
                    db.Rollback();
                }
            }
        }
        #endregion

    }
}

using IsaB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEntity GetEstateById(int id)
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                return db.Table<ImmobilieEntity>().FirstOrDefault(x => x.ID == id);
            }
        }
        public IEntity GetPictureById(int pictureID)
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                return db.Table<ImmobilieBildEntity>().FirstOrDefault(x => x.ID == pictureID);
            }
        }
        public T GetById<T>(int id) where T : IEntity
        {
            if (typeof(T) == typeof(ImmobilieEntity))
            {
                return (T) GetEstateById(id);
            }
            else if (typeof(T) == typeof(ImmobilieBildEntity))
            {
                return (T)GetPictureById(id);
            }
            else
            {
                return default(T);
            }
        }
        public void Save<T>(T item) where T : IEntity
        {
            Save((dynamic)item);
        }
        public void Delete<T>(T item) where T : IEntity
        {
            Delete((dynamic)item);
        }
        #region Private methods
        private void Save(ImmobilieEntity item)
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                if (db.Table<ImmobilieEntity>().Any(x => x.ID == item.ID))
                    db.Update(item);
                else
                    db.Insert(item);
            }
        }
        private void Save(ImmobilieBildEntity item)
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                if (db.Table<ImmobilieBildEntity>().Any(x => x.ID == item.ID))
                    db.Update(item);
                else
                    db.Insert(item);
            }
        }
        private void Delete(ImmobilieBildEntity picture)
        {
            using (SQLiteWrapper.SQLiteConnection db = new SQLiteWrapper.SQLiteConnection(_dbPath))
            {
                db.Delete(picture);
            }
        }
        #endregion

    }
}

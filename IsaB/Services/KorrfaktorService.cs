using IsaB.Interfaces.Services;
using IsaB.BusinessObjects;
using IsaB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class KorrfaktorService : ServiceBase, IKorrfaktorService
    {
        #region Construction
        public KorrfaktorService(IDatabaseService dbService)
            : base(dbService.DatabasePath)
        { }
        #endregion
        public IList<Korrekturfaktor> LoadKorrekturfaktorenByGebArtId(int gebArtId)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var korrFaktoren = db.Table<KorrekturfaktorEntity>().Where(x => x.GebArtId == gebArtId).ToList();
            var resultList = korrFaktoren.Convert();
            return resultList;
        }
        public IList<ImmobilieKorrekturfaktor> LoadKorrFaktorenByImmoId(int id)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var list = db.Table<ImmobilieKorrFaktorEntity>().Where(x => x.ImmoId == id).ToList();
            return list.Convert();
        }
        public async Task SaveKorrekturfaktor(ImmobilieKorrekturfaktor korrFak)
        {
            var entity = korrFak.Convert();
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            int rowsAffected = await db.UpdateAsync(entity);
            if (rowsAffected != 1)
            {
                await db.InsertAsync(entity);
            }
        }

        public IList<Korrekturfaktortyp> ListAllKorrekturfaktortypen()
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var korrFakTypen = db.Table<KorrekturfaktortypEntity>().ToList();
            return korrFakTypen.Convert();
        }
    }
}

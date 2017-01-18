using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsaB.Services
{
    public class BilderService : ServiceBase, IBilderService
    {
        #region Construction
        public BilderService(IDatabaseService dbService) : base(dbService.DatabasePath) { }
        #endregion
        public ImmobilieBild LoadFirstBildByImmoId(int immoId)
        {
            ImmobilieBild result = null;
            var db = new SQLite.SQLiteConnection(DbPath);
            ImmobilieBildEntity bild = db.Table<ImmobilieBildEntity>()
                .Where(x => x.ImmobilieId == immoId && x.SetAsTitlePictureDate != null)
                .OrderByDescending(x => x.SetAsTitlePictureDate)
                .FirstOrDefault();
            if (bild != null)
            {
                result = bild.Convert();
            }
            return result;
        }

        public async Task<IList<ImmobilieBild>> LoadBilderByImmoId(int immoId)
        {
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            var blist = await db.Table<ImmobilieBildEntity>().Where(x => x.ImmobilieId == immoId).ToListAsync();
            var resultList = blist.Convert();
            var titlePic = resultList.Where(x => x.SetAsTitlePictureDate.HasValue).OrderByDescending(x => x.SetAsTitlePictureDate).FirstOrDefault();
            if (titlePic != null)
                titlePic.IsTitlePic = true;
            return resultList;
        }

        public ImmobilieBild LoadBildById(int bildId)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var bild = db.Table<ImmobilieBildEntity>().First(x => x.Id == bildId);
            var titlePic = db.Table<ImmobilieBildEntity>().Where(x => x.SetAsTitlePictureDate != null).OrderByDescending(x => x.SetAsTitlePictureDate).FirstOrDefault();
            ImmobilieBild result = bild.Convert();
            result.IsTitlePic = titlePic != null && titlePic.Id == result.Id;
            return result;
        }
        public async Task SaveBild(ImmobilieBild bild)
        {
            var entity = bild.Convert();
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            int rowsAffected = await db.UpdateAsync(entity);
            if (rowsAffected != 1)
            {
                entity.Created = DateTime.Now;
                await db.InsertAsync(entity);
                bild.Id = entity.Id;
                bild.Created = entity.Created;
            }
        }
        public async Task DeleteBild(ImmobilieBild bild)
        {
            var entity = bild.Convert();
            var db = new SQLite.SQLiteAsyncConnection(DbPath);
            await db.DeleteAsync(entity);
        }
        public void UpdateSetAsTitlePictureDate(ImmobilieBild bild, DateTime? date)
        {
            var db = new SQLite.SQLiteConnection(DbPath);
            var bildEntity = db.Table<ImmobilieBildEntity>().FirstOrDefault(x => x.Id == bild.Id);
            if (bildEntity != null)
            {
                bildEntity.SetAsTitlePictureDate = date;
                db.Update(bildEntity);
            }
        }    
    }
}

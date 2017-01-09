using IsaB.Entities;
using IsaB.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace IsaB.Services
{
    public class DatabaseService : IDatabaseService
    {
        ISeedLoaderService _dataService;
        public DatabaseService(ISeedLoaderService dataService)
        {
            _dataService = dataService;
        }
        #region Props
        public string DatabasePath
        {
            get { return _dataService.DatabasePath; }
        }
        #endregion
        public void InitializeDataSource()
        {
             CheckDbAndSeed(_dataService.DatabasePath);
        }
        #region Private Methods
        private void CheckDbAndSeed(string dbPath)
        {
            if (!CheckDbExistence(dbPath))
            {
               using (var db = new SQLite.SQLiteConnection(dbPath))
                {
                    db.CreateTable<GebaeudeartEntity>();
                    db.CreateTable<ImmobilieEntity>();
                    db.CreateTable<GebBauweiseEntity>();
                    db.CreateTable<GebAusbauzustandEntity>();
                    db.CreateTable<GebArtXBauweiseEntity>();
                    db.CreateTable<GebArtXAusbauEntity>();
                    db.CreateTable<GebArtStandardEntity>();
                    db.CreateTable<GebArtBaupreisindexEntity>();
                    db.CreateTable<BaupreisindexEntity>();
                    db.CreateTable<ModernisierungEntity>();
                    db.CreateTable<ModernisierungsgradEntity>();
                    db.CreateTable<NHKostenEntity>();
                    db.CreateTable<StandardstufeEntity>();
                    db.CreateTable<GebaeudeteilEntity>();
                    db.CreateTable<WaegungsanteilEntity>();
                    db.CreateTable<ImmobilieBildEntity>();
                    db.CreateTable<TeilStandardEntity>();
                    db.CreateTable<ImmobilieModernisierungEntity>();
                    db.CreateTable<GesamtnutzungsdauerEntity>();
                    db.CreateTable<KorrekturfaktorEntity>();
                    db.CreateTable<KorrekturfaktortypEntity>();
                    db.CreateTable<ImmobilieKorrFaktorEntity>();
                    List<string> seedStringList = _dataService.GetSeedStringFromList();
                    foreach (var item in seedStringList)
                    {
                        db.Execute(item);
                    }
                }
            }
        }
        private bool CheckDbExistence(string dbPath)
        {
            bool dbExists = true;
            try
            {
                using (var db = new SQLite.SQLiteConnection(dbPath, SQLite.SQLiteOpenFlags.ReadWrite))
                {
                }
            }
            catch (SQLite.SQLiteException)
            {
                dbExists = false;
            }
            return dbExists;
        }
        #endregion
    }
}

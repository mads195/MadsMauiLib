using Mads195.MadsMauiLib.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.Database.SQLite
{
    public class SQLiteDb : ISQLiteDb
    {
        private readonly string _databaseFileName;
        private readonly string _databaseFilePath;
        private SQLiteAsyncConnection _database;

        private static readonly SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.ProtectionComplete;

        public SQLiteDb(string dbFileName = "DB", string? overridePath = null)
        {
            _databaseFileName = $"{dbFileName}.db3";
            string basePath = overridePath ?? FileSystem.AppDataDirectory;
            _databaseFilePath = Path.Combine(basePath, _databaseFileName);
        }

        private SQLiteAsyncConnection Database =>
            _database ??= new SQLiteAsyncConnection(_databaseFilePath, Flags);

        public string GetDatabasePath() => _databaseFilePath;

        public Task CreateTableAsync<T>() where T : new() =>
            Database.CreateTableAsync<T>(CreateFlags.None);

        public Task DropTableAsync<T>() where T : new() =>
            Database.DropTableAsync<T>();

        public Task<int> InsertAsync<T>(T data) where T : new() =>
            Database.InsertAsync(data);

        public Task<int> InsertOrReplaceAsync<T>(T data) where T : new() =>
            Database.InsertOrReplaceAsync(data);

        public Task<int> UpdateAsync<T>(T data) where T : new() =>
            Database.UpdateAsync(data);

        public Task<List<T>> GetAllDataAsync<T>() where T : new() =>
            Database.Table<T>().ToListAsync();

        public Task<int> DeleteAllDataAsync<T>() where T : new() =>
            Database.DeleteAllAsync<T>();

        public Task<int> DeleteDataAsync<T>(T data) where T : new() =>
            Database.DeleteAsync(data);

        public Task<List<T>> QueryAsync<T>(string sqlQuery) where T : new() =>
            Database.QueryAsync<T>(sqlQuery);

        public Task<List<T>> QueryAsync<T>(string sqlQuery, params object[] args) where T : new() =>
            Database.QueryAsync<T>(sqlQuery, args);

        public Task RunInTransactionAsync(Action<SQLiteConnection> transaction) =>
            Database.RunInTransactionAsync(transaction);

        public bool DatabaseExists() =>
            File.Exists(_databaseFilePath);

        public bool InitializeDatabase()
        {
            try
            {
                if (!DatabaseExists())
                {
                    Database.CreateTableAsync<MmlAppLog>().Wait();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error initializing database: {ex.Message}", ex);
            }
        }
    }
}

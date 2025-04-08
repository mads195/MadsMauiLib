using Mads195.MadsMauiLib.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.Database.SQLite
{
    public class SQLiteDb(string dbFileName = "DB") : ISQLiteDb
    {
        private readonly string DatabaseFileName = $"{dbFileName}.db3";
        private SQLiteAsyncConnection _database;

        private static readonly SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.ProtectionComplete;

        private SQLiteAsyncConnection Database =>
            _database ??= CreateConnection();

        private SQLiteAsyncConnection CreateConnection()
        {
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                DatabaseFileName
            );
            return new SQLiteAsyncConnection(dbPath, Flags);
        }

        public string GetDatabasePath() =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFileName);

        public Task CreateTableAsync<T>() where T : new()
        {
            return Database.CreateTableAsync<T>(CreateFlags.None);
        }

        public Task DropTableAsync<T>() where T : new()
        {
            return Database.DropTableAsync<T>();
        }

        public Task<int> InsertAsync<T>(T data) where T : new()
        {
            return Database.InsertAsync(data);
        }

        public Task<int> InsertOrReplaceAsync<T>(T data) where T : new()
        {
            return Database.InsertOrReplaceAsync(data);
        }

        public Task<int> UpdateAsync<T>(T data) where T : new()
        {
            return Database.UpdateAsync(data);
        }

        public Task<List<T>> GetAllDataAsync<T>() where T : new()
        {
            return Database.Table<T>().ToListAsync();
        }

        public Task<int> DeleteAllDataAsync<T>() where T : new()
        {
            return Database.DeleteAllAsync<T>();
        }

        public Task<int> DeleteDataAsync<T>(T data) where T : new()
        {
            return Database.DeleteAsync(data);
        }

        public Task<List<T>> QueryAsync<T>(string sqlQuery) where T : new()
        {
            return Database.QueryAsync<T>(sqlQuery);
        }

        public Task<List<T>> QueryAsync<T>(string sqlQuery, params object[] args) where T : new()
        {
            return Database.QueryAsync<T>(sqlQuery, args);
        }

        public Task RunInTransactionAsync(Action<SQLiteConnection> transaction)
        {
            return Database.RunInTransactionAsync(transaction);
        }

        public Task<List<T>> Query<T>(string sqlQuery) where T : new()
        {
            throw new NotImplementedException();
        }
        public bool DatabaseExists()
        {
            string path = GetDatabasePath();
            return File.Exists(path);
        }
        public bool InitializeDatabase()
        {
            try
            {
                if (!DatabaseExists())
                {
                    CreateTableAsync<MmlAppLog>().Wait();
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

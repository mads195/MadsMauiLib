using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.Database.SQLite
{
    public interface ISQLiteDb
    {
        Task CreateTableAsync<T>() where T : new();

        Task DropTableAsync<T>() where T : new();

        Task<int> InsertAsync<T>(T data) where T : new();

        Task<int> InsertOrReplaceAsync<T>(T data) where T : new();

        Task<int> UpdateAsync<T>(T data) where T : new();

        Task<List<T>> GetAllDataAsync<T>() where T : new();

        Task<int> DeleteAllDataAsync<T>() where T : new();

        Task<int> DeleteDataAsync<T>(T data) where T : new();

        Task<List<T>> Query<T>(string sqlQuery) where T : new();
        bool DatabaseExists();
        bool InitializeDatabase();
    }
}

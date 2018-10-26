using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Colaboro.Models;
using SQLite;

namespace Colaboro.Data
{
     
    public class ColaboroDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ColaboroDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<List<Usuario>> GetItemsAsync()
        {
            return database.Table<Usuario>().ToListAsync();
        }

        public Task<List<Usuario>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Usuario>("SELECT * FROM [Usuario] WHERE [Ativo] = 0");
        }

       

        public Task<Usuario> GetItemAsync(string username)
        {
            return database.Table<Usuario>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

        public async Task<bool>   IsUser()
        { 
            var result = false;
            var count  = await database.Table<Usuario>().CountAsync();
            /* task.ContinueWith(t =>
             {
                 if (t.IsCompleted)
                 {
                     result = true;
                     Debug.WriteLine(t.Result.Username);
                 }
             }, TaskScheduler.FromCurrentSynchronizationContext());*/
            if (count > 0)
            {
                result = true;
            }
            return result;
        }

        public async void SaveUserAsync(Usuario item)
        {
            var result = await database.Table<Usuario>().Where(i => i.Username == item.Username).CountAsync();

            if (result > 0)           
            {
                await database.UpdateAsync(item);
            }
            else
            {
                await database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Usuario item)
        {
            return database.DeleteAsync(item);
        }
    }
}

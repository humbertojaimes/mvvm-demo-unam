using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmApp.Model.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace MvvmApp.Model.Storage
{
    public class SQLiteAsyncManager
    {
        private SQLiteAsyncConnection database;

        public SQLiteAsyncManager()
        {
            database =
                DependencyService.Get<ISQLite>()
                                 .GetAsyncConnection();
            database.CreateTableAsync<Employee>().Wait();
        }

        public async Task SaveValue<T>
        (T value, bool overrideIfExists) where T : class, IKeyObject, new ()
        {
            T item = await database.FindAsync<T>(value.Id);

            if (item == null)
                await database.InsertAsync(value);
            else
            {
                if (overrideIfExists)
                    await database.UpdateAsync(value);
                else
                    throw new Exception($"Item {value.Id} already exists in DB");
            }
        }


        public async Task<List<T>> GetAllItems<T>()
            where T : class, IKeyObject, new()
        {
            return await database.Table<T>().ToListAsync();
        }

    }
}

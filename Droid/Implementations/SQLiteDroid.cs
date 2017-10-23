using System;
using System.IO;
using MvvmApp.Droid.Implementations;
using MvvmApp.Model.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace MvvmApp.Droid.Implementations
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteDroid()
        {
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(GetPath());
        }

        private string GetPath()
        {
            var sqliteFilename = "SQLite.db3";
            string documentsPath 
            = Environment.GetFolderPath
                         (Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}

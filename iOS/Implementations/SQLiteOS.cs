using System;
using System.IO;
using MvvmApp.iOS.Implementations;
using MvvmApp.Model.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace MvvmApp.iOS.Implementations
{
    public class SQLiteIOS : ISQLite
    {
        public SQLiteIOS()
        {
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return new SQLiteAsyncConnection(GetPath());
        }

        private string GetPath()
        {
            var sqliteFilename = "SQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            return path;
        }
    }
}

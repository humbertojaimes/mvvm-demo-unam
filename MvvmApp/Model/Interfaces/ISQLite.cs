using System;
using SQLite;

namespace MvvmApp.Model.Interfaces
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}

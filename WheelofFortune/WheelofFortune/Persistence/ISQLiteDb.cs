using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WheelofFortune.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WheelofFortune.Data
{
    /// <summary>
    /// Interface used for establishing a SQLite connection by shared project
    /// and by other projects, such as the android project. 
    /// Made purely for being multiplatform compatible. 
    /// </summary>
    public interface IDatabase
    {
        SQLiteAsyncConnection GetConnection();

    }
}

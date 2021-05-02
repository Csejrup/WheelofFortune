using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WheelofFortune.Data;
using WheelofFortune.Droid.Data;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]

namespace WheelofFortune.Droid.Data
{
    class SQLite_Android : IDatabase
    {
        public SQLite_Android()
        {

        }
        public SQLiteAsyncConnection GetConnection()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "WheelofFortune.db");

            var conn = new SQLiteAsyncConnection(dbPath);

            return conn;

        }
    }
}
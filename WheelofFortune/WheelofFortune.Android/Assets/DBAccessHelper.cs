using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using WheelofFortune.Data;
using WheelofFortune.Droid.Assets;
using Xamarin.Essentials;
using Xamarin.Forms;
[assembly: Dependency(typeof(DBAccessHelper))]
namespace WheelofFortune.Droid.Assets
{
    public class DBAccessHelper : IDatabase
    {
       /// <summary>
       /// Method used by the Android Project to estable DB connection 
       /// and creates a db file if it does not exist. 
       /// </summary>
       /// <returns></returns>
        public SQLiteAsyncConnection GetConnection()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "WheelofFortune.db");
            //Create the db file if it doesnt exist already
            if (!File.Exists(dbPath))
            {
                FileStream writeStream = new FileStream(dbPath, FileMode.OpenOrCreate, FileAccess.Write);
                Forms.Context.Assets.Open("WheelofFortune.db").CopyToAsync(writeStream);
            }
            var conn = new SQLiteAsyncConnection(dbPath);
            return conn;

        }

    }
}
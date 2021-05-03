using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WheelofFortune.Data;
using WheelofFortune.Models;
using Xamarin.Forms;

namespace WheelofFortune.Services
{
    /// <summary>
    /// Class for Database Services (Calls)
    /// </summary>
    public static class PrizeService
    {
        static SQLiteAsyncConnection db;
        /// <summary>
        /// Method for initializing the connection to the database 
        /// Creates a Table for Prize
        /// </summary>
        /// <returns></returns>
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            db = DependencyService.Get<IDatabase>().GetConnection();
            await db.CreateTableAsync<Prize>();

        }
        /// <summary>
        /// Async Method for inserting a prize into the Database when called. 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static async Task AddPrize(int points, DateTime date)
        {
            await Init();

            var prize = new Prize
            {
                Points = points,
                Date = date
            };

            var id = await db.InsertAsync(prize).ConfigureAwait(false);

            Console.Write("New prize id: {0}", prize.Id); ///FOR TEST
        }
        /// <summary>
        /// Async Method for retrieving Prize entities when called
        /// and returns a list of prize objects
        /// </summary>
        /// <returns></returns>
        public static async Task <IEnumerable<Prize>> GetPrizes()
        {
            await Init();

            var prize = await db.Table<Prize>().ToListAsync().ConfigureAwait(false);

            return prize;
        }
    }
}

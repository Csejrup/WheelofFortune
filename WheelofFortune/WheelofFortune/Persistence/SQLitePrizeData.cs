using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Interfaces;
using WheelofFortune.Models;

namespace WheelofFortune.Persistence
{
    /// <summary>
    /// SQLite Class for a Prize Object. 
    /// Contains CRUD Operation Methods
    /// </summary>
    public class SQLitePrizeData : IPrizeData
    {
        private SQLiteAsyncConnection _connection;
        public SQLitePrizeData(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Prize>();
        }
        /// <summary>
        /// Async method for Adding an prize entity to the database
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
        public async Task AddPrize(Prize prize)
        {
            await _connection.InsertAsync(prize).ConfigureAwait(false);
        }
        /// <summary>
        /// Method for retrieving an prize entity from the database by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Prize> GetPrize(int id)
        {
            return await _connection.FindAsync<Prize>(id).ConfigureAwait(false);
        }
        /// <summary>
        /// Async Method for retrieveing all Prize entities from the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Prize>> GetPrizesAsync()
        {
            return await _connection.Table<Prize>().ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// Async Method for deleting an prize entity from the database
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
        public async Task DeletePrize(Prize prize)
        {
            await _connection.DeleteAsync(prize).ConfigureAwait(false);
        }
        /// <summary>
        /// Async Method for updating an prize entity in the database
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
        public async Task UpdatePrize(Prize prize)
        {
            await _connection.UpdateAsync(prize).ConfigureAwait(false);
        }
    }
}

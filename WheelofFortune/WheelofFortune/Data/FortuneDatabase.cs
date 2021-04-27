using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Models;

namespace WheelofFortune.Data
{
    public class FortuneDatabase : BaseDatabase
    {
        public async Task<List<Prize>> GetAllPrizes()
        {
            var conn = await GetDatabaseConnection<Prize>().ConfigureAwait(false);
            return await AttemptAndRetry(() => conn.Table<Prize>().ToListAsync()).ConfigureAwait(false);
        }
        public async Task<Prize> GetPrizeAsync(int id)
        {
            var conn = await GetDatabaseConnection<Prize>().ConfigureAwait(false);
            // Get a specific prize
            return await AttemptAndRetry(()=> conn.Table<Prize>().Where(i => i.Id == id)
                            .FirstOrDefaultAsync());
        }

        public async Task<int> SavePrizeAsync(Prize prize)
        {
            var conn = await GetDatabaseConnection<Prize>().ConfigureAwait(false);
            if (prize.Id != 0)
            {
                // Update an existing note.
                return await conn.UpdateAsync(prize).ConfigureAwait(false);
            }
            else
            {
                // Save a new note.
                return await conn.InsertAsync(prize).ConfigureAwait(false);
            }
        }

        public async Task<int> DeleteNoteAsync(Prize prize)
        {
            var conn = await GetDatabaseConnection<Prize>().ConfigureAwait(false);
            // Delete a note.
            return await conn.DeleteAsync(prize).ConfigureAwait(false);
        }



    }
}

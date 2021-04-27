using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Models;

namespace WheelofFortune.Data
{
    public class WheelofFortuneDatabase
    {
        readonly SQLiteAsyncConnection database;

        public WheelofFortuneDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Prize>().Wait();
        }

        public Task<List<Prize>> GetPrizesAsync()
        {
            return database.Table<Prize>().ToListAsync();
        }
        public Task<Prize> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Prize>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Prize prize)
        {
            if (prize.Id != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(prize);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(prize);
            }
        }

        public Task<int> DeleteNoteAsync(Prize prize)
        {
            // Delete a note.
            return database.DeleteAsync(prize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Models;
using System.Linq;
namespace WheelofFortune.Services
{
    public class MockDataStore : IDataStore<Prize>
    {

        readonly List<Prize> prizes;

        public MockDataStore()
        {
            prizes = new List<Prize>()
            {
                new Prize { Id = Guid.NewGuid().ToString(), Text = "First prize", Description="This is an prize description." , Image="empty"},
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Second prize", Description="This is an prize description."  , Image="empty"},
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Third prize", Description="This is an prize description."  , Image="empty"},
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Fourth prize", Description="This is an prize description."  , Image="empty"},
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Fifth prize", Description="This is an prize description."  , Image="empty"},
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Sixth prize", Description="This is an prize description." , Image="empty" }
            };
        }

        public async Task<bool> AddPrizeAsync(Prize prize)
        {
            prizes.Add(prize);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePrizeAsync(Prize prize)
        {
            var oldItem = prizes.Where((Prize arg) => arg.Id == prize.Id).FirstOrDefault();
            prizes.Remove(oldItem);
            prizes.Add(prize);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePrizeAsync(string id)
        {
            var oldItem = prizes.Where((Prize arg) => arg.Id == id).FirstOrDefault();
            prizes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Prize> GetPrizeAsync(string id)
        {
            return await Task.FromResult(prizes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Prize>> GetPrizesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(prizes);
        }

    }
}

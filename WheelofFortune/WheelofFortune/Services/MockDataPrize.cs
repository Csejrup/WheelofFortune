using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Interfaces;
using WheelofFortune.Models;

namespace WheelofFortune.Services
{
    /// <summary>
    /// Class to Mock Data for prize objects
    /// </summary>
    public class MockDataPrize : IDataPrize<Prize>
    {
        readonly List<Prize> prizes;

        public MockDataPrize()
        {
            prizes = new List<Prize>()
            {
                new Prize { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Prize { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }
        /// <summary>
        /// Async method to add a Prize to the wheel
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
        public async Task<bool> AddPrizeAsync(Prize prize)
        {
            prizes.Add(prize);

            return await Task.FromResult(true);
        }
        /// <summary>
        /// Async Method to Update an existing Prize
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePrizeAsync(Prize prize)
        {
            var oldItem = prizes.Where((Prize arg) => arg.Id == prize.Id).FirstOrDefault();
            prizes.Remove(oldItem);
            prizes.Add(prize);

            return await Task.FromResult(true);
        }
        /// <summary>
        /// Method for deleting a prize 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeletePrizeAsync(string id)
        {
            var oldItem = prizes.Where((Prize arg) => arg.Id == id).FirstOrDefault();
            prizes.Remove(oldItem);

            return await Task.FromResult(true);
        }
        /// <summary>
        /// Method to get a prize by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Prize> GetPrizeAsync(string id)
        {
            return await Task.FromResult(prizes.FirstOrDefault(s => s.Id == id));
        }
        /// <summary>
        /// Method to get all prizes
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Prize>> GetPrizesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(prizes);
        }

    }
}

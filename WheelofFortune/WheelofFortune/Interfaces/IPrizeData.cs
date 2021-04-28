using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Models;

namespace WheelofFortune.Interfaces
{
   public interface IPrizeData
    {
        Task<IEnumerable<Prize>> GetPrizesAsync();
        Task<Prize> GetPrize(int id);
        Task AddPrize(Prize prize);
        Task UpdatePrize(Prize prize);
        Task DeletePrize(Prize prize);


    }
}

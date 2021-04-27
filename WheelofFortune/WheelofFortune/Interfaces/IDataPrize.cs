﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WheelofFortune.Interfaces
{
    /// <summary>
    /// Interface for CRUD operations for a prize object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataPrize<T>
    {
        Task<bool> AddPrizeAsync(T prize);
        Task<bool> UpdatePrizeAsync(T prize);
        Task<bool> DeletePrizeAsync(string id);
        Task<T> GetPrizeAsync(string id);
        Task<IEnumerable<T>> GetPrizesAsync(bool forceRefresh = false);
    }
}
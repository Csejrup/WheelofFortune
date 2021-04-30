﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WheelofFortune.Models;
using Xamarin.Essentials;

namespace WheelofFortune.Services
{
    public static class PrizeService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "WheelofFortune.db");

            db = new SQLiteAsyncConnection(dbPath);

            await db.CreateTableAsync<Prize>();

        }

        public static async Task AddPrize(int points, DateTime date)
        {
            await Init();

            var prize = new Prize
            {
                Points = points,
                Date = date
            };

            var id = await db.InsertAsync(prize);

            Console.Write("New prize id: {0}", prize.Id);
        }

        public static async Task <IEnumerable<Prize>> GetPrizes()
        {
            await Init();

            var prize = await db.Table<Prize>().ToListAsync();

            return prize;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;
using WheelofFortune.Models;

namespace WheelofFortune.ViewModels
{
    /// <summary>
    /// Class - viewmodel - for a prize
    /// </summary>
    public class PrizeViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private int number;
        public int Number
        {
            get => number; set
            {
                SetProperty(ref number, value);
            }
        }
        private DateTime datetime;
        public DateTime Datetime
        {
            get => datetime; set
            {
                SetProperty(ref datetime, value);
            }
        }

        public PrizeViewModel(){}

        public PrizeViewModel(Prize prize)
        {
            Id = prize.Id;
            number = prize.Points;
            datetime = prize.Date;
        }


    }
}

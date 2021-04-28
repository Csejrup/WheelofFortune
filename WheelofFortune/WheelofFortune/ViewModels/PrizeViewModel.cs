﻿using System;
using System.Collections.Generic;
using System.Text;
using WheelofFortune.Models;

namespace WheelofFortune.ViewModels
{
    public class PrizeViewModel : BaseViewModel
    {
        public int Id { get; set; }

        private string number;
        public string Number
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
            number = prize.Number;
            datetime = prize.Date;
        }


    }
}
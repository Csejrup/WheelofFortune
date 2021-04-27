using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WheelofFortune.Models;

namespace WheelofFortune.ViewModels
{
    public class WheelViewModel : BaseViewModel
    {
        #region properties
        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        private string description;
        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }
        private string prizeId;
        public string PrizeId
        {
            get
            {
                return prizeId;
            }
            set
            {
                prizeId = value;
                LoadPrizeId(value);
            }
        }
        public string Id { get; set; }
        private bool isSpinning;
        public bool IsSpinning 
        { 
            get => isSpinning; set
            {
                SetProperty(ref isSpinning, value);
            }
        }
        private double refreshRate;
        public double RefreshRate
        {
            get => refreshRate; set
            {
                SetProperty(ref refreshRate, value);
            }
        }
        private Wheel wheel;
        public Wheel Wheel
        {
            get => wheel; set
            {
                SetProperty(ref wheel, value);
            }
        }
        private Sector number;
        public Sector Number
        {
            get => number; set
            {
                SetProperty(ref number, value);
            }
        }
        private List<ChartData> chartData;
        public List<ChartData> ChartData
        {
            get => chartData; set
            {
                SetProperty(ref chartData, value);
            }
        }
        private List<string> colors;
        public List<string> Colors
        {
            get => colors; set
            {
                SetProperty(ref colors, value);
            }
        }
        private List<int> invalidPoints;
        public List<int> InvalidPoints
        {
            get => invalidPoints; set
            {
                SetProperty(ref invalidPoints, value);
            }
        }

        #endregion 
        #region Events
        public event EventHandler DataReady;
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public WheelViewModel()
        {
            LoadData();
        }
        /// <summary>
        /// Method for loading a price by id.
        /// </summary>
        /// <param name="prizeId"></param>
        public async void LoadPrizeId(string prizeId)
        {
            try
            {
                var item = await DataPrize.GetPrizeAsync(prizeId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Prize");
            }
        }
        /// <summary>
        /// Method for loading data for the wheel
        /// </summary>
        private void LoadData()
        {
            Colors = new List<string>() { "#F25022", "#7FBA00", "#00A4EF", "#FFB900", "#737373", "#F4B400", "#0F9D58", "#737373", "#FFB900", "#00A4EF", "#7FBA00", "#F25022" }; //Microsoft Colors
            Wheel = new Wheel
            {
                Sectors = new List<Sector>()
            };
            //Hardcoded: Future: Can be replaced by an api call to generate a wheel
            for (int i = 0; i < 12; i++)
            {
                Wheel.Sectors.Add(new Sector()
                {
                    Color = Colors[i],
                    number = 100 * (i + 1)
                });

            }
            ChartData = new List<ChartData>();
            foreach (var sector in Wheel.Sectors)
                ChartData.Add(new ChartData() { Sector = sector });

            int total = 360;
            int sides = ChartData.Count;
            double divisor = total / sides;
            double counter = divisor;
            InvalidPoints = new List<int>();
            while (counter <= total)
            {
                InvalidPoints.Add((int)Math.Round(counter, MidpointRounding.AwayFromZero));
                counter += divisor;
            }
            DataReady?.Invoke(this, null);
        }
    }
}


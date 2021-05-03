using System;
using System.Collections.Generic;
using WheelofFortune.Models;

namespace WheelofFortune.ViewModels
{
    /// <summary>
    /// Class - ViewModel - for the WheelPage View. 
    /// </summary>
    public class WheelViewModel : BaseViewModel
    {
        #region properties
       
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
        private void LoadData()
        {
            Colors = new List<string>() { "#7D84AA","#484F75", "#292F50" }; 
            Wheel = new Wheel
            {
                Sectors = new List<Sector>()
            };
            //Hardcoded: Future: Can be replaced by an api call to generate a wheel
            int currentColor = 0;
            for (int i = 0; i < 12; i++)
            {
                Wheel.Sectors.Add(new Sector()
                {
                    Color = Colors[currentColor],
                    number = 100 * (i + 1)
                });

                currentColor++;

                if (currentColor == Colors.Count)
                {
                    currentColor = 0;
                }
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


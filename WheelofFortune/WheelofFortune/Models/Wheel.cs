using System;
using System.Collections.Generic;
using System.Text;

namespace WheelofFortune.Models
{
    /// <summary>
    /// Class Model for Wheel
    /// Used for drawing the wheel
    /// </summary>
    public class Wheel
    {
        public List<Sector> Sectors { get; set; }
    }
    public class Sector
    {
        public int number { get; set; }
        public string Color { get; set; }
    }
}

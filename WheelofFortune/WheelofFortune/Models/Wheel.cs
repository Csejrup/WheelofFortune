using System;
using System.Collections.Generic;
using System.Text;

namespace WheelofFortune.Models
{
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

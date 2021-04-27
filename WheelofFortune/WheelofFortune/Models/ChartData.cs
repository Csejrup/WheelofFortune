using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using WheelofFortune.Helpers;

namespace WheelofFortune.Models
{
    public class ChartData
    {
        public string Text => $"{WheelConstants.EmptySpaces}{Sector.number.ToString()}";
        public SKColor Color => Xamarin.Forms.Color.FromHex(Sector.Color).ToSKColor();

        public Sector Sector { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WheelofFortune.Models
{
    /// <summary>
    /// Class with attributes for a Prize Object (model)
    /// </summary>
    public class Prize
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}

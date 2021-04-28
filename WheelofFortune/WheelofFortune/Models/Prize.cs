using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace WheelofFortune.Models
{
    /// <summary>
    /// Class with attributes for a Prize Object (model)
    /// </summary>
    public class Prize
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }


    }
}

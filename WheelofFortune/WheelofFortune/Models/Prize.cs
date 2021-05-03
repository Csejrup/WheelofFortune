using System;
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
        public int Points { get; set; }
        public DateTime Date { get; set; }
    }
}

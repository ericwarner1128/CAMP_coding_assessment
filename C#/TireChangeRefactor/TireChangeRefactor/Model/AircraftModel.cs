using System;

namespace TireChangeRefactor.Model
{
    /// <summary>
    /// Class that descibes an aircraft
    /// </summary>
    public class AircraftModel
    {
        public int Id { get; set; }
        public DateTime LastTireChange { get; set; }
        public string Manufacturer { get; set; }
        public DateTime[] Landings { get; set; }  
    }
}

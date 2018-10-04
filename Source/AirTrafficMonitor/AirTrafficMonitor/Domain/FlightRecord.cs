using System;

namespace AirTrafficMonitor
{
    public class FlightRecord
    {
        public string Tag { get; set; }
        public Position Position { get; set; }
        public int Altitude { get; set; } // put in position
        public DateTime Timestamp { get; set; }
    }
}

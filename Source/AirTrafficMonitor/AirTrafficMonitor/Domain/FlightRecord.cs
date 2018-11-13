using System;

namespace AirTrafficMonitor.Domain
{
    public class FlightRecord
    {
        public string Tag { get; set; }
        public Position Position { get; set; }
        public DateTime Timestamp { get; set; }

    }
}

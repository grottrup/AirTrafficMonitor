using System;

namespace AirTrafficMonitor.Domain
{
    public class FlightInCollision
    {
        public FlightInCollision(string tag1, string tag2, DateTime timestamp)
        {
            Tag1 = tag1;
            Tag2 = tag2;
            TimeStamp = timestamp;
        }

        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
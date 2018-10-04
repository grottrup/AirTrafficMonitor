using System;
using System.Collections.Generic;

namespace AirTrafficMonitor.View
{
    public class FlightTrack // refactor... only like this for simplicity and to make logic for the rest of the code
    {
        private readonly List<FlightRecord> _records;

        public string Tag { get; }
        public DateTime LatestTime { get; private set; }
        public int Course { get; private set; }
        public int Velocity { get; private set; }
        public Position Position { get; private set; }




        public FlightTrack(string tag)
        {
            Tag = tag;
            _records = new List<FlightRecord>();
        }

        public void Add(FlightRecord record)
        {
            LatestTime = record.Timestamp;
            Position = record.Position;
        }
    }
}
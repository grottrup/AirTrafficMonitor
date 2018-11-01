using System;
using System.Collections.Generic;

namespace AirTrafficMonitor.Domain
{
    public class FlightTrack
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
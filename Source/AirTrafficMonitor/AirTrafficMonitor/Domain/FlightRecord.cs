﻿using System;

namespace AirTrafficMonitor
{
    public class FlightRecord
    {
        public string RawData { get; } //remove
        public string Tag { get; set; }
        public Position Position { get; set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }

        public FlightRecord(string rawData)
        {
            RawData = rawData;
        }
    }
}
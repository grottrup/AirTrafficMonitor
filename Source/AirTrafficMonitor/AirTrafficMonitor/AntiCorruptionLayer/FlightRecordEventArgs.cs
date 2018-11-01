using AirTrafficMonitor.Domain;
using System;

namespace AirTrafficMonitor.AntiCorruptionLayer
{
    public class FlightRecordEventArgs : EventArgs
    {
        public FlightRecord FlightRecord { get; private set; }

        public FlightRecordEventArgs(FlightRecord record)
        {
            FlightRecord = record;
        }
    }
}
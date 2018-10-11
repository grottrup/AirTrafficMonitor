using System;

namespace AirTrafficMonitor.Observer
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
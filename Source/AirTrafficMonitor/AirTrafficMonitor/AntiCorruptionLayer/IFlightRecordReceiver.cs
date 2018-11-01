using System;

namespace AirTrafficMonitor.AntiCorruptionLayer
{

    public interface IFlightRecordReceiver
    {
        event EventHandler<FlightRecordEventArgs> FlightRecordReceived;
    }
}
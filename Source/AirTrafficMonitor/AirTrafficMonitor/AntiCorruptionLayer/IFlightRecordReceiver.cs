using System;

namespace AirTrafficMonitor.Observer
{

    public interface IFlightRecordReceiver
    {
        event EventHandler<FlightRecordEventArgs> FlightRecordReceived;
    }
}
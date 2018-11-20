using System;

namespace AirTrafficMonitor
{
    public interface IFlightObserver
    {
        event EventHandler<FlightTrackEventArgs> EnteredAirspace;
        event EventHandler<FlightTrackEventArgs> LeftAirspace;
    }
}
using System;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ISeperationHandler
    {
        event EventHandler<FlightInProximityEventArgs> FlightsInProximity;
        void DetectCollision(Tuple<IFlightTrack, IFlightTrack> tracks);
    }
}
using System;
using System.Collections.Generic;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ISeperationHandler
    {
        event EventHandler<FlightInProximityEventArgs> FlightsInProximity;
        void DetectCollision(Tuple<FlightTrack, FlightTrack> tracks);
    }
}
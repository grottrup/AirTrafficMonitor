using System.Collections.Generic;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ISeperationHandler
    {
        void DetectCollision(List<FlightTrack> tracks);
    }
}
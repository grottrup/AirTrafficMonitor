using System.Collections.Generic;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor
{
    public interface ISeperationHandler
    {
        void DetectCollision(List<FlightTrack> tracks);
    }
}
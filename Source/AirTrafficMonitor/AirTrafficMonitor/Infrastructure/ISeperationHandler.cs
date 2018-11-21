using System.Collections.Generic;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ISeperationHandler
    {
        void DetectCollision(ICollection<IFlightTrack> tracks);
    }
}
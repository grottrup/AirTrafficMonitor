using System;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(FlightTrack track);
        void RenderCollision(Tuple<FlightTrack, FlightTrack> flightsInCollision);
    }
}
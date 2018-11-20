
using System;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;


namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(FlightTrack track);
        void RenderCollision(Tuple<FlightTrack, FlightTrack> flightsInCollision);
        void RenderWithGreenTillTimerEnds(string renderstr, ITimer timer);
        void RenderWithRedTillTimerEnds(string renderstr, ITimer timer);

    }
}
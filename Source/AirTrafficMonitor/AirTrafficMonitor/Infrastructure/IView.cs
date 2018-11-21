
using System;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;


namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(Tuple<FlightTrack> track);
        void RenderCollision(Tuple<FlightTrack, FlightTrack> flightsInCollision);
        void RenderWithGreenTillTimerEnds(string renderstr);
        void RenderWithRedTillTimerEnds(string renderstr);

    }
}
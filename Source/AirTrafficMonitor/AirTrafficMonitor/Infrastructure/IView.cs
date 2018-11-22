
using System;
using AirTrafficMonitor.Domain;
 using System.Collections.Generic;


namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(Tuple<IFlightTrack> track);
        void RenderCollision(Tuple<IFlightTrack, IFlightTrack> flightsInCollision);
        void RenderWithGreenTillTimerEnds(string renderstr);
        void RenderWithRedTillTimerEnds(string renderstr);

    }
}
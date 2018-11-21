using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;
using System;
 using System.Collections.Generic;

namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(FlightTrack track);
        void RenderCollision(Tuple<FlightTrack, FlightTrack> ProximityList);
        void RenderWithGreenTillTimerEnds(string renderstr, ITimer timer);
        void RenderWithRedTillTimerEnds(string renderstr, ITimer timer);

        //void RenderCollision(List<FlightTrack> ProximityList);
    }
}
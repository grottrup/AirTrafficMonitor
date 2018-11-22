
using System;
using System.Timers;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;


namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(Tuple<IFlightTrack> track);
        void RenderCollision(Tuple<IFlightTrack, IFlightTrack> flightsInCollision);
        void RenderWithGreenTillTimerEnds(IFlightTrack track);
        void AddToRenderWithColor(string toRender, ConsoleColor color);

        ElapsedEventHandler RemoveFromView(IFlightTrack flightTrack);
    }
}
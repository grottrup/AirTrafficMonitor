using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;

namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(FlightTrack track);
        void ConsoleData(FlightInCollision eventArgs);
        void RenderWithGreenTillTimerEnds(string renderstr, ITimer timer);
        void RenderWithRedTillTimerEnds(string renderstr, ITimer timer);
    }
}
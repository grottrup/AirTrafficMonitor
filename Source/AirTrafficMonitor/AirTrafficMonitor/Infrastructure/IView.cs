using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface IView
    {
        void Render(FlightTrack track);
        void ConsoleData(FlightInCollision eventArgs);
    }
}
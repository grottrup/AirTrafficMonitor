namespace AirTrafficMonitor.View
{
    public interface IView
    {
        void Render(FlightTrack track);
        void ConsoleData(FlightInCollision eventArgs);
    }
}
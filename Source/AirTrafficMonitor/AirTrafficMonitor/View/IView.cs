namespace AirTrafficMonitor.View
{
    public interface IView
    {
        void Render(FlightRecord record);
        void ConsoleData(FlightInCollision eventArgs);
    }
}
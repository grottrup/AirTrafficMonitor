using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ILogger
    {
        void DataLog(FlightInCollision eventArgs);
    }
}
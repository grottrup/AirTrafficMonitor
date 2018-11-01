using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public interface ILogger
    {
        void DataLog(object test, FlightInCollision eventArgs);
    }
}
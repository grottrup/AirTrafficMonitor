using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.AntiCorruptionLayer
{
    public interface IFlightRecordFactory
    {
        FlightRecord CreateRecord(string rawRecordData);
    }
}

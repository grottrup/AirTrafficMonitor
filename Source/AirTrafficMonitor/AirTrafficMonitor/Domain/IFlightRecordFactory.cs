namespace AirTrafficMonitor.Domain
{
    public interface IFlightRecordFactory
    {
        FlightRecord CreateRecord(string rawRecordData);
    }
}

namespace AirTrafficMonitor.Domain
{
    public interface IAirTrafficTrackFactory
    {
        AirTrafficRecord CreateRecord(string rawTrackData);
    }
}

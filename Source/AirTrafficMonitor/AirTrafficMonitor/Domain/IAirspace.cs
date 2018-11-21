namespace AirTrafficMonitor.Domain
{
    public interface IAirspace
    {
        bool HasPositionWithinBoundaries(Position position);
    }
}
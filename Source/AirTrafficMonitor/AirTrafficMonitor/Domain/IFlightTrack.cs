using System;

namespace AirTrafficMonitor.Domain
{
    public interface IFlightTrack
    {
        string Tag { get; set; }
        DateTime LatestTime { get; set; }
        double NavigationCourse { get; set; }
        double Velocity { get; set; }
        Position Position { get; set; }

        void Update(FlightRecord record);
    }
}

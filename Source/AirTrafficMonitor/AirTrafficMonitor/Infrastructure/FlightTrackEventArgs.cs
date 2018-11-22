using System;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public class FlightTrackEventArgs: EventArgs
    {
        public IFlightTrack FlightTrack { get; private set; }

        public FlightTrackEventArgs(IFlightTrack track)
        {
            FlightTrack = track;
        }
    }
}
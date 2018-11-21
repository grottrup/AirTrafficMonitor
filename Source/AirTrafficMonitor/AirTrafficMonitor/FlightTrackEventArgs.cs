using System;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor
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
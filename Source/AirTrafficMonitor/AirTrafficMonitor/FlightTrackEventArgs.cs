using System;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor
{
    public class FlightTrackEventArgs: EventArgs
    {
        public FlightTrack FlightTrack { get; private set; }

        public FlightTrackEventArgs(FlightTrack track)
        {
            FlightTrack = track;
        }
    }
}
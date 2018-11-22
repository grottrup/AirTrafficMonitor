using System;
using AirTrafficMonitor.Domain;


namespace AirTrafficMonitor.Infrastructure
{
    public class FlightInProximityEventArgs : EventArgs
    {
        //public FlightTrack FlightTrack { get; private set; }
        public Tuple<IFlightTrack, IFlightTrack> proximityTracks;

        public FlightInProximityEventArgs(Tuple<IFlightTrack, IFlightTrack> tracks)
        {
            proximityTracks = tracks;
        }
    }
}
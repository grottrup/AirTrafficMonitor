using System;
using System.Collections;
using System.Collections.Generic;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Domain;

public class FlightInProximityEventArgs : EventArgs
{
    //public FlightTrack FlightTrack { get; private set; }
    public Tuple<FlightTrack, FlightTrack> ProximityList;

    public FlightInProximityEventArgs(Tuple<FlightTrack, FlightTrack> tracks)
    {
        ProximityList = tracks;
    }
}
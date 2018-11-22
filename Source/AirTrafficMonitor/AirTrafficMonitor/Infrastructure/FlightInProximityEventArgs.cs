﻿using System;
using System.Collections;
using System.Collections.Generic;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Domain;

public class FlightInProximityEventArgs : EventArgs
{
    //public FlightTrack FlightTrack { get; private set; }
    public Tuple<IFlightTrack, IFlightTrack> ProximityList;

    public FlightInProximityEventArgs(Tuple<IFlightTrack, IFlightTrack> tracks)
    {
        ProximityList = tracks;
    }
}
﻿using System.Collections.Generic;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor
{
    public interface ISeperationHandler
    {
        void DetectCollision(List<FlightTrack> tracks);
    }
}
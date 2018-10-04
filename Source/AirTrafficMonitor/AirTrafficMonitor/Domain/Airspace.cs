using System;
using System.Dynamic;

namespace AirTrafficMonitor
{
    public class Airspace
    {
        public int MaxPosition;
        public int MinPosition;
        public int MaxAltitude;
        public int MinAltitude;
        
        public Airspace(int maxPos, int minPos, int maxAlt, int minAlt)
        {
            MaxPosition = maxPos;
            MinPosition = minPos;
            MaxAltitude = maxAlt;
            MinAltitude = minAlt;

        }

        public Airspace()
        {
            MaxPosition = 90000;
            MinPosition = 10000;
            MaxAltitude = 20000;
            MinAltitude = 500;
        }
    }
}
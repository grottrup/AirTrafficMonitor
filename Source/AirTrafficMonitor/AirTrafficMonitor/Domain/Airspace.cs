using System;
using System.Dynamic;

namespace AirTrafficMonitor
{
    public class Airspace
    {
        private int MaxPosition = 90000;
        private int MinPosition = 10000;
        private int MaxAltitude = 20000;
        private int MinAltitude = 500;
        /*
        public Airspace(int MaxPos, int MinPos, int MaxAlt, int MinAlt)
        {
            MaxPosition = MaxPos;
            MinPosition = MinPos;
            MaxAltitude = MaxAlt;
            MinAltitude = MinAlt;

        }*/

        public bool IsWithin(Position Position, int Altitude)
        {
            if (Position.X < MinPosition || Position.X > MaxPosition)
                return false;
            if (Position.Y < MinPosition || Position.Y > MaxPosition)
                return false;
            if (Altitude < MinAltitude || Altitude > MaxAltitude)
                return false;
            return true;
        }
        
    }
}
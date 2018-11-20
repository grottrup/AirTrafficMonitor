namespace AirTrafficMonitor.Domain
{
    public class Airspace
    {
        public int MaxPosition { get; private set; } // both x and y... consider splitting
        public int MinPosition { get; private set; } // both x and y... consider splitting
        public int MaxAltitude { get; private set; }
        public int MinAltitude { get; private set; }
        
        public Airspace()
        {
            MaxPosition = 90000;
            MinPosition = 10000;
            MaxAltitude = 20000;
            MinAltitude = 500;
        }

        public Airspace(int maxAltitude, int minAltitude, int maxPosition, int minPosition)
        {
            MaxPosition = maxPosition;
            MinPosition = minPosition;
            MaxAltitude = maxAltitude;
            MinAltitude = minAltitude;
        }
    }
}
namespace AirTrafficMonitor.Domain
{

    public class Airspace : IAirspace
    {
        public int MaxPosition { get; private set; } // both x and y... consider splitting
        public int MinPosition { get; private set; } // both x and y... consider splitting
        public int MaxAltitude { get; private set; }
        public int MinAltitude { get; private set; }
        
        //public Airspace()
        //{
        //    MaxPosition = 90000;
        //    MinPosition = 10000;
        //    MaxAltitude = 20000;
        //    MinAltitude = 500;
        //}

        public Airspace(int maxPosition, int minPosition, int maxAltitude, int minAltitude)
        {
            MaxPosition = maxPosition;
            MinPosition = minPosition;
            MaxAltitude = maxAltitude;
            MinAltitude = minAltitude;
        }

        public bool HasPositionWithinBoundaries(Position position)
        {
            if (position != null)
            {
                if (position.Latitude < MinPosition || position.Latitude > MaxPosition)
                    return false;
                if (position.Longitude < MinPosition || position.Longitude > MaxPosition)
                    return false;
                if (position.Altitude < MinAltitude || position.Altitude > MaxAltitude)
                    return false;
                return true;
            }
            return false;
        }
    }
}
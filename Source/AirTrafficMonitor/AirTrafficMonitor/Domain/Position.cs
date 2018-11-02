namespace AirTrafficMonitor.Domain
{
    public class Position
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int Altitude { get; set; }

        public Position(int latitude, int longitude, int altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public Position()
        {
        }

        public bool IsWithin(Airspace airspace)
        {
            if (Latitude < airspace.MinPosition || Latitude > airspace.MaxPosition)
                return false;
            if (Longitude < airspace.MinPosition || Longitude > airspace.MaxPosition)
                return false;
            if (Altitude < airspace.MinAltitude || Altitude > airspace.MaxAltitude)
                return false;
            return true;
        }
    }

}

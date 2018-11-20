using System;

namespace AirTrafficMonitor.Domain
{
    public class Position
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int Altitude { get; set; }

        public Position() { }

        public Position(int latitude, int longitude, int altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }
    }

}

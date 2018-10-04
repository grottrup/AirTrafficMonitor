namespace AirTrafficMonitor
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Altitude { get; set; }

        public Position(int x, int y) // remove this constructor
        {
            X = x;
            Y = y;
        }

        public Position(int x, int y, int altitude)
        {
            X = x;
            Y = y;
            Altitude = altitude;
        }

        /*
        public bool IsWithin(Airspace airspace)
        {
            return true; //make checker
        }*/
    }
}

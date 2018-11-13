namespace AirTrafficMonitor.Domain
{
    public class Airspace
    {
        public int MaxPosition { get; }
        public int MinPosition { get; }
        public int MaxAltitude { get; }
        public int MinAltitude { get; }
        
        public Airspace()
        {
            MaxPosition = 90000;
            MinPosition = 10000;
            MaxAltitude = 20000;
            MinAltitude = 500;
        }
    }
}
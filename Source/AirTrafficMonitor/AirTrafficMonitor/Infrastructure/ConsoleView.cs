using AirTrafficMonitor.Domain;
using System;

namespace AirTrafficMonitor.Infrastructure
{
    public class ConsoleView : IView
    {
        public void Render(FlightTrack track)
        {
            Console.WriteLine(track.ToString());
        }

        public void ConsoleData(FlightInCollision eventArgs)
        {
            Console.WriteLine("Warning, two planes are currently on collision course! " +
                              "\n Plane Tag: " + eventArgs.Tag1 + " and plane Tag: " + eventArgs.Tag2 + "\n Current time: " +
                              eventArgs.TimeStamp);
        }
        
    }
}

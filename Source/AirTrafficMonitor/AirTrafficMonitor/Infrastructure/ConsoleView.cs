using AirTrafficMonitor.Domain;
using System;
using System.IO;

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
            string tag1 = eventArgs.Tag1;
            string tag2 = eventArgs.Tag2;
            DateTime time = eventArgs.TimeStamp;
            Console.WriteLine("Warning, two planes are currently on collision course! " +
                              "\n Plane Tag: {0} and plane Tag: {1}\n Current time: {2}", tag1, tag2, time);
        }
        
    }
}

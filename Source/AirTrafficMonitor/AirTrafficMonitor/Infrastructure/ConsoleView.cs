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

        public void RenderCollision(Tuple<FlightTrack, FlightTrack> flightsInCollision)
        {
            string flight1 = flightsInCollision.Item1.Tag;
            string flight2 = flightsInCollision.Item2.Tag;
            DateTime timeFlight = flightsInCollision.Item2.LatestTime;
            
            Console.WriteLine("Warning, two planes are currently on collision course! \n Plane Tag: {0}, Plane Tag: {1} and Time: {2}\n", flight1, flight2, timeFlight);
        }
    }
}

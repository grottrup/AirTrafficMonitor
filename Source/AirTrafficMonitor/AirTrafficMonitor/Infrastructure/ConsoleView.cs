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
            string flight1 = flightsInCollision.ToString();
            string flight2 = flightsInCollision.ToString();
            
            Console.WriteLine($"Warning, two planes are currently on collision course! \n Plane Tag: {flight1} and plane Tag: {flight2}\n");
        }
    }
}

using AirTrafficMonitor.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using AirTrafficMonitor.Utilities;

namespace AirTrafficMonitor.Infrastructure
{
    public class ConsoleView : IView
    {
        private ISeperationHandler _handler;


        public ConsoleView(ISeperationHandler handler)
        {
            _handler = handler;
            _handler.FlightsInProximity += FlightsInCollision; //FlightInProximity event
        }
        
        private void FlightsInCollision(object sender, FlightInProximityEventArgs e) //FlightInProximity event
        {
              this.RenderCollision(e.ProximityList);
            
            
        }

        //public void DelayTimer()

        //public void Render(FlightTrack track)
        //{
        //}

        

        public void Render(Tuple<IFlightTrack> track)
        {
            string flight1Tag = track.Item1.Tag;
            DateTime flight1Time = track.Item1.LatestTime;
            double flight1Nav = track.Item1.NavigationCourse;
            int flight1Lat = track.Item1.Position.Latitude;
            int flight1Lon = track.Item1.Position.Longitude;
            int flight1Alt = track.Item1.Position.Altitude;
            
            Console.WriteLine("Tag: {0}, Time: {1}, NavigationCourse: {2}, Latitude: {3}, Longitude: {4}, Altitude: {5}\n", flight1Tag, flight1Time, flight1Nav, flight1Lat, flight1Lon, flight1Alt); 
        }

        public void RenderCollision(Tuple<IFlightTrack, IFlightTrack> flightsInCollision)
        {
            string flight1 = flightsInCollision.Item1.Tag;
            string flight2 = flightsInCollision.Item2.Tag;
            DateTime timeFlight = flightsInCollision.Item2.LatestTime;
            
            Console.WriteLine("Warning, two planes are currently on collision course! \n Plane Tag: {0}, Plane Tag: {1} and Time: {2}\n", flight1, flight2, timeFlight);
        }

        public void RenderWithGreenTillTimerEnds(string renderstr)
        {
        
           // Console.ForegroundColor = ConsoleColor.Green;
       
            Console.WriteLine(renderstr, Console.ForegroundColor = ConsoleColor.Green);

            var timer = new EventTimer(5000);


        }

        public void RenderWithRedTillTimerEnds(string renderstr)
        {

            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(renderstr, Console.ForegroundColor = ConsoleColor.Red);

            var timer = new EventTimer(5000);

        }
    }
}

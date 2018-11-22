using AirTrafficMonitor.Domain;
using System;
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
        private ICollection<Tuple<string, ConsoleColor>> _thingsToRender;
        private IConsole _console;

        public ConsoleView(IConsole console)
        {
            _console = console;
            _thingsToRender = new List<Tuple<string, ConsoleColor>>();
        }
        
        public void Render(Tuple<IFlightTrack> track)
        {
            string flight1Tag = track.Item1.Tag;
            DateTime flight1Time = track.Item1.LatestTime;
            double flight1Nav = track.Item1.NavigationCourse;
            int flight1Lat = track.Item1.Position.Latitude;
            int flight1Lon = track.Item1.Position.Longitude;
            int flight1Alt = track.Item1.Position.Altitude;
            double flight1Vel = track.Item1.Velocity;
            
            Console.WriteLine("Tag: {0}, Time: {1}, NavigationCourse: {2}, Latitude: {3}, Longitude: {4}, Altitude: {5}, Velocity: {6}\n", flight1Tag, flight1Time, flight1Nav, flight1Lat, flight1Lon, flight1Alt, flight1Vel); 
        }

        public void RenderCollision(Tuple<IFlightTrack, IFlightTrack> flightsInCollision)
        {
            string flight1 = flightsInCollision.Item1.Tag;
            string flight2 = flightsInCollision.Item2.Tag;
            DateTime timeFlight = flightsInCollision.Item2.LatestTime;
            
            Console.WriteLine("Warning, two planes are currently on collision course! \n Plane Tag: {0}, Plane Tag: {1} and Time: {2}\n", flight1, flight2, timeFlight);
        }

        public void RenderWithGreenTillTimerEnds(IFlightTrack track)
        {
        
            Console.WriteLine("Flight: " + track.Tag + " left airspace at: " + track.LatestTime + "", Console.ForegroundColor = ConsoleColor.Green);

            var timer = new StringEventTimer(5000, "");
        }

        public void AddToRenderWithColor(string toRender, ConsoleColor color)
        {
            _thingsToRender.Add(new Tuple<string, ConsoleColor>(toRender, color));
            RenderWithColor(color);
        }

        public void RenderWithColor(ConsoleColor color)
        {
            _console.Clear();
            lock (_thingsToRender)
            {
                foreach (var renderThis in _thingsToRender)
                {
                    Console.WriteLine(renderThis.Item1, Console.ForegroundColor = renderThis.Item2);
                }
            }
        }

        public void RemoveFromRender(string preciseStringToRemove)
        {
            lock (_thingsToRender)
            {
                foreach (var renderThis in _thingsToRender)
                {
                    if (renderThis.Item1.Equals(preciseStringToRemove))
                    {
                        _thingsToRender.Remove(renderThis);
                        break;
                    }
                }
            }
            RenderWithColor(ConsoleColor.Gray);
        }
    }
}

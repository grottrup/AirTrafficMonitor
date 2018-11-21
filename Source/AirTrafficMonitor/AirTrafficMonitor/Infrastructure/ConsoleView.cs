using AirTrafficMonitor.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using AirTrafficMonitor.Utilities;

namespace AirTrafficMonitor.Infrastructure
{
    public class ConsoleView : IView
    {
        
        //private int _lineNumber;
        //private void WriteLine(string message, [CallerLineNumber] int lineNumber = 0)
        //{
        //    Console.WriteLine(message);
        //    _lineNumber = lineNumber;
        //}
        public static void WriteAt(int left, int top, string s)
        {
            int currentLeft = Console.CursorLeft;
            int currentTop = Console.CursorTop;
            Console.CursorVisible = false;//Hide cursor
            Console.SetCursorPosition(left, top);
            Console.Write(s);
            Console.SetCursorPosition(currentLeft, currentTop);
            Console.CursorVisible = true;//Show cursor back
        }
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

        public void RenderWithGreenTillTimerEnds(string renderstr)
        {
        
           // Console.ForegroundColor = ConsoleColor.Green;
       
            Console.WriteLine(renderstr, Console.ForegroundColor = ConsoleColor.Green);
            //WriteAt(0,3,renderstr);
            var timer = new EventTimer(5000);


        }

        public void RenderWithRedTillTimerEnds(string renderstr)
        {

            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(renderstr, Console.ForegroundColor = ConsoleColor.Red);
           // WriteAt(0,0,renderstr);
           var timer = new EventTimer(5000);

        }
    }
}

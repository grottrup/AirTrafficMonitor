using AirTrafficMonitor.Domain;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using AirTrafficMonitor.Utilities;

namespace AirTrafficMonitor.Infrastructure
{
    public class ConsoleView : IView
    {
        public void DelayTimer()
        {
            Task.Delay(5000);
        }

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

        public void RenderWithGreenTillTimerEnds(string renderstr, ITimer timer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(renderstr);

            //timer.WaitTimer();

            
            Console.ResetColor();

        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public async void RenderWithRedTillTimerEnds(string renderstr, ITimer timer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(renderstr);

            //var startTime = System.DateTime.Now;
            //while (startTime < startTime.Add(new TimeSpan(0,0,5)))
            //{

            //}
            //await Task.Delay(5000);
            //timer.WaitTimer();
            //timer.WaitFive();
            //Console.ResetColor();
           // Thread.Sleep(5000);
            //timer.Interval = 5;
            //timer.Start();  

            //ClearCurrentConsoleLine();
            //Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ResetColor();
        }
    }
}

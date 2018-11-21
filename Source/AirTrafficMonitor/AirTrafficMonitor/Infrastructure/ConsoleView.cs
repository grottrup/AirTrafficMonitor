using AirTrafficMonitor.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using AirTrafficMonitor.Utilities;
using AirTrafficMonitor.Infrastructure;

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

        public void DelayTimer()
        {
            Task.Delay(5000);
        }

        public void Render(FlightTrack track)
        {
            Console.WriteLine(track.ToString());
        }

        //public void RenderCollision(List<FlightTrack> ProximityList)
        public void RenderCollision(Tuple<FlightTrack, FlightTrack> ProximityList)
        {

            string flight1 = ProximityList.Item1.ToString();
            string flight2 = ProximityList.Item2.ToString();
            
            Console.WriteLine($"Warning, two planes are currently on collision course! \n Plane Tag: {flight1} and plane Tag: {flight2}\n");
        }

        public void RenderWithGreenTillTimerEnds(string renderstr, ITimer timer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(renderstr);

            //timer.WaitTimer();

            
            Console.ResetColor();

        }

        public async void RenderWithRedTillTimerEnds(string renderstr, ITimer timer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(renderstr);

            //var startTime = System.DateTime.Now;
            //while (startTime < startTime.Add(new TimeSpan(0,0,5)))
            //{

            //}
            await Task.Delay(5000);
            //timer.WaitTimer();

            //Console.ResetColor();

            //timer.Interval = 5;
            //timer.Start();  

            Console.ResetColor();
        }
    }
}

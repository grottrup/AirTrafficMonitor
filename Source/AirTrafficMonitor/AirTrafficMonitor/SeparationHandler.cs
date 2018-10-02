using System;
using System.Collections.Generic;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor
{
    public class SeparationHandler : ISeperationHandler
    {

        public event EventHandler SeparationEvent;

        public int VertDist = 300;
        public int HoriDist = 5000;
        //public SubscribePls = new AirTrafficMonitor.Observer;
        //public void Update(FlightRecord update)
        //{
          
           
        //}

        public void DetectCollision(List<FlightTrack> tracks)
        {
            foreach (var flights in tracks)
            {
                
            }
        }
    }
}

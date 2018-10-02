
using System;
using System.Collections.Generic;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor.Observer
{
    public class SeparationHandler
    {

        public event EventHandler SeparationEvent;

        public int VertDist = 300;
        public int HoriDist = 5000;
        //public SubscribePls = new AirTrafficMonitor.Observer;
        //public void Update(AirTrafficRecord update)
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

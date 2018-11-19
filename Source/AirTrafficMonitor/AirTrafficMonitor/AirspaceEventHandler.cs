using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using Timer = System.Threading.Timer;


namespace AirTrafficMonitor
{
    public class AirspaceEventHandler
    {
        private readonly ITimer _timer;
        private readonly List<FlightTrack> _track;
        private readonly IFlightObserver _observerEvents;
        private IView _view;

        public AirspaceEventHandler(ITimer timer, IFlightObserver observerEvents, IView view) 
        {
            _observerEvents = observerEvents;
            _view = view;
            _observerEvents.EnteredAirspace += EnterAirspaceEvent;
            _observerEvents.LeftAirspace += LeftAirspaceEvent;
            _timer = timer;
            _track = new List<FlightTrack>();   
        }

        public void EnterAirspaceEvent(object sender,FlightTrackEventArgs e)
        {
                var flightUpdate = e.FlightTrack;
                _view.RenderWithRedTillTimerEnds("Flight "+flightUpdate.Tag+" entered airspace at"+flightUpdate.LatestTime+"",_timer);
              
        }

        public void LeftAirspaceEvent(object sender, FlightTrackEventArgs e)
        {
            var flightUpdate = e.FlightTrack;
            _view.RenderWithGreenTillTimerEnds("Flight "+flightUpdate.Tag+" left airspace at"+flightUpdate.LatestTime+"",_timer);
        }
    }
}
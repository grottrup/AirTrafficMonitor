using System;
using System.Timers;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;
using Microsoft.Win32;

namespace AirTrafficMonitor.Infrastructure
{
    public class AirspaceEventHandler
    {
        private readonly IFlightObserver _flightsInAirspaceSubject;
        private IView _view;

        public AirspaceEventHandler(IFlightObserver flightsInAirspaceSubject, IView view)
        {
            _flightsInAirspaceSubject = flightsInAirspaceSubject;
            _view = view;
            _flightsInAirspaceSubject.EnteredAirspace += EnterAirspaceEvent;
            _flightsInAirspaceSubject.LeftAirspace += LeftAirspaceEvent;

        }

        private void EnterAirspaceEvent(object sender, FlightTrackEventArgs e)
        {

            var flightUpdate = e.FlightTrack;
            var renderStr = "Flight: " + flightUpdate.Tag + " entered airspace at: " + flightUpdate.LatestTime;
            _view.AddToRenderWithColor(renderStr, ConsoleColor.Cyan);
            var timer = new StringEventTimer(5000, renderStr); //_view.RemoveFromRender(renderStr);
            timer.Elapsed += StopShowingAirspaceEvent;
        }

        protected virtual void StopShowingAirspaceEvent(object sender, ElapsedEventArgsWithString e)
        {
            _view.RemoveFromRender(e.StringToHandle);
        }

        private void LeftAirspaceEvent(object sender, FlightTrackEventArgs e)
        {
            var flightUpdate = e.FlightTrack;
            var renderStr = "Flight: " + flightUpdate.Tag + " left airspace at: " + flightUpdate.LatestTime;
            _view.AddToRenderWithColor(renderStr, ConsoleColor.Green);
            var timer = new StringEventTimer(5000, renderStr); //_view.RemoveFromRender(renderStr);
            timer.Elapsed += StopShowingAirspaceEvent;
        }
    }
}
using System;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;

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
            _view.AddToRenderWithColor(renderStr, ConsoleColor.Red);
            var timer = new EventTimer(5000);
            timer.Elapsed += _view.RemoveFromView(renderStr);
        }

        private void LeftAirspaceEvent(object sender, FlightTrackEventArgs e)
        {
            var flightUpdate = e.FlightTrack;
            _view.RenderWithGreenTillTimerEnds(flightUpdate);
        }
    }
}
﻿using System;
using System.Timers;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Utilities;
using Microsoft.Win32;

namespace AirTrafficMonitor.Infrastructure
{
    public class AirspaceEventHandler
    {
        private readonly IFlightObserver _flightsInAirspaceSubject;
        private readonly ISeperationHandler _seperationHandler;
        private IView _view;
        private ILogger _logger;

        public AirspaceEventHandler(IFlightObserver flightsInAirspaceSubject, IView view, ILogger logger)
        {
            _flightsInAirspaceSubject = flightsInAirspaceSubject;
            _view = view;
            _flightsInAirspaceSubject.EnteredAirspace += EnterAirspaceEvent;
            _flightsInAirspaceSubject.LeftAirspace += LeftAirspaceEvent;
            _seperationHandler.FlightsInProximity += RenderDangerOfProximity;
        }

        private void RenderDangerOfProximity(object sender, FlightInProximityEventArgs e) //FlightInProximity event
        {
            _view.AddToRenderWithColor($"Danger! Proximity of {e.proximityTracks.Item1.Tag} and {e.proximityTracks.Item2.Tag}", ConsoleColor.Red);
            _logger.DataLog(e.proximityTracks);
        }

        private void EnterAirspaceEvent(object sender, FlightTrackEventArgs e)
        {

            var flightUpdate = e.FlightTrack;
            var renderStr = "Flight: " + flightUpdate.Tag + " entered airspace at: " + flightUpdate.LatestTime;
            _view.AddToRenderWithColor(renderStr, ConsoleColor.Cyan);
            var timer = new StringEventTimer(5000, renderStr);
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
            var timer = new StringEventTimer(5000, renderStr);
            timer.Elapsed += StopShowingAirspaceEvent;
        }
    }
}
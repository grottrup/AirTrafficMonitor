using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.Util;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor.Infrastructure
{
    public class FlightObserver : IFlightObserver
    {
        private readonly List<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ISeperationHandler _handler;
        private readonly Airspace _monitoredAirspace;
        private IFlightRecordReceiver _recordReceiver;

        public FlightObserver(Airspace airspace, IFlightRecordReceiver recordReceiver, IView view, ISeperationHandler handler)
        {
            _recordReceiver = recordReceiver;
            _recordReceiver.FlightRecordReceived += UpdateFlightTracks;
            _view = view;
            _handler = handler;
            _tracks = new List<FlightTrack>();
            _monitoredAirspace = airspace;
        }

        private void UpdateFlightTracks(object sender, FlightRecordEventArgs e)
        {
            var flightUpdate = e.FlightRecord;
            if (flightUpdate.Position.IsWithin(_monitoredAirspace))
            {
                var updatedTrack = _tracks.SortRecordByTag(flightUpdate);
                _handler.DetectCollision(_tracks);
                _view.Render(updatedTrack);
            }
        }
    }
}
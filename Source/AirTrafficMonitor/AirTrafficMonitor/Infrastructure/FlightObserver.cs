using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.Util;

namespace AirTrafficMonitor.View
{
    public class FlightObserver
    {
        private readonly List<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ISeperationHandler _handler;
        private readonly Airspace _space;
        private IFlightRecordReceiver _recordReceiver;

        public FlightObserver(IFlightRecordReceiver recordReceiver, IView view, ISeperationHandler handler)
        {
            _recordReceiver = recordReceiver;
            _recordReceiver.FlightRecordReceived += UpdateFlightTracks;
            _view = view;
            _handler = handler;
            _tracks = new List<FlightTrack>();
            _space = new Airspace();
        }

        private void UpdateFlightTracks(object sender, FlightRecordEventArgs e)
        {
            var flightUpdate = e.FlightRecord;
            if (flightUpdate.Position.IsWithin(_space))
            {
                _tracks.SortRecordByTag(flightUpdate);
                _handler.DetectCollision(_tracks);
                _view.Render(flightUpdate);
            }
        }
    }
}
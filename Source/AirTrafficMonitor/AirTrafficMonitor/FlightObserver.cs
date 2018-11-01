using System.Collections.Generic;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Util;

namespace AirTrafficMonitor
{
    public class FlightObserver
    {
        private readonly ICollection<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ISeperationHandler _handler;
        private readonly IFlightRecordReceiver _recordReceiver;
        private readonly Airspace _monitoredAirspace;

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
                _handler.DetectCollision(_tracks as List<FlightTrack>); // TODO: Handler needs to be more implementation agnostic
                _view.Render(updatedTrack);
            }
        }
    }
}
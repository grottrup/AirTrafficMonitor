using System;
using System.Collections.Generic;
using System.Linq;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NPlant.MetaModel.ClassDiagraming;

namespace AirTrafficMonitor
{
    public class FlightObserver : IFlightObserver
    {
        private readonly ICollection<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ILogger _logger;
        private readonly ISeperationHandler _handler;
        private readonly IFlightRecordReceiver _recordReceiver;
        private readonly Airspace _monitoredAirspace;
        public event EventHandler<FlightTrackEventArgs> EnteredAirspace;
        public event EventHandler<FlightTrackEventArgs> LeftAirspace;
     
        public FlightObserver(Airspace monitoredAirspace, IFlightRecordReceiver recordReceiver, IView view, ISeperationHandler handler, ILogger logger)
        {

            _recordReceiver = recordReceiver;
            _recordReceiver.FlightRecordReceived += UpdateFlightTracks;
            _logger = logger;
            _view = view;
            _handler = handler;
            _tracks = new List<FlightTrack>();
            _monitoredAirspace = monitoredAirspace;
        }

        private void UpdateFlightTracks(object sender, FlightRecordEventArgs e)
        {
            var flightUpdate = e.FlightRecord;
            if (flightUpdate.Position.IsWithin(_monitoredAirspace))
            {
                var updatedTrack = _tracks.SortRecordByTag(flightUpdate);
                var newTrack = _tracks.Any(t => t.Tag == flightUpdate.Tag);
                if (newTrack) // not in list yet
                {
                    var args = new FlightTrackEventArgs(updatedTrack);
                 EnteredAirspace?.Invoke(this, args);
                }
                _handler.DetectCollision(_tracks as List<FlightTrack>); // TODO: Handler needs to be more implementation agnostic
                _view.Render(updatedTrack);
                // TODO... logger?
            }
            else
            {

                var leftAirspaceTrack = _tracks.FirstOrDefault(t => t.Tag == flightUpdate.Tag);
                var leftairspacetrue = _tracks.Any(t => t.Tag == flightUpdate.Tag);
                if (leftairspacetrue) // in list
                {
                    
                    var args = new FlightTrackEventArgs(leftAirspaceTrack);
                    LeftAirspace?.Invoke(this, args);

                    _tracks.Remove(leftAirspaceTrack);
                }
            }

        }
    }
}
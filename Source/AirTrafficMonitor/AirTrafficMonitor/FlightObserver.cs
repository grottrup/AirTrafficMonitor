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
        private readonly ICollection<IFlightTrack> _tracks;
        private readonly IView _view;
        private readonly ILogger _logger;
        private readonly ISeperationHandler _handler;
        private readonly IFlightRecordReceiver _recordReceiver;
        private readonly IAirspace _monitoredAirspace;
        public event EventHandler<FlightTrackEventArgs> EnteredAirspace;
        public event EventHandler<FlightTrackEventArgs> LeftAirspace;
     
        public FlightObserver(IAirspace monitoredAirspace, IFlightRecordReceiver recordReceiver, IView view, ISeperationHandler handler, ILogger logger)
        {

            _recordReceiver = recordReceiver;
            _recordReceiver.FlightRecordReceived += UpdateFlightTracks;
            _logger = logger;
            _view = view;
            _handler = handler;
            _tracks = new List<IFlightTrack>();
            _monitoredAirspace = monitoredAirspace;
        }

        private void UpdateFlightTracks(object sender, FlightRecordEventArgs e)
        {
            var flightUpdate = e.FlightRecord;
            if (_monitoredAirspace.HasPositionWithinBoundaries(flightUpdate.Position))
            {
                IFlightTrack updatedTrack;
                var existingTrack = _tracks.Any(t => t.Tag == flightUpdate.Tag);
                if (existingTrack) // already in list
                {
                    updatedTrack = _tracks.SortRecordByTag(flightUpdate);
                    //_view.Render(updatedTrack);
                }
                else  {
                    updatedTrack = _tracks.SortRecordByTag(flightUpdate);
                    var args = new FlightTrackEventArgs(updatedTrack);
                    EnteredAirspace?.Invoke(this, args);
                }
                _handler.DetectCollision(_tracks); // TODO: Handler needs to be more implementation agnostic                {
                
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
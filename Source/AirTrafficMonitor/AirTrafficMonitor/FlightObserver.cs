using System.Collections.Generic;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NPlant.MetaModel.ClassDiagraming;

namespace AirTrafficMonitor
{
    public class FlightObserver
    {
        private readonly ICollection<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ILogger _logger;
        private readonly ISeperationHandler _handler;
        private readonly IFlightRecordReceiver _recordReceiver;
        private readonly Airspace _monitoredAirspace;

        //added for AirspaceEventHandler
        private readonly AirspaceEventHandler _airspaceEvent = new AirspaceEventHandler();

        public FlightObserver(Airspace monitoredAirspace, IFlightRecordReceiver recordReceiver, IView view, ISeperationHandler handler, ILogger logger)
        {

            _recordReceiver = recordReceiver;
            _recordReceiver.FlightRecordReceived += UpdateFlightTracks;
            _recordReceiver.FlightRecordReceived += _airspaceEvent.AirspaceEvent; //AirspaceEventhandler
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
                _handler.DetectCollision(_tracks as List<FlightTrack>); // TODO: Handler needs to be more implementation agnostic
                _view.Render(updatedTrack);
                // TODO... logger?
            }
        }
    }
}
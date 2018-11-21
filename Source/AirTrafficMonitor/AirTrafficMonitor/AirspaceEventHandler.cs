using AirTrafficMonitor.Infrastructure;

namespace AirTrafficMonitor
{
    public class AirspaceEventHandler
    {
        private readonly IFlightObserver _flightInAirspaceSubject;
        private IView _view;

        public AirspaceEventHandler(IFlightObserver flightInAirspaceSubject, IView view) 
        {
            _flightInAirspaceSubject = flightInAirspaceSubject;
            _view = view;
            _flightInAirspaceSubject.EnteredAirspace += EnterAirspaceEvent;
            _flightInAirspaceSubject.LeftAirspace += LeftAirspaceEvent;
        }

        private void EnterAirspaceEvent(object sender,FlightTrackEventArgs e)
        {
                var flightUpdate = e.FlightTrack;
                _view.RenderWithRedTillTimerEnds("Flight "+flightUpdate.Tag+" entered airspace at"+flightUpdate.LatestTime+"");
              
        }

        private void LeftAirspaceEvent(object sender, FlightTrackEventArgs e)
        {
            var flightUpdate = e.FlightTrack;
            _view.RenderWithGreenTillTimerEnds("Flight "+flightUpdate.Tag+" left airspace at"+flightUpdate.LatestTime+"");
        }
    }
}
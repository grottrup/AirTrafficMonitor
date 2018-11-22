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

        private void EnterAirspaceEvent(object sender,FlightTrackEventArgs e)
        {
                var flightUpdate = e.FlightTrack;
                _view.RenderWithRedTillTimerEnds("Flight: "+flightUpdate.Tag+" entered airspace at: "+flightUpdate.LatestTime+"");
              
        }

        private void LeftAirspaceEvent(object sender, FlightTrackEventArgs e)
        {
            var flightUpdate = e.FlightTrack;
            _view.RenderWithGreenTillTimerEnds("Flight: "+flightUpdate.Tag+" left airspace at: "+flightUpdate.LatestTime+"");
        }
    }
}
using System;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor
{
    public class AirTrafficObserver : Observer.IObserver<AirTrafficTrack>
    {
        private readonly IView _view;

        public AirTrafficObserver(IView view)
        {
            _view = view;
        }

        public void Update(AirTrafficTrack update)
        {
            _view.Render(update);
        }
    }
}
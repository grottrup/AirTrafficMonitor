using System;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor
{
    public class AirTrafficObserver : Observer.IObserver<AirTrafficRecord>
    {
        private readonly IView _view;

        public AirTrafficObserver(IView view)
        {
            _view = view;
        }

        public void Update(AirTrafficRecord update)
        {
            _view.Render(update);
        }
    }
}
using System;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor
{
    public class AirTrafficObserver : Observer.IObserver<AirTrafficReport>
    {
        private readonly IView _view;

        public AirTrafficObserver(IView view)
        {
            _view = view;
        }

        public void Update(AirTrafficReport update)
        {
            _view.Display(update);
        }
    }
}
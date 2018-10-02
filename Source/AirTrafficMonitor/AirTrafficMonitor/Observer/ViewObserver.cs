using System;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor
{
    public class ViewObserver : Observer.IObserver<AirTrafficRecord>
    {
        private readonly IView _view;

        public ViewObserver(IView view)
        {
            _view = view;
        }

        public void Update(AirTrafficRecord update)
        {
            _view.Render(update);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using AirTrafficMonitor.Observer.AntiCorruptionLayer;

namespace AirTrafficMonitor.Observer
{
    public class AirTrafficSubject : IObservable<AirTraffic>
    {
        private readonly IRawDataController _controller;
        private readonly List<IObserver<AirTraffic>> _observers;

        public AirTrafficSubject(IRawDataController controller)
        {
            _controller = controller;
            _observers = new List<IObserver<AirTraffic>>();
        }

        public IDisposable Subscribe(IObserver<AirTraffic> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            throw new NotImplementedException();
        }
    }
}
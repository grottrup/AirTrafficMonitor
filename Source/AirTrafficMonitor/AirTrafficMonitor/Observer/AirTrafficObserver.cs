using System;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor
{
    public class AirTrafficObserver : IObserver<AirTraffic>
    {
        public void OnNext(AirTraffic value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
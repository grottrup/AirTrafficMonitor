using System;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor
{
    public class AirTrafficObserver : IObserver<AirTrafficReport>
    {
        public void OnNext(AirTrafficReport value)
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
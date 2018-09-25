using System;

namespace AirTrafficMonitor
{
    public class TransponderReceiverData : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            throw new NotImplementedException();
        }
    }
}

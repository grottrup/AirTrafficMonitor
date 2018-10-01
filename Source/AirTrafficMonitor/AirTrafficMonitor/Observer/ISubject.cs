using System;

namespace AirTrafficMonitor.Observer
{
    public interface ISubject<T>
    {
        void Subscribe(System.IObserver<T> observer);
        void Unsubscribe(System.IObserver<T> observer);
    }
}
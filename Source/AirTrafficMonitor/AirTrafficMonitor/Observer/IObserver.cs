namespace AirTrafficMonitor.Observer
{
    public interface IObserver<T>
    {
        void Update(T update);

    }
}
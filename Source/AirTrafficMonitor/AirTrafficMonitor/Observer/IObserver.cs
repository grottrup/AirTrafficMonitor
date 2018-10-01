namespace AirTrafficMonitor
{
    public interface IObserver<T>
    {
        void Update(T update);

    }
}
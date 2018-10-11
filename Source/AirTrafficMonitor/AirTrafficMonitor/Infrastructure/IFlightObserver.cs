namespace AirTrafficMonitor.Observer
{
    public interface IFlightObserver<T>
    {
        void Update(T flightUpdate);
    }
}
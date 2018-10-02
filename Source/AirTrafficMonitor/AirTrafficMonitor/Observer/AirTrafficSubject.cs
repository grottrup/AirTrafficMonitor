using System;
using System.Collections;
using System.Collections.Generic;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer
{
    public class AirTrafficSubject : ISubject<FlightRecord>
    {
        private readonly List<IObserver<FlightRecord>> _observers;
        private readonly ITransponderReceiver _receiver;

        public AirTrafficSubject()
        {
            _observers = new List<IObserver<FlightRecord>>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
            StartReceivingTransponderData();
        }

        public void Subscribe(IObserver<FlightRecord> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver<FlightRecord> observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(FlightRecord record)
        {
            _observers.ForEach(o => o.Update(record));
        }


        private void StartReceivingTransponderData()
        {
            _receiver.TransponderDataReady += RawDataReceivedEvent;
        }

        private void RawDataReceivedEvent(object sender, RawTransponderDataEventArgs e)
        {
            var rawDataList = e.TransponderData;
            foreach (var rawData in rawDataList)
            {
                Notify(new FlightRecord(rawData)); // replace with a factory and make an abstraction of the FlightRecord class
            }
        }
    }
}
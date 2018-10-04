using System;
using System.Collections;
using System.Collections.Generic;
using AirTrafficMonitor.Domain;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer
{
    public class FlightSubject : ISubject<FlightRecord>
    {
        private readonly List<IObserver<FlightRecord>> _observers;
        private readonly ITransponderReceiver _receiver;
        private FlightRecordFactory _factory;

        public FlightSubject()
        {
            _observers = new List<IObserver<FlightRecord>>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
            _factory = new FlightRecordFactory();
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
                var record = _factory.CreateRecord(rawData);
                Notify(record); // replace with a factory and make an abstraction of the FlightRecord class
            }
        }
    }
}
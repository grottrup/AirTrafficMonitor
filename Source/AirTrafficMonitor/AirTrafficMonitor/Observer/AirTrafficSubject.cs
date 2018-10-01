using System;
using System.Collections;
using System.Collections.Generic;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer
{
    public class AirTrafficSubject : ISubject<AirTrafficRecord>
    {
        private readonly List<IObserver<AirTrafficRecord>> _observers;
        private readonly ITransponderReceiver _receiver;

        public AirTrafficSubject()
        {
            _observers = new List<IObserver<AirTrafficRecord>>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
            StartReceivingTransponderData();
        }

        public void Subscribe(IObserver<AirTrafficRecord> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver<AirTrafficRecord> observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(AirTrafficRecord record)
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
                Notify(new AirTrafficRecord(rawData)); // replace with a factory and make an abstraction of the AirTrafficRecord class
            }
        }
    }
}
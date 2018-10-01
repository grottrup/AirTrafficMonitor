using System;
using System.Collections;
using System.Collections.Generic;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer
{
    public class AirTrafficSubject : ISubject<AirTrafficReport>
    {
        private readonly List<System.IObserver<AirTrafficReport>> _observers;
        private readonly ITransponderReceiver _receiver;

        public AirTrafficSubject()
        {
            _observers = new List<System.IObserver<AirTrafficReport>>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
        }

        public void Subscribe(System.IObserver<AirTrafficReport> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(System.IObserver<AirTrafficReport> observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(AirTrafficReport report)
        {
            _observers.ForEach(o => o.OnNext(report));
        }


        public void StartReceivingTransponderData()
        {
            _receiver.TransponderDataReady += RawDataReceivedEvent;
        }

        private void RawDataReceivedEvent(object sender, RawTransponderDataEventArgs e)
        {
            var rawDataList = e.TransponderData;
            foreach (var rawData in rawDataList)
            {
                Notify(new AirTrafficReport(rawData)); // replace with a factory and make an abstraction of the AirTrafficReport class
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer
{
    public class AirTrafficSubject : IObservable<AirTrafficReport>
    {
        private readonly List<IObserver<AirTrafficReport>> _observers;

        public AirTrafficSubject()
        {
            _observers = new List<IObserver<AirTrafficReport>>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
        }

        public IDisposable Subscribe(IObserver<AirTrafficReport> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            throw new NotImplementedException();
        }

        private void Notify(AirTrafficReport airTrafficReportReport)
        {
            _observers.ForEach(o => o.OnNext(airTrafficReportReport));
        }

        private readonly ITransponderReceiver _receiver;

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
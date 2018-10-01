using System;
using System.Collections;
using System.Collections.Generic;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer
{
    public class AirTrafficSubject : ISubject<AirTrafficTrack>
    {
        private readonly List<IObserver<AirTrafficTrack>> _observers;
        private readonly ITransponderReceiver _receiver;

        public AirTrafficSubject()
        {
            _observers = new List<IObserver<AirTrafficTrack>>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
            StartReceivingTransponderData();
        }

        public void Subscribe(IObserver<AirTrafficTrack> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver<AirTrafficTrack> observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(AirTrafficTrack track)
        {
            _observers.ForEach(o => o.Update(track));
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
                Notify(new AirTrafficTrack(rawData)); // replace with a factory and make an abstraction of the AirTrafficTrack class
            }
        }
    }
}
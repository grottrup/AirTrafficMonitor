using System;
using AirTrafficMonitor.Domain;
using TransponderReceiver;

namespace AirTrafficMonitor.AntiCorruptionLayer
{
    public class FlightRecordReceiver : IFlightRecordReceiver
    {
        private readonly ITransponderReceiver _receiver;
        private FlightRecordFactory _factory;

        public event EventHandler<FlightRecordEventArgs> FlightRecordReceived;

        public FlightRecordReceiver()
        {
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            _receiver.TransponderDataReady += RawDataReceived;
            _factory = new FlightRecordFactory();
        }

        private void RawDataReceived(object sender, RawTransponderDataEventArgs e)
        {
            var rawDataList = e.TransponderData;
            foreach (var rawData in rawDataList)
            {
                var record = _factory.CreateRecord(rawData);
                FlightRecordEventArgs args = new FlightRecordEventArgs(record);
                FlightRecordReceived(this, args);
            }
        }
    }
}
//TODO: Mock ITransponderReceiver ud
//TODO: 
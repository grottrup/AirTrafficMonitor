using System;
using AirTrafficMonitor.Domain;
using TransponderReceiver;

namespace AirTrafficMonitor.AntiCorruptionLayer
{
    public class FlightRecordReceiver : IFlightRecordReceiver
    {
        private readonly ITransponderReceiver _receiver;
        private IFlightRecordFactory _flightRecordFactory;

        public event EventHandler<FlightRecordEventArgs> FlightRecordReceived;

        public FlightRecordReceiver(ITransponderReceiver transponderReceiver, IFlightRecordFactory flightRecordFlightRecordFactory)
        {
            _receiver = transponderReceiver;
            _receiver.TransponderDataReady += RawDataReceived;
            _flightRecordFactory = flightRecordFlightRecordFactory;
        }

        private void RawDataReceived(object sender, RawTransponderDataEventArgs e)
        {
            var rawDataList = e.TransponderData;
            foreach (var rawData in rawDataList)
            {
                var record = _flightRecordFactory.CreateRecord(rawData);
                FlightRecordEventArgs args = new FlightRecordEventArgs(record);
                FlightRecordReceived(this, args);
            }
        }
    }
}
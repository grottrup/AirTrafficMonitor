using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitor.Observer.AntiCorruptionLayer
{
    public interface IRawDataController
    {
    }

    public class RawDataController : IRawDataController
    {
        private readonly ITransponderReceiver _receiver;
        public List<string> RawDataList { get; } //remake so that you return object instad of a list of data

        public RawDataController()
        {
            RawDataList = new List<string>();
            _receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();//dependency inject instead maybe
        }

        public void StartReceivingTransponderData()
        {
            _receiver.TransponderDataReady += RawDataReceivedEvent;
        }

        private void RawDataReceivedEvent(object sender, RawTransponderDataEventArgs e)
        {
            var rawDataList = e.TransponderData;
            foreach (var item in rawDataList)
            {
                RawDataList.Add(item);
            }
        }
    }
}

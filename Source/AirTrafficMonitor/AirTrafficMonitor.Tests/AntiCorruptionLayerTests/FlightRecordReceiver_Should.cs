using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitor.Tests.AntiCorruptionLayerTests
{
    [TestFixture]
    public class FlightRecordReceiver_Should
    {
        private FlightRecordReceiver _sut;
        private FlightRecordFactory _ssut_flightRecordFactory;
        private ITransponderReceiver _fakeTransponder;

        [SetUp]
        public void SetUp()
        {
            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            _ssut_flightRecordFactory = new FlightRecordFactory();
            _sut = new FlightRecordReceiver(_fakeTransponder, _ssut_flightRecordFactory);
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975")]
        public void RaiseEventWithFlightRecord(string rawData)
        {
            var transponderData = new List<string>();
            transponderData.Add(rawData);
            _fakeTransponder.TransponderDataReady += Raise.EventWith(_fakeTransponder, new RawTransponderDataEventArgs(transponderData));

            EventHandler<FlightRecordEventArgs> sut_event = (sender, e) =>
            {
                var expectedFlightRecord = new FlightRecord();
                Assert.That(e.FlightRecord.Tag, Is.Not.Null);
                Assert.That(e.FlightRecord.Tag, Is.EqualTo("fail"));
                Assert.That(e.FlightRecord.Tag, Is.EqualTo(expectedFlightRecord.Tag));
            };
        }
    }
}
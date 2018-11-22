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
        private IFlightRecordFactory _fakeFlightRecordFactory;
        private ITransponderReceiver _fakeTransponder;

        [SetUp]
        public void SetUp()
        {
            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            _fakeFlightRecordFactory = Substitute.For<IFlightRecordFactory>();
            _sut = new FlightRecordReceiver(_fakeTransponder, _fakeFlightRecordFactory);
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975")]
        public void WhenRaisingTransponderDataReady_CallCreateRecord(string rawData)
        {
            // ARRANGE
            var transponderData = new List<string>();
            transponderData.Add(rawData);

            FlightRecord persistedArgs = null;
            var expectedFlightRecord = new FlightRecord();
            _sut.FlightRecordReceived += (sender, e) =>
            {
                persistedArgs = e.FlightRecord;
            };

            //ACT
            _fakeTransponder.TransponderDataReady += Raise.EventWith(_fakeTransponder, new RawTransponderDataEventArgs(transponderData));

            // ASSERT
            _fakeFlightRecordFactory.Received().CreateRecord(Arg.Any<string>());
        }
    }
}
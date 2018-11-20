using System.Collections.Generic;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitor.IntegrationTests.TopTests
{
    [TestFixture]
    public class FlightObserver_Integrating_FlightRecordReceiver_Should
    {
        private FlightRecordReceiver _ssut_flightRecordReceiver;
        private FlightObserver _sut;

        private ITransponderReceiver _fakeTransponder;

        [SetUp]
        public void SetUp()
        {
            var fakeView = Substitute.For<IView>();
            var fakeSeperation = Substitute.For<ISeperationHandler>();     
            var fakeLogger = Substitute.For<Infrastructure.ILogger>();
            var fakeMonitoredAirspace = Substitute.For<Airspace>();

            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            var _factory = new FlightRecordFactory();
            _ssut_flightRecordReceiver = new FlightRecordReceiver(_fakeTransponder, _factory);
            _sut = new FlightObserver(fakeMonitoredAirspace, _ssut_flightRecordReceiver, fakeView, fakeSeperation, fakeLogger);
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975", "AGJ063", 39563, 95000, 16800)]
        public void WhenRaisingTransponderDataReady_CreateRecordObject_ThatASubscriperCanReceive(string rawData, string expTag, int expLat, int expLong, int expAlt)
        {
            // ARRANGE
            var transponderData = new List<string>();
            transponderData.Add(rawData);

            FlightTrack persistedArgs = null;
            _sut.EnteredAirspace += (sender, e) =>
            {
                persistedArgs = e.FlightTrack;
            };

            //ACT
            _fakeTransponder.TransponderDataReady += Raise.EventWith(_fakeTransponder, new RawTransponderDataEventArgs(transponderData));

            // ASSERT
            Assert.That(persistedArgs.Tag, Is.Not.Null);
            Assert.That(persistedArgs.Tag, Is.EqualTo(expTag));
            Assert.That(persistedArgs.Position.Altitude, Is.EqualTo(int.MaxValue));
        }
    }
}

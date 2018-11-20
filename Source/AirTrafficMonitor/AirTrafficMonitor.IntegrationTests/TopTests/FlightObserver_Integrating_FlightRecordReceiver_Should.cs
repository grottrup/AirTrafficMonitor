using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using NSubstitute;
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

        [SetUp]
        public void SetUp()
        {
            var fakeTransponder = Substitute.For<ITransponderReceiver>();

            var airspace = new Airspace();
            var factory = new FlightRecordFactory();
            var fakeView = Substitute.For<IView>();
            var fakeSeperation = Substitute.For<ISeperationHandler>();
     
            var fakeLogger = Substitute.For<Infrastructure.ILogger>();
            var fakeMonitoredAirspace = Substitute.For<Airspace>();

            _ssut_flightRecordReceiver = new FlightRecordReceiver(fakeTransponder, factory);
            _sut = new FlightObserver(fakeMonitoredAirspace, _ssut_flightRecordReceiver, fakeView, fakeSeperation, fakeLogger);
        }

        [Test]
        public void TriggerOnEventRaised()
        {

        }
    }
}

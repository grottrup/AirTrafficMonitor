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

namespace AirTrafficMonitor.IntegrationTests.TopDownTests
{
    [TestFixture]
    public class FlightObserver_Integrating_SeperationHandler_Should
    {
        //Confirmed from bottom up
        private FlightRecordReceiver _ssut_flightRecordReceiver;
        private Airspace _ssut_monitoredAirspace;
        private FlightObserver _sut;

        private ITransponderReceiver _fakeTransponder;
        private SeparationHandler _seperation;

        [SetUp]
        public void SetUp()
        {
            var fakeView = Substitute.For<IView>();
            var fakeLogger = Substitute.For<Infrastructure.ILogger>();
            _seperation = new SeparationHandler();

            var _factory = new FlightRecordFactory();
            _ssut_monitoredAirspace = new Airspace(90000, 10000, 20000, 500);
            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            _ssut_flightRecordReceiver = new FlightRecordReceiver(_fakeTransponder, _factory);
            _sut = new FlightObserver(_ssut_monitoredAirspace, _ssut_flightRecordReceiver, fakeView, _seperation);
        }

        [TestCase("AGJ063;12000;50000;16800;20181001160609975", "AGJ063", 39563, 95000, 16800)]
        public void WhenANewRecord_IsWithinAirspace_CallDetectCollision(string rawData, string expTag, int expLat, int expLong, int expAlt)
        {
            // ARRANGE
            var transponderData = new List<string>();
            transponderData.Add(rawData);

            _fakeTransponder.TransponderDataReady += Raise.EventWith(_fakeTransponder, new RawTransponderDataEventArgs(transponderData));

            _seperation.Received().DetectCollision(Arg.Any<ICollection<IFlightTrack>>());
        }
    }
}

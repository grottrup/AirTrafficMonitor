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

namespace AirTrafficMonitor.IntegrationTests.BottomUpTests
{
    /// <summary>
    /// Integration step 3
    /// </summary>
    [TestFixture]
    public class FlightObserver_Integrating_Airspace_Should
    {
        private FlightRecordReceiver _ssut_flightRecordReceiver;
        private Airspace _ssut_monitoredAirspace;
        private FlightObserver _sut;

        private ITransponderReceiver _fakeTransponder;

        [SetUp]
        public void SetUp()
        {
            var fakeView = Substitute.For<IView>();
            var fakeSeperation = Substitute.For<ISeperationHandler>();
            var fakeLogger = Substitute.For<Infrastructure.ILogger>();

            var _factory = new FlightRecordFactory();
            _ssut_monitoredAirspace = new Airspace(90000, 10000, 20000, 500);
            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            _ssut_flightRecordReceiver = new FlightRecordReceiver(_fakeTransponder, _factory);
            _sut = new FlightObserver(_ssut_monitoredAirspace, _ssut_flightRecordReceiver, fakeView, fakeSeperation, fakeLogger);
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975", "AGJ063", 39563, 95000, 16800)]
        public void Something(string rawData, string expTag, int expLat, int expLong, int expAlt)
        {
            
        }
    }
}

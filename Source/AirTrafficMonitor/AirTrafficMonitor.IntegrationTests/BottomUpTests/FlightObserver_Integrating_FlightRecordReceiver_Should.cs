using System;
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
    /// <summary>
    /// Integration step 2
    /// </summary>
    [TestFixture]
    public class FlightObserver_Integrating_FlightRecordReceiver_Should
    {
        private FlightRecordReceiver _ssut_flightRecordReceiver;
        private FlightObserver _sut;

        private ITransponderReceiver _fakeTransponder;
        private IAirspace _fakeMonitoredAirspace;

        [SetUp]
        public void SetUp()
        {
            var fakeView = Substitute.For<IView>();
            var fakeSeperation = Substitute.For<ISeperationHandler>();     
            var fakeLogger = Substitute.For<Infrastructure.ILogger>();

            var _factory = new FlightRecordFactory();
            _fakeMonitoredAirspace = Substitute.For<IAirspace>();
            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            _ssut_flightRecordReceiver = new FlightRecordReceiver(_fakeTransponder, _factory);
            _sut = new FlightObserver(_fakeMonitoredAirspace, _ssut_flightRecordReceiver, fakeView, fakeSeperation, fakeLogger);
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975", "AGJ063", 39563, 95000, 16800)]
        public void WhenRaisingTransponderDataReady_GivenFlightIsWithinAirspace_CreateFlightTrack_ThatASubscriperCanReceive(string rawData, string expTag, int expLat, int expLong, int expAlt)
        {
            // ARRANGE
            var transponderData = new List<string>();
            transponderData.Add(rawData);
            _fakeMonitoredAirspace.HasPositionWithinBoundaries(Arg.Any<Position>()).Returns(true);

            IFlightTrack persistedArgs = null;
            _sut.EnteredAirspace += (sender, e) =>
            {
                persistedArgs = e.FlightTrack;
            };

            //ACT
            _fakeTransponder.TransponderDataReady += Raise.EventWith(_fakeTransponder, new RawTransponderDataEventArgs(transponderData));

            // ASSERT
            Assert.That(persistedArgs.Tag, Is.Not.Null);
            Assert.That(persistedArgs.NavigationCourse, Is.EqualTo(double.NaN));
            Assert.That(persistedArgs.Velocity, Is.EqualTo(0));
            Assert.That(persistedArgs.LatestTime, Is.Not.EqualTo(DateTime.MinValue));

            Assert.That(persistedArgs.Tag, Is.EqualTo(expTag));
            Assert.That(persistedArgs.Position.Altitude, Is.EqualTo(expAlt));
            Assert.That(persistedArgs.Position.Latitude, Is.EqualTo(expLat));
            Assert.That(persistedArgs.Position.Longitude, Is.EqualTo(expLong));
        }
    }
}

using System;
using System.Collections.Generic;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class FlightObserver_Should
    {
        private IView _fakeView;
        private ISeperationHandler _fakeSeperation;
        private IFlightRecordReceiver _fakeFlight;
        private Infrastructure.FlightObserver _uut;
        private Airspace _fakeMonitoredAirspace;

        [SetUp]
        public void SetUp()
        {
            _fakeView = Substitute.For<IView>();
            _fakeSeperation = Substitute.For<ISeperationHandler>();
            _fakeFlight = Substitute.For<IFlightRecordReceiver>();
            _fakeMonitoredAirspace = Substitute.For<Airspace>();
            _uut = new Infrastructure.FlightObserver(_fakeMonitoredAirspace, _fakeFlight, _fakeView, _fakeSeperation);
        }

        [Test]
        public void Call_RenderAndCollisionDivider()
        {
            // Act
            var record = new FlightRecord()
            {
                Tag = "default",
                Position = new Position(20000, 20000, 19000),
                Timestamp = DateTime.MinValue
            };

            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));

            // Assert
            _fakeView.Received().Render(Arg.Any<FlightTrack>());
            _fakeSeperation.Received().DetectCollision(Arg.Any<List<FlightTrack>>());
        }

        [Test]
        public void RenderAllTracksWithinTheMonitoredAirSpace()
        {
        }

        [Test]
        public void Not_RenderAnyTracksOutsideTheMonitoredAirSpace()
        {

        }
    }
}

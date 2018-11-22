using System;
using System.Collections.Generic;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ILogger = AirTrafficMonitor.Infrastructure.ILogger;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class FlightObserver_Should
    {
        private IView _fakeView;
        private ILogger _fakeLogger;
        private ISeperationHandler _fakeSeperation;
        private IFlightRecordReceiver _fakeFlight;
        private FlightObserver _uut;
        private IAirspace _fakeMonitoredAirspace;

        [SetUp]
        public void SetUp()
        {
            _fakeView = Substitute.For<IView>();
            _fakeSeperation = Substitute.For<ISeperationHandler>();
            _fakeFlight = Substitute.For<IFlightRecordReceiver>();
            _fakeLogger = Substitute.For<ILogger>();
            _fakeMonitoredAirspace = Substitute.For<IAirspace>();
            _uut = new FlightObserver(_fakeMonitoredAirspace, _fakeFlight, _fakeView, _fakeSeperation, _fakeLogger);
        }

        [Test]
        public void Call_DetectCollision()
        {
            // Arrange
            _fakeMonitoredAirspace.HasPositionWithinBoundaries(Arg.Any<Position>()).Returns(true);

            // Act
            var record = new FlightRecord()
            {
                Tag = "test flight",
                Position = new Position(20000, 20000, 19000),
                Timestamp = DateTime.MinValue
            };

            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));

            // Assert
            _fakeSeperation.Received().DetectCollision(Arg.Any<ICollection<IFlightTrack>>());
        }

        [Test]
        public void RenderAnyTrackInTheMonitoredAirSpace()
        {
            _fakeMonitoredAirspace.HasPositionWithinBoundaries(Arg.Any<Position>()).Returns(true);

            var record = new FlightRecord()
            {
                Tag = "test flight",
                Position = new Position(20000, 20000, 19000),
                Timestamp = DateTime.MinValue
            };

            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));


            IFlightTrack persistedArg = null;
            _uut.LeftAirspace += (sender, e) => { persistedArg = e.FlightTrack; };

            _fakeMonitoredAirspace.HasPositionWithinBoundaries(Arg.Any<Position>()).Returns(false);
            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));

            Assert.That(persistedArg, Is.Not.Null);
        }

        [Test]
        public void Not_RenderAnyTracksOutsideTheMonitoredAirSpace()
        {
            _fakeMonitoredAirspace.HasPositionWithinBoundaries(Arg.Any<Position>()).Returns(true);

            var record = new FlightRecord()
            {
                Tag = "test flight",
                Position = new Position(0, 0, 0),
                Timestamp = DateTime.MinValue
            };
            
            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));


            IFlightTrack persistedArg = null;
            _uut.LeftAirspace += (sender, e) => { persistedArg = e.FlightTrack; };
            
            _fakeMonitoredAirspace.HasPositionWithinBoundaries(Arg.Any<Position>()).Returns(false);
            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));
            
            Assert.That(persistedArg, Is.Not.Null);
            
        }
    }
}

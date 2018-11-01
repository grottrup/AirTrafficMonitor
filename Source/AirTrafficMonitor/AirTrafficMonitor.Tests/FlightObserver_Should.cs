using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class FlightObserver_Should
    {
        private IView fakeView;
        private ISeperationHandler fakeSeperation;
        private IFlightRecordReceiver fakeFlight;
        private FlightObserver uut;
        private Airspace fakeMonitoredAirspace;

        [SetUp]
        public void SetUp()
        {
            fakeView = Substitute.For<IView>();
            fakeSeperation = Substitute.For<ISeperationHandler>();
            fakeFlight = Substitute.For<IFlightRecordReceiver>();
            fakeMonitoredAirspace = Substitute.For<Airspace>();
            uut = new FlightObserver(fakeMonitoredAirspace, fakeFlight, fakeView, fakeSeperation);
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

            fakeFlight.FlightRecordReceived += Raise.EventWith(fakeFlight, new FlightRecordEventArgs(record));

            // Assert
            fakeView.Received().Render(Arg.Any<FlightTrack>());
            fakeSeperation.Received().DetectCollision(Arg.Any<List<FlightTrack>>());
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

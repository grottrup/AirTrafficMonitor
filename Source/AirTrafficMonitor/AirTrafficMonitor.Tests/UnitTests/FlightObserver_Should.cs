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

        [Test]
        public void Call_RenderAndCollisionDivider()
        {
            //arrange
            var fakeView = Substitute.For<IView>();
            var fakeSeperation = Substitute.For<ISeperationHandler>();
            var fakeFlight = Substitute.For<IFlightRecordReceiver>();
            var observer = new FlightObserver(fakeFlight, fakeView, fakeSeperation);

            //act

            var record = new FlightRecord()
            {
                Tag = "default",
                Position = new Position(20000, 20000, 19000),
                Timestamp = DateTime.MinValue
            };

            fakeFlight.FlightRecordReceived += Raise.EventWith(fakeFlight, new FlightRecordEventArgs(record));

            //assert
            fakeView.Received().Render(Arg.Any<FlightTrack>());
            fakeSeperation.Received().DetectCollision(Arg.Any<List<FlightTrack>>());
        }

    }
}

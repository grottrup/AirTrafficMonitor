using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Observer;
using AirTrafficMonitor.View;
using DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class ObserverTests
    {

        [Test]
        public void FlightObserver_ShouldCall_RenderAndCollisionDivider()
        {
            //arrange
            var fakeView = Substitute.For<IView>();
            var fakeSeperation = Substitute.For<ISeperationHandler>();
            var fakeFlight = Substitute.For<IFlightRecordReceiver>();
            var observer = new FlightObserver(fakeFlight, fakeView, fakeSeperation);

            //act
            //observer.UpdateFlightTracks(new FlightRecord()
            //{
            //    Tag = "default",
            //    Position = new Position(20000, 20000, 19000),
            //    Timestamp = DateTime.MinValue
            //});
            
            //assert
            fakeView.Received().Render(Arg.Any<FlightTrack>());
            fakeSeperation.Received().DetectCollision(Arg.Any<List<FlightTrack>>());
        }

    }
}

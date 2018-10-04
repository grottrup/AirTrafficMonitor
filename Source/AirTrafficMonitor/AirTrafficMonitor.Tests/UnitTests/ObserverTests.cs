using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var observer = new FlightObserver(fakeView, fakeSeperation);

            //act
            observer.Update(new FlightRecord()
            {
                Tag = "default",
                Position = new Position(20000, 20000, 19000),
                Timestamp = DateTime.MinValue
            });
            
            //assert
            fakeView.Received().Render(Arg.Any<FlightRecord>());
            fakeSeperation.Received().DetectCollision(Arg.Any<List<FlightTrack>>());
        }

    }
}

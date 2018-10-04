using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Util;
using AirTrafficMonitor.View;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class TrackListRecordSorterTests
    {
        //ZOMBIES
        [Test]
        public void Sort_NullRecordWhenListIsEmpty_ShouldNotBeAccepeted()
        {
            // Arrange
            var tracks = new List<FlightTrack>();

            //Act
            Assert.Throws<NullReferenceException>( () =>
                tracks.SortRecordByTag(null)
            );

            //Assert
            Assert.AreEqual(0, tracks.Count());
        }

        [Test]
        public void Sort_OneRecordWhenListIsEmpty_ShouldCreateANewTrackWithASingleRecord()
        {
            // Arrange
            var tracks = new List<FlightTrack>();
            var factory = new FlightRecordFactory();
            var record = factory.CreateRecord("AGJ063;39563;95000;16800;20181001160609975");
            var expectedTrack = new FlightTrack("AGJ063");
            expectedTrack.Add(record);

            //Act
            tracks.SortRecordByTag(record);

            //Assert
            Assert.AreEqual(1, tracks.Count());
            Assert.AreEqual(expectedTrack.Tag, tracks.First().Tag);
            Assert.AreEqual(expectedTrack.Course, tracks.First().Course);
            Assert.AreEqual(expectedTrack.Position, tracks.First().Position);
            Assert.AreEqual(expectedTrack.LatestTime, tracks.First().LatestTime);
            Assert.AreEqual(expectedTrack.Velocity, tracks.First().Velocity);
        }
    }
}

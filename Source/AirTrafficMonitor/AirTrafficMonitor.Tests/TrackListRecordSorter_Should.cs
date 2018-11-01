using System;
using System.Collections.Generic;
using System.Linq;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Util;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class TrackListRecordSorter_Should
    {
        //ZOMBIES

        //Z
        [Test]
        public void NotAccept_NullRecordWhenListIsEmpty()
        {
            // Arrange
            var tracks = new List<FlightTrack>();

            //Act
            Assert.Throws<NullReferenceException>(() =>
               tracks.SortRecordByTag(null)
            );

            //Assert
            Assert.AreEqual(0, tracks.Count());
        }

        //O
        [Test]
        public void CreateANewTrackWithASingleRecord_WhenListIsEmpty()
        {
            // Arrange
            var tracks = new List<FlightTrack>();
            var factory = new FlightRecordFactory();
            var record = factory.CreateRecord("AGJ063;39563;95000;16800;20181001160609975");
            var expectedTrack = new FlightTrack("AGJ063");
            expectedTrack.Update(record);

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

        //M
        [Test]
        public void CreateTwoIndependentTracks_ForDifferentFlights()

        {
            // Arrange
            var tracks = new List<FlightTrack>();
            var factory = new FlightRecordFactory();

            var record1 = factory.CreateRecord("AGJ063;39563;95000;16800;20181001160609975");
            var record2 = factory.CreateRecord("BBJ011;30563;90000;10800;20191001160609975");

            var expectedTrack1 = new FlightTrack("AGJ063");
            expectedTrack1.Update(record1);

            var expectedTrack2 = new FlightTrack("BBJ011");
            expectedTrack2.Update(record2);

            //Act
            tracks.SortRecordByTag(record1);
            tracks.SortRecordByTag(record2);

            //Assert
            Assert.AreEqual(2, tracks.Count());
            Assert.IsTrue(tracks.Any(track => track.Tag == expectedTrack1.Tag));
        }

        //M
        [Test]
        public void UpdateTheCurrentTrackOfTheFlight_ForTwoRecordsOfSameFlight()

        {
            // Arrange
            var tracks = new List<FlightTrack>();
            var factory = new FlightRecordFactory();
            var record1 = factory.CreateRecord("AGJ063;39563;95000;16800;20181001160609975");
            var record2 = factory.CreateRecord("AGJ063;0;0;0;20191001160609975");
            var expectedTrack = new FlightTrack("AGJ063");
            expectedTrack.Update(record1);
            expectedTrack.Update(record2);

            //Act
            tracks.SortRecordByTag(record1);
            tracks.SortRecordByTag(record2);

            //Assert
            Assert.AreEqual(1, tracks.Count());
            Assert.AreEqual(expectedTrack.Tag, tracks.First().Tag);
        }
    }
}
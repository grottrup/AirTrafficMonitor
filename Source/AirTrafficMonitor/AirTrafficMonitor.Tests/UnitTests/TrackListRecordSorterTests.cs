using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Util;
using AirTrafficMonitor.View;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class TrackListRecordSorterTests
    {
        //ZOMBIES
        [Test]
        public void Sort_WhenListIsEmpty_ShouldCreateANewTrackWithASingleRecord()
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
        }
    }
}

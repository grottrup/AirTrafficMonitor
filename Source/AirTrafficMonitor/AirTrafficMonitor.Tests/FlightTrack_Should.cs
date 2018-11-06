using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class FlightTrack_Should
    {
        [TestCase(0, 0, 0, 1, 0)] //north
        [TestCase(0, 0, 1, 0, 90)] //east
        [TestCase(0, 1, 0, 0, 180)] //south
        [TestCase(1, 0, 0, 0, 270)] //west
        public void GivenTwoPositionRecords_CalculateANavigationCourse(int lon1, int lat1, int lon2, int lat2, int expectedCourse)
        {
            var uut = new FlightTrack("test flight");

            var record1 = new FlightRecord() {Position = new Position(lat1, lon1, 0)};
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, 0) };

            uut.Update(record1);
            uut.Update(record2);

            Assert.That(uut.NavigationCourse, Is.EqualTo(expectedCourse));
        }

        //[TestCase(0, 0, 0, 0, 0)]
        public void GivenTwoPositionRecords_CalculateVelocity(int lon1, int lat1, int lon2, int lat2, int expectedVelocity)
        {
            var uut = new FlightTrack("test flight");

            var record1 = new FlightRecord() { Position = new Position(lat1, lon1, 0) };
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, 0) };

            uut.Update(record1);
            uut.Update(record2);

            Assert.That(uut.Velocity, Is.EqualTo(expectedVelocity));
        }
    }
}

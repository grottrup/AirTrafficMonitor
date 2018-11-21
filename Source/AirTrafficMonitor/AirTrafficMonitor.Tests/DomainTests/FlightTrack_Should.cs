using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.DomainTests
{
    [TestFixture]
    public class FlightTrack_Should
    {
        private FlightTrack _uut;

        [TestCase(1, 0, 0, 0, 270)] // West
        [TestCase(0, 1, 0, 0, 180)] // Sourth
        [TestCase(0, 0, 1, 0, 90)] // East
        [TestCase(0, 0, 0, 1, 0)] // North
        [TestCase(1, 0, 0, 1, 315)] // North West
        [TestCase(1, 1, 0, 0, 225)] // Sorth West
        [TestCase(0, 1, 1, 0, 135)] // Sorth East
        [TestCase(0, 0, 1, 1, 45)] // North East
        [TestCase(0, 0, 0, 0, double.NaN)] // No expectedCourse
        [TestCase(100000, 0, 0, 1, 359.999)] // North North West testing decimals
        [TestCase(1, 0, -1, 0, 270)] // West
        [TestCase(0, 1, 0, -1, 180)] // Sourth
        [TestCase(-1, 0, 1, 0, 90)] // East
        [TestCase(0, -1, 0, 1, 0)] // North
        [TestCase(1, -1, -1, 1, 315)] // North West
        [TestCase(1, 1, -1, -1, 225)] // Sorth West
        [TestCase(-1, 1, 1, -1, 135)] // Sorth East
        [TestCase(-1, -1, 1, 1, 45)] // North East
        public void GivenTwoPositionRecords_CalculateNavigationCourse(int lat1, int lon1, int lat2, int lon2, double expectedCourse)
        {
            _uut = new FlightTrack("AAA123");
            var record1 = new FlightRecord() {Position = new Position(lat1, lon1, 0)};
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, 0) };
            _uut.Update(record1);
            _uut.Update(record2);

            Assert.That(_uut.NavigationCourse, Is.EqualTo(expectedCourse).Within(0.001));
        }

        [TestCase(40000, 30000, 12000, 20000, 10000, 8000, 5, 5656.8)]
        [TestCase(4000, 4000, 1000, 4100, 4100, 1000, 10, 14.1)]
        [TestCase(4850, 4850, 1000, 5000, 5000, 1000, 2, 106)]
        [TestCase(1000, 1000, 1000, 1000, 1000, 1000, 1, 0)]
        public void GivenTwoPositionRecords_CalculateVelocity(int lon1, int lat1, int alt1, int lon2, int lat2, int alt2, int time, double expectedVelocity)
        {
            _uut = new FlightTrack("AAA123");
            var record1 = new FlightRecord() { Position = new Position(lat1, lon1, alt1), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0) };
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, alt2), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0 + time) };

            _uut.Update(record1);
            _uut.Update(record2);

            Assert.That(_uut.Velocity, Is.EqualTo(expectedVelocity));
        }

        [TestCase(-1000, -1000, -1000, 1000, 1000, 1000, 0, 1000, 1000, 1000, 1, 0)]
        public void OnlyMakeVelocityCalculations_FromTheTwoLatestRecords(int lat1, int lon1, int alt1, 
                                                                         int lat2, int lon2, int alt2, int timeSec2,
                                                                         int lat3, int lon3, int alt3, int timeSec3,
                                                                         double expectedVelocity)
        {
            // ARRAGNE
            _uut = new FlightTrack("AAA123");
            var record1 = new FlightRecord() { Position = new Position(lat1, lon1, alt1), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0) };
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, alt2), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0).Add(new TimeSpan(0,0,timeSec2)) };
            _uut.Update(record1);
            _uut.Update(record2);

            // ACT
            var record3 = new FlightRecord() { Position = new Position(lat3, lon3, alt3), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0).Add(new TimeSpan(0,0,timeSec2 + timeSec3)) }; ;
            _uut.Update(record3);

            //ASSERT
            Assert.That(_uut.Velocity, Is.EqualTo(expectedVelocity));
        }

        [TestCase("ABC123", 147,102,417,double.NaN,0,23,59)]
        public void OnlyMakeVelocityCalculations_FromTheTwoLatestRecords2(string tag, int lat, int lon, int alt, 
                                                                         double expectedCourse, double expectedVelocity, 
                                                                         int hour, int minute)
        {
            // ARRANGE
            _uut = new FlightTrack(tag);
            var record1 = new FlightRecord()
            {
                Position = new Position(lat, lon, alt),
                Timestamp = new DateTime(2018, 1, 1, hour, minute, 0)
            };
            _uut.Update(record1);

            var uutStr = _uut.ToString();
            //ASSERT
            Assert.That(uutStr, Does.Contain(tag));
            Assert.That(uutStr, Does.Contain(lat.ToString()));
            Assert.That(uutStr, Does.Contain(lon.ToString()));
            Assert.That(uutStr, Does.Contain(alt.ToString()));
            Assert.That(uutStr, Does.Contain(expectedCourse.ToString()));
            Assert.That(uutStr, Does.Contain(expectedVelocity.ToString()));
            Assert.That(uutStr, Does.Contain(hour.ToString()));
            Assert.That(uutStr, Does.Contain(minute.ToString()));
        }
    }
}

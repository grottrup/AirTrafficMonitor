﻿using System;
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
        private FlightTrack _uut;
        private FlightRecord record1;
        private FlightRecord record2;

        //0 = nord
        //1-89 = nord/øst
        //90 = øst
        //91-179 = syd/øst
        //180 = syd
        //181-269 = syd/west
        //270 = west
        //271-359 = nord/west
        [TestCase(20000, 15000, 10000, 25000, 315)]
        [TestCase(1000, - 10, 1500, - 20, 0)]
        [TestCase(1000, 10, 1500, 20, 181)]
        [TestCase(30000, 65000, 14000, 45000, 0)] 
        public void GivenTwoPositionRecords_CalculateANavigationCourse(int lat1, int lon1, int lat2, int lon2, int expectedCourse)
        {
            _uut = new FlightTrack("AAA123");
            var record1 = new FlightRecord() {Position = new Position(lat1, lon1, 0)};
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, 0) };
            _uut.Update(record1);
            _uut.Update(record2);

            Assert.That(_uut.NavigationCourse, Is.EqualTo(expectedCourse));
        }

        [TestCase(40000, 30000, 12000, 20000, 10000, 8000, 5, 5656.8)]
        [TestCase(4000, 4000, 1000, 4100, 4100, 1000, 10, 14.1)]
        [TestCase(4850, 4850, 1000, 5000, 5000, 1000, 2, 106)]

        public void GivenTwoPositionRecords_CalculateVelocity(int lon1, int lat1, int alt1, int lon2, int lat2, int alt2, int time, double expectedVelocity)
        {

            _uut = new FlightTrack("AAA123");
            var record1 = new FlightRecord() { Position = new Position(lat1, lon1, alt1), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0) };
            var record2 = new FlightRecord() { Position = new Position(lat2, lon2, alt2), Timestamp = new DateTime(2018, 1, 1, 0, 0, 0 + time) };

            _uut.Update(record1);
            _uut.Update(record2);

            Assert.That(_uut.Velocity, Is.EqualTo(expectedVelocity));
        }
    }
}

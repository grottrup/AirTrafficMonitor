using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    class SeparationHandler_Should
    {
        private IFlightObserver _fakeFlightObserver;
        private ILogger _fakeLogger;
        private IView _fakeView;
        private SeparationHandler _uut;

        [SetUp]
        public void SetUp()
        {
            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            
            _uut = new SeparationHandler(_fakeLogger, _fakeView);
        }
        
        [TestCase("ABC123", "DEF456", 2018, 11, 22, 13, 41, 55, 56)]
        public void RaiseEvent_WhenFlightsAreInProximity(string tag1, string tag2, int year, int month, int day, int hour, int min, int sec1, int sec2)
        {
            //Create 2 flighttracks colliding
            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
            Position fake2 = Substitute.For<Position>(15000, 15001, 10000);

            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec1));
            fakeFlightTrack1.Position.Returns(fake1);

            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
            fakeFlightTrack2.Tag.Returns(tag2);
            fakeFlightTrack2.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec2));
            fakeFlightTrack2.Position.Returns(fake2);

            List<IFlightTrack> tracks = new List<IFlightTrack>();
            tracks.Add(fakeFlightTrack1);
            tracks.Add(fakeFlightTrack2);
            ICollection<IFlightTrack> fakeTracks = tracks;

            Tuple<IFlightTrack, IFlightTrack> result = null;
            _uut.FlightsInProximity += (sender, e) =>
            {
                result = e.proximityTracks;
            };

            Tuple<IFlightTrack, IFlightTrack> expectedResult = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack2, fakeFlightTrack1);

            // Act
            _uut.DetectCollision(fakeTracks);

            // Assert
            Assert.AreEqual(result, expectedResult);
        }

        [TestCase("ABC123", 2018, 11, 22, 13, 41, 55, 56)]
        public void DoNothing_WhenOnlyOneFlightTrack(string tag1, int year, int month, int day, int hour, int min, int sec1, int sec2)
        {
            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec1));
            fakeFlightTrack1.Position.Returns(fake1);

            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
            fakeFlightTrack2.Tag.Returns(tag1);
            fakeFlightTrack2.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec2));
            fakeFlightTrack2.Position.Returns(fake1);

            List<IFlightTrack> tracks = new List<IFlightTrack>();
            tracks.Add(fakeFlightTrack1);
            tracks.Add(fakeFlightTrack2);
            ICollection<IFlightTrack> fakeTracks = tracks;

            Tuple<IFlightTrack, IFlightTrack> result = null;
            _uut.FlightsInProximity += (sender, e) =>
            {
                result = e.proximityTracks;
            };

            Tuple<IFlightTrack, IFlightTrack> expectedResult = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack2, fakeFlightTrack1);

            // Act
            _uut.DetectCollision(fakeTracks);

            // Assert
            Assert.AreNotEqual(expectedResult, result);
        }
        
        [TestCase("ABC123", "DEF456")]
        public void DoNothing_WhenNotWithinTimespan(string tag1, string tag2)
        {
            //Create 2 flighttracks colliding
            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
            Position fake2 = Substitute.For<Position>(15000, 15001, 10000);

            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(DateTime.MinValue);
            fakeFlightTrack1.Position.Returns(fake1);

            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
            fakeFlightTrack2.Tag.Returns(tag2);
            fakeFlightTrack2.LatestTime.Returns(DateTime.MaxValue);
            fakeFlightTrack2.Position.Returns(fake2);

            List<IFlightTrack> tracks = new List<IFlightTrack>();
            tracks.Add(fakeFlightTrack1);
            tracks.Add(fakeFlightTrack2);
            ICollection<IFlightTrack> fakeTracks = tracks;

            Tuple<IFlightTrack, IFlightTrack> result = null;
            _uut.FlightsInProximity += (sender, e) =>
            {
                result = e.proximityTracks;
            };

            Tuple<IFlightTrack, IFlightTrack> expectedResult = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack2, fakeFlightTrack1);

            // Act
            _uut.DetectCollision(fakeTracks);

            // Assert
            Assert.AreNotEqual(result, expectedResult);

        }

        
        [TestCase("ABC123", "DEF456", 2018, 11, 22, 13, 41, 55, 56)]
        public void DoNothing_WhenNotWithinProximity(string tag1, string tag2, int year, int month, int day, int hour, int min, int sec1, int sec2)
        {//Create 2 flighttracks colliding
            Position fake1 = Substitute.For<Position>(15000, 15000, 6000);
            Position fake2 = Substitute.For<Position>(15000, 15001, 19999);

            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec1));
            fakeFlightTrack1.Position.Returns(fake1);

            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
            fakeFlightTrack2.Tag.Returns(tag2);
            fakeFlightTrack2.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec2));
            fakeFlightTrack2.Position.Returns(fake2);

            List<IFlightTrack> tracks = new List<IFlightTrack>();
            tracks.Add(fakeFlightTrack1);
            tracks.Add(fakeFlightTrack2);
            ICollection<IFlightTrack> fakeTracks = tracks;

            Tuple<IFlightTrack, IFlightTrack> result = null;
            _uut.FlightsInProximity += (sender, e) =>
            {
                result = e.proximityTracks;
            };

            Tuple<IFlightTrack, IFlightTrack> expectedResult = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack2, fakeFlightTrack1);

            // Act
            _uut.DetectCollision(fakeTracks);

            // Assert
            Assert.AreNotEqual(result, expectedResult);

        }
    }
}

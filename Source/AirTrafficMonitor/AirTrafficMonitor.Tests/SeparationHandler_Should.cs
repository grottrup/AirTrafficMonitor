//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using AirTrafficMonitor.AntiCorruptionLayer;
//using AirTrafficMonitor.Domain;
//using AirTrafficMonitor.Infrastructure;
//using AirTrafficMonitor.Utilities;
//using NSubstitute;
//using NUnit.Framework;

//namespace AirTrafficMonitor.Tests
//{
//    [TestFixture]
//    class SeparationHandler_Should
//    {
//        private IFlightObserver _fakeFlightObserver;
//        private SeparationHandler _uut;

//        [SetUp]
//        public void SetUp()
//        {
//            _fakeFlightObserver = Substitute.For<IFlightObserver>();
//            _uut = new SeparationHandler();
//        }

//        [TestCase("ABC123", "DEF456", 2018, 11, 22, 13, 41, 55, 56)]
//        public void RaiseEvent_WhenFlightsAreInProximity(string tag1, string tag2, int year, int month, int day, int hour, int min, int sec1, int sec2)
//        {
//            //Create 2 flighttracks colliding
//            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
//            Position fake2 = Substitute.For<Position>(15000, 15001, 10000);

//            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack1.Tag.Returns(tag1);
//            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec1));
//            fakeFlightTrack1.Position.Returns(fake1);

//            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack2.Tag.Returns(tag2);
//            fakeFlightTrack2.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec2));
//            fakeFlightTrack2.Position.Returns(fake2);

//            var fakeTracks = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack1, fakeFlightTrack2);

//            Tuple<IFlightTrack, IFlightTrack> proximityTracks = null;
//            _uut.FlightsInProximity += (sender, e) =>
//            {
//                proximityTracks = e.proximityTracks;
//            };

//            // Act
//            _uut.DetectCollision(fakeTracks);

//            // Assert
//            Assert.That(proximityTracks.Item1, Is.Not.Null);

//        }

//        [TestCase("ABC123", "DEF456")]
//        public void DoNothing_WhenFlightTracksAreNull(string tag1, string tag2)
//        {

//            //Create 2 flighttracks colliding
//            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
//            Position fake2 = Substitute.For<Position>(15000, 15001, 10000);

//            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack1.Tag.Returns(tag1);
//            fakeFlightTrack1.LatestTime.Returns(DateTime.MaxValue);
//            fakeFlightTrack1.Position.Returns(fake1);

//            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack2.Tag.Returns(tag2);
//            fakeFlightTrack2.LatestTime.Returns(DateTime.MinValue);
//            fakeFlightTrack2.Position.Returns(fake2);

//            //var fakeTracks = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack1, fakeFlightTrack2);

//            //Tuple<IFlightTrack, IFlightTrack> proximityTracks = null;
//            //_uut.FlightsInProximity += (sender, e) =>
//            //{
//            //    proximityTracks = e.proximityTracks;
//            //};

//            Tuple<IFlightTrack, IFlightTrack> fakeTracks = null;


//            // Act
//            _uut.DetectCollision(fakeTracks);

//            // Assert

//            Assert.That(proximityTracks, Is.Null);

//        }

//        [TestCase("ABC123", "DEF456")]
//        public void DoNothing_WhenNotWithinTimespan(string tag1, string tag2)
//        {

//            //Create 2 flighttracks colliding
//            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
//            Position fake2 = Substitute.For<Position>(15000, 15001, 10000);

//            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack1.Tag.Returns(tag1);
//            fakeFlightTrack1.LatestTime.Returns(DateTime.MaxValue);
//            fakeFlightTrack1.Position.Returns(fake1);

//            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack2.Tag.Returns(tag2);
//            fakeFlightTrack2.LatestTime.Returns(DateTime.MinValue);
//            fakeFlightTrack2.Position.Returns(fake2);

//            var fakeTracks = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack1, fakeFlightTrack2);

//            Tuple<IFlightTrack, IFlightTrack> proximityTracks = null;
//            _uut.FlightsInProximity += (sender, e) =>
//            {
//                proximityTracks = e.proximityTracks;
//            };

//            // Act
//            _uut.DetectCollision(fakeTracks);

//            // Assert
//            Assert.That(proximityTracks, Is.Null);

//        }


//        [TestCase("ABC123", "DEF456", 2018, 11, 22, 13, 41, 55, 56)]
//        public void DoNothing_WhenNotWithinProximity(string tag1, string tag2, int year, int month, int day, int hour, int min, int sec1, int sec2)
//        {

//            //Create 2 flighttracks colliding
//            Position fake1 = Substitute.For<Position>(15000, 15000, 10000);
//            Position fake2 = Substitute.For<Position>(15000, 15001, 10000);

//            var fakeFlightTrack1 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack1.Tag.Returns(tag1);
//            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec1));
//            fakeFlightTrack1.Position.Returns(fake1);

//            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
//            fakeFlightTrack2.Tag.Returns(tag2);
//            fakeFlightTrack2.LatestTime.Returns(new DateTime(year, month, day, hour, min, sec2));
//            fakeFlightTrack2.Position.Returns(fake2);

//            var fakeTracks = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack1, fakeFlightTrack2);

//            Tuple<IFlightTrack, IFlightTrack> proximityTracks = null;
//            _uut.FlightsInProximity += (sender, e) =>
//            {
//                proximityTracks = e.proximityTracks;
//            };

//            // Act
//            _uut.DetectCollision(fakeTracks);

//            // Assert
//            Assert.That(proximityTracks, Is.Null);

//        }
//    }
//}

using System;
using System.Collections;
using System.Collections.Generic;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class AirspaceEvent_Should
    {
        private ITimer _fakeTimer;
        private IView _fakeView;
        private IFlightObserver _fakeFlightObserver;
        private AirspaceEventHandler _uut;
        private ISeperationHandler _fakeSeperation;

        [SetUp]
        public void SetUp()
        {
            _fakeTimer = Substitute.For<ITimer>();
            _fakeView = Substitute.For<IView>();
            _fakeSeperation = Substitute.For<ISeperationHandler>();
            var fakeLogger = Substitute.For<ILogger>();

            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _uut = new AirspaceEventHandler(_fakeFlightObserver, _fakeView, fakeLogger, _fakeSeperation);
        }

        [TestCase("CC123", 2018, 1, 1, "CC456", 2018, 1, 1)]
        public void Give_TriggerWarning(string tag, int year, int month, int day, string tag2, int year2, int month2, int day2)
        {
            // Act
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            var fakeFlightTrack2 = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag2);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year2, month2, day2));

            Tuple<IFlightTrack, IFlightTrack> fakeTracks = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack, fakeFlightTrack2);

            _fakeSeperation.FlightsInProximity += Raise.EventWith(_fakeSeperation, new FlightInProximityEventArgs(fakeTracks));

            var expectedResult = $"Danger! Proximity of {fakeTracks.Item1.Tag} and {fakeTracks.Item2.Tag}";

            //Assert
            _fakeView.Received().AddToRenderWithColor(expectedResult, ConsoleColor.Red);
        }

        [TestCase("CC123", 2018, 1, 1)]
        public void AirspaceEnterEvent_TriggersView(string tag, int year, int month, int day)
        {
            // Act
            var fakeFlightTrack = Substitute.For<IFlightTrack>();

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));

            _fakeView.Received().AddToRenderWithColor(Arg.Any<string>(), Arg.Any<ConsoleColor>());
        }

        [TestCase("BB123", 2018, 1, 1)]
        public void AirspaceLeftEvent_TriggersView(string tag, int year, int month, int day)
        {
            // Act
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            _fakeFlightObserver.LeftAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));

            _fakeView.Received().AddToRenderWithColor(Arg.Any<string>(), Arg.Any<ConsoleColor>());
        }
    }
}

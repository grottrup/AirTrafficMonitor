using System;
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


        [SetUp]
        public void SetUp()
        {
            _fakeTimer = Substitute.For<ITimer>();
            _fakeView = Substitute.For<IView>();

            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _uut = new AirspaceEventHandler(_fakeFlightObserver, _fakeView);
        }

        [TestCase("CC123", 2018, 1, 1)]
        public void AirspaceEnterEvent_TriggersView(string tag, int year, int month, int day)
        {
            // Act
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
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
        private ILogger _fakeLogger;
        private ISeperationHandler _fakeSeperation;
        private IFlightRecordReceiver _fakeFlight;
        private IFlightObserver _fakeFlightObserver;
        private List<IFlightTrack> _tracks;
        private IAirspace _fakeMonitoredAirspace;
        private AirspaceEventHandler _uut;
        private FlightTrack _fakeTrack;
        private List<FlightTrack> _fakeTracks;


        [SetUp]
        public void SetUp()
        {
            _fakeTimer = Substitute.For<EventTimer>(5000);
            _fakeTracks = Substitute.For<List<FlightTrack>>();
            _fakeTrack = Substitute.For<FlightTrack>("AAAAA");
            _tracks = new List<IFlightTrack>();

            _fakeView = Substitute.For<IView>();
            _fakeSeperation = Substitute.For<ISeperationHandler>();
            _fakeFlight = Substitute.For<IFlightRecordReceiver>();
            _fakeLogger = Substitute.For<ILogger>();
            _fakeMonitoredAirspace = Substitute.For<IAirspace>();
            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _uut = new AirspaceEventHandler(_fakeFlightObserver, _fakeView);
        }
        //Flight CC123 entered airspace at 01-01-0001 00:00:00
        [Test]
        public void AirspaceEnterEvent()
        {
            // Act


            _fakeTrack = new FlightTrack("CC123")
            {
                Position = new Position(20000, 20000, 19000),
                LatestTime = DateTime.MinValue
            };

            var track = Substitute.For<IFlightTrack>();
            track.Position = new Position(20000, 20000, 19000);
            track.LatestTime = DateTime.MaxValue;

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(_fakeTrack));
            

            _fakeView.Received().RenderWithRedTillTimerEnds("Flight: " + _fakeTrack.Tag + " entered airspace at: " + _fakeTrack.LatestTime + "");
        }

        [Test]
        public void AirspaceLeftEvent()
        {
            // Act
           
            _fakeTrack = new FlightTrack("BB123")
            {
                Position = new Position(11000, 910000, 5000),
                LatestTime = DateTime.MinValue
            };

            _fakeTracks = new List<FlightTrack>();
            _fakeFlightObserver.LeftAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(_fakeTrack));


            _fakeView.Received().RenderWithGreenTillTimerEnds("Flight: " + _fakeTrack.Tag + " left airspace at: " + _fakeTrack.LatestTime + "");
        }

        [Test]
        public void timer_test()
        {
            _fakeTrack = new FlightTrack("CC123")
            {
                Position = new Position(20000, 20000, 19000),
                LatestTime = DateTime.MinValue
            };

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(_fakeTrack));
           
     
            _fakeTimer.Received();
        }

    }
}

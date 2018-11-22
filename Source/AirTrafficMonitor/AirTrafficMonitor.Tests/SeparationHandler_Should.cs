using System;
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
        private ITimer _aTimer;
        private IView _fakeView;
        private ILogger _fakeLogger;
        private IFlightRecordReceiver _fakeFlight;
        private IFlightObserver _fakeFlightObserver;
        private Tuple<FlightTrack, FlightTrack> _fakeTracks;
        private Airspace _fakeMonitoredAirspace;
        private AirspaceEventHandler _fakeAirspaceEventHandler;
        private SeparationHandler _uut;
        public event EventHandler<FlightInProximityEventArgs> FlightsInProximity;

        [SetUp]
        public void SetUp()
        {
            _aTimer = new EventTimer();
            //_fakeTracks = Substitute.For<Tuple<FlightTrack, FlightTrack>>();
            _fakeView = Substitute.For<IView>();
            //_fakeAirspaceEventHandler = Substitute.For<AirspaceEventHandler>();
            _fakeFlight = Substitute.For<IFlightRecordReceiver>();
            _fakeLogger = Substitute.For<ILogger>();
            _fakeMonitoredAirspace = Substitute.For<Airspace>();
            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _uut = new SeparationHandler(_fakeLogger);
        }


        //Warning, two planes are currently on collision course!
        //Plane Tag: AB12 and plane Tag: CD34;
        [Test]
        public void WriteCollision()
        {
            // Act
            var track1 = new FlightTrack("AB12")
            {
                Position = new Position(20000, 20000, 19000),
                LatestTime = DateTime.MinValue
            };
            var track2 = new FlightTrack("CD34")
            {
                Position = new Position(20000, 20000, 19000),
                LatestTime = DateTime.MinValue
            };

            var lol = new Tuple<FlightTrack, FlightTrack>(track1, track2);

            //_uut.FlightsInProximity += Raise.EventWith(_uut, new FlightInProximityEventArgs(lol));
            //_fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));
            //_fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(track));
            
            //Assert
            _fakeView.RenderCollision(lol);
        }
    }
}

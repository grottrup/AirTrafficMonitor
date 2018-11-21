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

        private IView _fakeView;
        private ILogger _fakeLogger;
        private ISeperationHandler _fakeSeperation;
        private IFlightRecordReceiver _fakeFlight;
        private IFlightObserver _fakeFlightObserver;
        private List<FlightTrack> _fakeTracks;
        private IAirspace _fakeMonitoredAirspace;
        private AirspaceEventHandler _uut;



        [SetUp]
        public void SetUp()
        {

            _fakeTracks = Substitute.For<List<FlightTrack>>();
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
        public void AirspaceEvent()
        {
            // Act

            var track = new FlightTrack("CC123")
            {
                Position = new Position(20000, 20000, 19000),
                LatestTime = DateTime.MinValue
            };

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(track));

            //var record1 = new FlightTrack("CC123")
            //{
              
            //    Position = new Position(100, 100, 450),
            //    LatestTime = DateTime.Now
            //};
            //_fakeFlightObserver.LeftAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(record1));

            _fakeView.Received().RenderWithRedTillTimerEnds("Flight " + track.Tag + " entered airspace at" + track.LatestTime + "");
        }

        //[Test]
        //public void Test_Timer()
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    _aTimer.WaitTimer();
        //    watch.Stop();

        //    var output = watch.ElapsedMilliseconds;

        //    Assert.AreEqual(5000, output);

        //    // Assert

        //}

    }
}

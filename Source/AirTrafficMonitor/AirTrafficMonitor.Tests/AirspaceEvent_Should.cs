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
        private ITimer _aTimer;
        private IView _fakeView;
        private ILogger _fakeLogger;
        private ISeperationHandler _fakeSeperation;
        private IFlightRecordReceiver _fakeFlight;
        private FlightObserver _uut;
        private List<FlightTrack> _fakeTracks;
        private Airspace _fakeMonitoredAirspace;
        private AirspaceEventHandler _airspaceEventHandler;



        [SetUp]
        public void SetUp()
        {
            _aTimer = new EventTimer();
            _fakeTracks = Substitute.For<List<FlightTrack>>();
            _fakeView = Substitute.For<IView>();
            _fakeSeperation = Substitute.For<ISeperationHandler>();
            _fakeFlight = Substitute.For<IFlightRecordReceiver>();
            _fakeLogger = Substitute.For<ILogger>();
            _fakeMonitoredAirspace = Substitute.For<Airspace>();
            _airspaceEventHandler = new AirspaceEventHandler();
           
            

            _uut = new FlightObserver(_fakeMonitoredAirspace, _fakeFlight, _fakeView, _fakeSeperation, _fakeLogger);
       
        }
        //Flight CC123 entered airspace at 01-01-0001 00:00:00
        [Test]
        public void AirspaceEvent()
        {
            // Act
            var record = new FlightRecord()
            {
                Tag = "CC123",
                Position = new Position(20000, 20000, 19000),
                Timestamp = DateTime.MinValue
            };

            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record));
            var record1 = new FlightRecord()
            {
                Tag = "CC123",
                Position = new Position(100, 100, 450),
                Timestamp = DateTime.MinValue
            };
            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record1));

            var record2 = new FlightRecord()
            {
                Tag = "AA123",
                Position = new Position(18000, 20000, 18000),
                Timestamp = DateTime.MinValue
            };
            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record2));

            var record3 = new FlightRecord()
            {
                Tag = "BB123",
                Position = new Position(18000, 20000, 18000),
                Timestamp = DateTime.MinValue
            };
            _fakeFlight.FlightRecordReceived += Raise.EventWith(_fakeFlight, new FlightRecordEventArgs(record3));

            // Assert
            _fakeView.Received().Render(Arg.Any<FlightTrack>());

        }

        [Test]
        public void Test_Timer()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            _aTimer.WaitTimer();
            watch.Stop();

            var output = watch.ElapsedMilliseconds;

            Assert.AreEqual(5000, output);

            // Assert

        }

    }
}

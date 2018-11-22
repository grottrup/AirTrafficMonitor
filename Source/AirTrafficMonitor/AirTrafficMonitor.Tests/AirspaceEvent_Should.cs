using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private IFlightObserver _fakeFlightObserver;
        private AirspaceEventHandler _uut;


        [SetUp]
        public void SetUp()
        {
            _fakeTimer = Substitute.For<ITimer>(5000);
            _fakeView = Substitute.For<IView>();

            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _uut = new AirspaceEventHandler(_fakeFlightObserver, _fakeView);
        }

        [TestCase("CC123", 2018, 1,1)]
        public void AirspaceEnterEvent(string tag, int year, int month, int day)
        {
            // Act
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));
            

            _fakeView.Received().AddToRenderWithColor(Arg.Any<string>(), Arg.Any<ConsoleColor>());
        }

        [TestCase("BB123", 2018,1,1)]
        public void AirspaceLeftEvent(string tag, int year, int month, int day)
        {
            // Act
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));
       
            _fakeFlightObserver.LeftAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));


            _fakeView.Received().RenderWithGreenTillTimerEnds(fakeFlightTrack);
        }

        [TestCase("AA123", 2018,1,1)]
        public void timer_test(string tag, int year, int month, int day)
        {
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));
           
            _fakeTimer.Received();
        }

        [TestCase("AA123", 2018, 1, 1)]
        public void timer_OnTimerEvent(string tag, int year, int month, int day)
        {
            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));

            var fakeTimer = Substitute.For<ITimer>();

            
            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {


                var result = ConsoleOutput.GetOutput();
                Assert.That(result, Does.Contain("Timer").IgnoreCase);
            }
        }

    }
}

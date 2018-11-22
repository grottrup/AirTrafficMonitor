using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.IntegrationTests.BottomUpTests
{
    [TestFixture]
    public class AirspaceEventHandler_Integrating_ConsoleView_Should
    {
        private AirspaceEventHandler _sut;
        private ConsoleView _ssut_view;
        private IFlightObserver _fakeFlightObserver;

        [SetUp]
        public void Setup()
        {
            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _ssut_view = new ConsoleView();
            _sut = new AirspaceEventHandler(_fakeFlightObserver, _ssut_view);
        }

        [TestCase("BB123", 2018, 11, 20)]
        public void BeAbleTo_Display_AirspaceEvent_ForEnteringAirSpace(string tag, int year, int month, int day)
        {

            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            IFlightTrack persistedArgs = null;
            _fakeFlightObserver.EnteredAirspace += (sender, e) =>
            {
                persistedArgs = e.FlightTrack;
            };

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));

            Assert.That(persistedArgs, Is.Not.Null);
            Assert.That(persistedArgs.Tag, Is.EqualTo(fakeFlightTrack.Tag));
            Assert.That(persistedArgs.LatestTime, Is.EqualTo(fakeFlightTrack.LatestTime));
        }

        [TestCase("BB123", 2018, 11, 20)]
        public void BeAbleTo_Display_AirspaceEvent_ForLeftAirSpace(string tag, int year, int month, int day)
        {

            var fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));

            IFlightTrack persistedArgs = null;
            _fakeFlightObserver.EnteredAirspace += (sender, e) =>
            {
                persistedArgs = e.FlightTrack;
            };

            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(fakeFlightTrack));

            Assert.That(persistedArgs, Is.Not.Null);
            Assert.That(persistedArgs.Tag, Is.EqualTo(fakeFlightTrack.Tag));
            Assert.That(persistedArgs.LatestTime, Is.EqualTo(fakeFlightTrack.LatestTime));
        }

        [TestCase("AA123", 2018, 11, 20)]
        public void EnterAirspace_Prints__In_Console(string tag1, int year, int month, int day)
        {

            IFlightTrack fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day));


            var currentConsoleOut = Console.Out;

   
            using (var consoleOutput = new ConsoleOutput())
            {

                _ssut_view.RenderWithRedTillTimerEnds(fakeFlightTrack1);
                var result = ConsoleOutput.GetOutput();
                Assert.That(result, Does.Contain("enter").IgnoreCase);
                Assert.That(result, Does.Contain(year.ToString()));
                Assert.That(result, Does.Contain(month.ToString()));
                Assert.That(result, Does.Contain(day.ToString()));
                Assert.That(result, Does.Contain(tag1));
            }
        }

        [TestCase("AA123", 2018, 11, 20)]
        public void LeftAirspace_Prints__In_Console(string tag1, int year, int month, int day)
        {

            IFlightTrack fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day));


            var currentConsoleOut = Console.Out;


            using (var consoleOutput = new ConsoleOutput())
            {

                _ssut_view.RenderWithGreenTillTimerEnds(fakeFlightTrack1);
                var result = ConsoleOutput.GetOutput();
                Assert.That(result, Does.Contain("left").IgnoreCase);
                Assert.That(result, Does.Contain(year.ToString()));
                Assert.That(result, Does.Contain(month.ToString()));
                Assert.That(result, Does.Contain(day.ToString()));
                Assert.That(result, Does.Contain(tag1));
            }
        }
    }
}

using System;
using System.Globalization;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NSubstitute;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests
{

    [TestFixture]
    public class ConsoleView_Should
    {
        private ConsoleView _uut;
        private ISeperationHandler _fakeSeparationHandler;
        private ILogger _fakeLogger;

        [SetUp]
        public void Setup()
        {
            //ILogger fakeLogger = Substitute.For<ILogger>();
            //ISeperationHandler fakeSeperationHandler = Substitute.For<ISeperationHandler>();
            _uut = new ConsoleView(_fakeSeparationHandler, _fakeLogger);  
        }
       
        [TestCase("AA123", "BB123", 2018, 11, 20)]
        public void RenderCollision_OfTwoFlightTracks(string tag1, string tag2, int year, int month, int day)
        {
            IFlightTrack fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack1.Tag.Returns(tag1);
            fakeFlightTrack1.LatestTime.Returns(new DateTime(year, month, day));

            IFlightTrack fakeFlightTrack2 = Substitute.For<IFlightTrack>();
            fakeFlightTrack2.Tag.Returns(tag2);
            fakeFlightTrack2.LatestTime.Returns(new DateTime(year, month, day));

            var currentConsoleOut = Console.Out;
            
            Tuple<IFlightTrack, IFlightTrack> ff = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack1, fakeFlightTrack2);
            
      
            using (var consoleOutput = new ConsoleOutput())
            {
                _uut.RenderCollision(ff);
                
                var result = ConsoleOutput.GetOutput();
                Assert.That(result, Does.Contain("Collision").IgnoreCase);
                Assert.That(result, Does.Contain(year.ToString()));
                Assert.That(result, Does.Contain(month.ToString()));
                Assert.That(result, Does.Contain(day.ToString()));
                Assert.That(result, Does.Contain(tag1));
                Assert.That(result, Does.Contain(tag2));
            }
        }

        [TestCase("CC456", 2018, 11, 21, 63.14262, 12500, 80000, 10000)]
        public void ConsoleView_RenderOfOneTrack_FullInfo(string tag, int year, int month, int day, double nav, int lat, int lon, int alt)
        {
            IFlightTrack fakeFlightTrack3 = Substitute.For<IFlightTrack>();
            fakeFlightTrack3.Tag.Returns(tag);
            fakeFlightTrack3.LatestTime.Returns(new DateTime(year, month, day));
            fakeFlightTrack3.NavigationCourse.Returns(nav);
            fakeFlightTrack3.Position.Returns(new Position(lat, lon, alt));
            
            var currentConsoleOut = Console.Out;
            
            Tuple<IFlightTrack> ft = new Tuple<IFlightTrack>(fakeFlightTrack3);
            using (var consoleOutput = new ConsoleOutput())
            {
                _uut.Render(ft);
                var result = ConsoleOutput.GetOutput();
                Assert.That(result, Does.Contain(tag));
                Assert.That(result, Does.Contain(year.ToString()));
                Assert.That(result, Does.Contain(month.ToString()));
                Assert.That(result, Does.Contain(day.ToString()));
                Assert.That(result, Does.Contain(nav.ToString()));
                Assert.That(result, Does.Contain(lat.ToString()));
                Assert.That(result, Does.Contain(lon.ToString()));
                Assert.That(result, Does.Contain(alt.ToString()));       
            }
        }
    }
}
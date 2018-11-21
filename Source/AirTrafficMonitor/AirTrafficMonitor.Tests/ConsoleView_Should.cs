using System;
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
        
        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleView();
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
                Assert.That(result, Does.Contain(year));
                Assert.That(result, Does.Contain(month));
                Assert.That(result, Does.Contain(day));
                Assert.That(result, Does.Contain(tag1));
                Assert.That(result, Does.Contain(tag2));
            }
        }


        //[TestCase("CC456", "11/20/2018 12:00:00", 63.14262, 12500, 80000, 10000 ,"Tag: CC456, Time: 11/20/2018 12:00:00 PM, NavigationCourse: 63.14262, Latitude: 12500, Longitude: 80000, Altitude: 10000\n\n")]
        public void ConsoleView_TestThatRenderCanPrint_ReturnTrue(string tag, string time, double nav, int lat, int lon, int alt, string outputstring)
        {
            var fakeFlightTrack2 = new FlightTrack("CC456")
            {
                LatestTime = DateTime.Parse(time),
                NavigationCourse = nav,
                Position = new Position()
                {
                    Latitude = lat,
                    Longitude = lon,
                    Altitude = alt,
                },
                Tag = tag,
            };
            
            var currentConsoleOut = Console.Out;
            
            //Tuple<FlightTrack> ft = new Tuple<FlightTrack>(_fakeFlightTrack2); //What are you trying to do????
            
            using (var consoleOutput = new ConsoleOutput())
            {
                //_uut.Render(ft);
                Assert.AreEqual(outputstring, ConsoleOutput.GetOutput());
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
            
        }
    }
}
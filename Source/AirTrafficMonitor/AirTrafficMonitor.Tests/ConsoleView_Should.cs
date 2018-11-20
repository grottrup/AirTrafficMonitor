using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
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
        private FlightTrack _fakeFlightTrack;
        private FlightTrack _fakeFlightTrack1;
        
//TODO: Der er syntax fejl grundet Datetime Parse konvertering. Der skal kigges yderligere på CultureInfo. 
        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleView();
            _fakeFlightTrack = Substitute.For<FlightTrack>("AA123");
            _fakeFlightTrack1 = Substitute.For<FlightTrack>("BB123");
        }
       
        [TestCase("AA123", "BB123", "20-11-2018", "Warning, two planes are currently on collision course! \n Plane Tag: AA123, Plane Tag: BB123 and Time: 20-11-2018 00:00:00\n\r\n")]
        
        public void ConsoleView_test_that_it_prints(string tag1, string tag2, string time, string outputstring)
        {
            _fakeFlightTrack = new FlightTrack("AA123")
            {
                LatestTime = DateTime.Parse(time, CultureInfo.CreateSpecificCulture("eu-EU"))
            };
            
            
            _fakeFlightTrack1 = new FlightTrack("BB123")
            {
                LatestTime = DateTime.Parse(time, CultureInfo.CreateSpecificCulture("eu-EU"))
            };
                
            var currentConsoleOut = Console.Out;
            
            Tuple<FlightTrack, FlightTrack> ff = new Tuple<FlightTrack, FlightTrack>(_fakeFlightTrack, _fakeFlightTrack1);
            
           
            using (var consoleOutput = new ConsoleOutput())
            {
               
                _uut.RenderCollision(ff);
                Assert.AreEqual(outputstring, ConsoleOutput.GetOutput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
/*

        [Test]
        public void ConsoleView_TestThatRenderCanPrint_ReturnTrue(FlightTrack track, string flight1)
        {
            
        }*/
    }
}
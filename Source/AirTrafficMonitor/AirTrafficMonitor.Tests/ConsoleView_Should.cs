using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
        private FlightTrack _fakeFlightTrack2;
        
        
//TODO: Der er syntax fejl grundet Datetime Parse konvertering. Der skal kigges yderligere på CultureInfo. 
        // Måske det her: Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        //                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        
        //Edit: i .NET 4.5 skulle følgende være AppDomain-wide: public static System.Globalization.CultureInfo DefaultThreadCurrentCulture { get; set; }
        
        
        [SetUp]
        public void Setup()
        {
            _uut = new ConsoleView();
            _fakeFlightTrack = Substitute.For<FlightTrack>("AA123");
            _fakeFlightTrack1 = Substitute.For<FlightTrack>("BB123");
            _fakeFlightTrack2 = Substitute.For<FlightTrack>("CC456");
        }
       

        [TestCase("AA123", "BB123", "11/20/2018", "Warning, two planes are currently on collision course! \n Plane Tag: AA123, Plane Tag: BB123 and Time: 11/20/2018 12:00:00 AM\n\n")]
        
        public void ConsoleView_TestThatRenderCollisionCanPrint_ReturnTrue(string tag1, string tag2, string time, string outputstring)
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


        //[TestCase("CC456", "11/20/2018 12:00:00", 63.14262, 12500, 80000, 10000 ,"Tag: CC456, Time: 11/20/2018 12:00:00 PM, NavigationCourse: 63.14262, Latitude: 12500, Longitude: 80000, Altitude: 10000\n\n")]

       
        public void ConsoleView_TestThatRenderCanPrint_ReturnTrue(string tag, string time, double nav, int lat, int lon, int alt, string outputstring)
        {
            _fakeFlightTrack2 = new FlightTrack("CC456")
            {
                LatestTime = DateTime.Parse(time, CultureInfo.CreateSpecificCulture("eu-EU")), //CultureInfo.CreateSpecificCulture("eu-EU")
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
            
            Tuple<FlightTrack> ft = new Tuple<FlightTrack>(_fakeFlightTrack2);
            
            using (var consoleOutput = new ConsoleOutput())
            {
                _uut.Render(ft);
                Assert.AreEqual(outputstring, ConsoleOutput.GetOutput());
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
            
        }
    }
}
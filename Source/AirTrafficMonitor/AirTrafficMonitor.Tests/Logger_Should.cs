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
using System.IO;


namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class Logger_Should
    {
        private Logger _uut;
        private IFlightTrack _fakeFlightTrack;
        private IFlightTrack _fakeFlightTrack1;
        
        [SetUp]
        public void Setup()
        {
            _uut = new Logger();
            _fakeFlightTrack = Substitute.For<FlightTrack>("AA123");
            _fakeFlightTrack1 = Substitute.For<FlightTrack>("BB123");
            
        }

        [Test]
        //TestKomponent -> Scenarie -> Forventning
        public void LogFile_WriteFileDoesntExist_ReturnTrue()
        {
            string path = @"DataLog.txt";

            //Sletter og asserter
            File.Delete("DataLog.txt");
            Assert.IsFalse(File.Exists(path));

            //Kalder og asserter.
            //_uut.DataLog("Test");
            //Assert.IsTrue(File.Exists(path));
        }

        [TestCase("CC456", "DD789", "11/20/2018", "11/20/2018", 63.14262, 64.52742, 12300, 12500, 79000, 80000, 11000, 10000)]
        public void LogFile_WriteFileDoesExist_ReturnTrue_Real(string tag1, string tag2, string time, string time2, double nav, double nav2, int lat, int lat2, int lon, int lon2, int alt, int alt2)
        {
            _fakeFlightTrack = new FlightTrack("AA123")
            {
                LatestTime = DateTime.Parse(time, CultureInfo.CreateSpecificCulture("eu-EU")),
                NavigationCourse = nav,
                Position = new Position()
                {
                    Latitude = lat,
                    Longitude = lon,
                    Altitude = alt,
                },
                Tag = tag1,
            };
            
            _fakeFlightTrack1 = new FlightTrack("BB123")
            {
                LatestTime = DateTime.Parse(time2, CultureInfo.CreateSpecificCulture("eu-EU")),
                NavigationCourse = nav2,
                Position = new Position()
                {
                    Latitude = lat2,
                    Longitude = lon2,
                    Altitude = alt2,
                },
                Tag = tag2,
            };
            
            Tuple<IFlightTrack, IFlightTrack> wf = new Tuple<IFlightTrack, IFlightTrack>(_fakeFlightTrack, _fakeFlightTrack1);
            
            string path = @"DataLog.txt";
            
            File.Delete("DataLog.txt");
            _uut.DataLog(wf);
            var writeFileDoesExist = (File.Exists(path));

            Assert.That(writeFileDoesExist, Is.EqualTo(true));
            
        }
        
        
        [Test]
        //TestKomponent -> Scenarie -> Forventning
        public void LogFile_WriteFileDoesExist_ReturnTrue()
        {
            string path = @"DataLog.txt";
            
            File.Delete("DataLog.txt");
            _uut.DataLog("Test Besked");
            var writeFileDoesExist = (File.Exists(path));

            Assert.That(writeFileDoesExist, Is.EqualTo(true));
        }
        
        //[Test]
        //TODO: public void LogFile_LogNewEvent_ReturnString()
        
    }
}
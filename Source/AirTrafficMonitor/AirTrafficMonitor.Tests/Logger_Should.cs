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
        
        [SetUp]
        public void Setup()
        {
            _uut = new Logger();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete("DataLog.txt");
        }

        [Test]
        public void LogFile_WriteFileDoesntExist_ReturnTrue()
        {
            string path = @"DataLog.txt";

            Assert.IsFalse(File.Exists(path));

            //_uut.DataLog("Test");
            //Assert.IsTrue(File.Exists(path));
        }

        [TestCase("CC456", "DD789", 2018, 11, 22, 2018, 11, 22, 63.14262, 64.52742, 12300, 12500, 79000, 80000, 11000, 10000)]
        public void LogFile_WriteFileDoesExist_ReturnTrue_Real(string tag1, string tag2, int year, int month, int day, int year2, int month2, int day2, double nav, double nav2, int lat, int lat2, int lon, int lon2, int alt, int alt2)
        {
            IFlightTrack fakeFlightTrack = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag1);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year, month, day));
            fakeFlightTrack.NavigationCourse.Returns(nav);
            fakeFlightTrack.Position.Returns(new Position(lat, lon, alt));
            
            IFlightTrack fakeFlightTrack1 = Substitute.For<IFlightTrack>();
            fakeFlightTrack.Tag.Returns(tag2);
            fakeFlightTrack.LatestTime.Returns(new DateTime(year2, month2, day2));
            fakeFlightTrack.NavigationCourse.Returns(nav2);
            fakeFlightTrack.Position.Returns(new Position(lat2, lon2, alt2));
            
            Tuple<IFlightTrack, IFlightTrack> wf = new Tuple<IFlightTrack, IFlightTrack>(fakeFlightTrack, fakeFlightTrack1);
            
            string path = @"DataLog.txt";
            
            _uut.DataLog("wf");
            var writeFileDoesExist = (File.Exists(path));

            Assert.That(writeFileDoesExist, Is.True);
            
        }
        
        
        [Test]
        public void LogFile_WriteFileDoesExist_ReturnTrue()
        {
            string path = @"DataLog.txt";
            
            _uut.DataLog("Test Besked");
            var writeFileDoesExist = (File.Exists(path));

            Assert.That(writeFileDoesExist, Is.True);
        } 
    }
}
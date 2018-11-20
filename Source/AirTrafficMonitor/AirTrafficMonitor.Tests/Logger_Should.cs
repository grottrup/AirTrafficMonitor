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
        private FlightTrack _fakeFlightTrack;
        private FlightTrack _fakeFlightTrack1;
        

//TODO: Ændre test til selve koden og ikke testkoden
        
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

        [Test]
        public void LogFile_WriteFileDoesExist_ReturnTrue_Real()
        {
            _fakeFlightTrack = new FlightTrack("AA123");
            
            _fakeFlightTrack1 = new FlightTrack("BB123");
            
            Tuple<FlightTrack, FlightTrack> wf = new Tuple<FlightTrack, FlightTrack>(_fakeFlightTrack,_fakeFlightTrack1);
            
            string path = @"DataLog.txt";
            
            File.Delete("DataLog.txt");
            _uut.DataLog("wf");
            var writeFileDoesExist = (File.Exists("DataLog.txt"));

            Assert.That(writeFileDoesExist, Is.EqualTo(true));
            
        }
        
        
        [Test]
        //TestKomponent -> Scenarie -> Forventning
        public void LogFile_WriteFileDoesExist_ReturnTrue()
        {
            string path = @"DataLog.txt";
            
            File.Delete("DataLog.txt");
            _uut.DataLog("Test Besked");
            var writeFileDoesExist = (File.Exists("DataLog.txt"));

            Assert.That(writeFileDoesExist, Is.EqualTo(true));
        }
        
        //[Test]
        //TODO: public void LogFile_LogNewEvent_ReturnString()
        
    }
}
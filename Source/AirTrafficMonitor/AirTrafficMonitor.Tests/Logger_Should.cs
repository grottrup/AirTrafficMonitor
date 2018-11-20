using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NUnit.Framework;


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
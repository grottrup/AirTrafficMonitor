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
        public void LogFile_WriteFileDoesntExist()
        {
            string fileName = "DataLog.txt";

            Assert.IsFalse(File.Exists(fileName));
        }

        [TestCase("CC456")]
        public void LogFile_WriteFileDoesExist_ReturnTrue_Real(string loggingStr)
        {
            
            string path = "DataLog.txt";
            
            _uut.DataLog(loggingStr);
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
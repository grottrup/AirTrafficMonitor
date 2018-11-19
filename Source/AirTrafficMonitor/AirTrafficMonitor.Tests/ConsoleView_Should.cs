using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NUnit.Framework;

/*namespace AirTrafficMonitor.Tests
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

        [TestCase("AA123","BB123", "11-08-2018", "Warning, two planes are currently on collision course! " +
                                                                "\n Plane Tag: AA123 and plane Tag: BB123\n Current time: 11-08-2018 00:00:00\r\n")]
        [TestCase("CC123", "DD123", "11-09-2018", "Warning, two planes are currently on collision course! " +
                                                  "\n Plane Tag: CC123 and plane Tag: DD123\n Current time: 11-09-2018 00:00:00\r\n")]

        public void ConsoleView_test_that_it_prints(Tuple<FlightTrack, FlightTrack)
        {
            
            var _currentConsoleOut = Console.Out;
            ConsoleView flightsInCollision = flight1, flight2;

            using (var consoleOutput = new ConsoleOutput())
            {
                _uut.RenderCollision(flightsInCollision);
                Assert.AreEqual(outputstring, ConsoleOutput.GetOutput());
            }

            Assert.AreEqual(_currentConsoleOut, Console.Out);
        }
    }
}*/

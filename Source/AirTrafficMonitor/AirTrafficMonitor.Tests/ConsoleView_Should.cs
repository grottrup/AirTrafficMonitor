using System;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
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
            var fakeConsole = Substitute.For<IConsole>();
            _uut = new ConsoleView(fakeConsole);
        }
       
        [TestCase("AA123")]
        public void RenderCollision_OfTwoFlightTracks(string renderStr)
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                //_uut.AddToRenderWithColor(ff.Item1.ToString() + "&" + ff.Item2.ToString(), ConsoleColor.Blue);
                
                //var result = ConsoleOutput.GetOutput();
                //Assert.That(result, Does.Contain("Danger").IgnoreCase);
                //Assert.That(result, Does.Contain(year.ToString()));
                //Assert.That(result, Does.Contain(month.ToString()));
                //Assert.That(result, Does.Contain(day.ToString()));
                //Assert.That(result, Does.Contain(tag1));
                //Assert.That(result, Does.Contain(tag2));
            }
        }

        [TestCase("CC456")]
        public void RenderGivenString(string renderStr)
        {
            var currentConsoleOut = Console.Out;
            
            using (var consoleOutput = new ConsoleOutput())
            {
                _uut.AddToRenderWithColor(renderStr, ConsoleColor.DarkGray);
                var result = ConsoleOutput.GetOutput();
                Assert.That(result, Does.Contain(renderStr));
            }
        }
    }
}
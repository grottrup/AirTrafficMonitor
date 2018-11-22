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
        private IConsole _fakeConsole;
        
        [SetUp]
        public void Setup()
        {
            _fakeConsole = Substitute.For<IConsole>();
            _uut = new ConsoleView(_fakeConsole);
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

        [TestCase("CC456")]
        public void RemovesGivenString(string renderStr)
        {
            var currentConsoleOut = Console.Out;
            
            using (var consoleOutput = new ConsoleOutput())
            {                
                //act
                _uut.RemoveFromRender(renderStr);
                
                
                var result = ConsoleOutput.GetOutput();
                _fakeConsole.Received().Clear();
            }
        }
    }
}
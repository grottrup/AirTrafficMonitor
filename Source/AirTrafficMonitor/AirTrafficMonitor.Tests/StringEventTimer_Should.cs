using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ILogger = Castle.Core.Logging.ILogger;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    class StringEventTimer_Should
    {
        private ITimer _uut;
        private FakeTimerSub _fakeTimerSub;

        [SetUp]
        public void Setup()
        {
            _fakeTimerSub = Substitute.For<FakeTimerSub>();
        }

        [TestCase(5000,"render this")]
        public void some_test(int timer, string renderstr)
        {
            _uut = new StringEventTimer(timer, renderstr);
            _uut.Elapsed += _fakeTimerSub.CountTheEvent;

            System.Threading.Thread.Sleep(6000);

            Assert.That(_fakeTimerSub.EventCounter, Is.EqualTo(1));

        }

        [TestCase(5000, "render this")]
        public void some_test1(int timer, string renderstr)
        {
            _uut = new StringEventTimer(timer, renderstr);
            _uut.Elapsed += _fakeTimerSub.CountTheEvent;

            Assert.That(_fakeTimerSub.EventCounter, Is.EqualTo(0));

        }

    }

    public class FakeTimerSub
    {
        public int EventCounter = 0;

        //testing of event by a subscriber that we can call .Recieved on
        public void CountTheEvent(object source, ElapsedEventArgsWithString e)
        {
            EventCounter++;
        }
    }
}

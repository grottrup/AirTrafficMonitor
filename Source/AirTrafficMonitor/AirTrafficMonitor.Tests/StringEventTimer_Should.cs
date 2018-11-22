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
        public void StringEventTimer_Is_Triggered(int timer, string renderstr)
        {
            _uut = new StringEventTimer(timer, renderstr);
            _uut.Elapsed += _fakeTimerSub.CountTheEvent;

            System.Threading.Thread.Sleep(6000);

            Assert.That(_fakeTimerSub.EventCounter, Is.EqualTo(1));

        }

        [TestCase(5000, "render this")]
        public void StringEventTimer_Is_Not_Triggered_Before_Time(int timer, string renderstr)
        {
            _uut = new StringEventTimer(timer, renderstr);
            _uut.Elapsed += _fakeTimerSub.CountTheEvent;

            Assert.That(_fakeTimerSub.EventCounter, Is.EqualTo(0));

        }


        [TestCase(5000, "render this")]
        public void StringEventTimer_HandleString(int timer, string renderstr)
        {
            _uut = new StringEventTimer(timer, renderstr);
            _uut.Elapsed += _fakeTimerSub.CountTheEvent;

            System.Threading.Thread.Sleep(6000);
            Assert.That(_fakeTimerSub.renderstr, Is.EqualTo(renderstr));

        }

    }

    public class FakeTimerSub
    {
        public int EventCounter = 0;
        public string renderstr = null;
        public void CountTheEvent(object source, ElapsedEventArgsWithString e)
        {
            renderstr = e.StringToHandle;
            EventCounter++;
        }
    }
}

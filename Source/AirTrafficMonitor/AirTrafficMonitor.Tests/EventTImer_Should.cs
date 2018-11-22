using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using AirTrafficMonitor.Utilities;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Timer = System.Threading.Timer;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    class EventTimer_Should
    {
       
        private ITimer _timer;
        //private IView _fakeView;
        //private  IFlightObserver _observerEvents;
        //private AirspaceEventHandler _fakeAirspaceEventHandlerEventHandler;
        //private FlightTrack _fakeTrack;
        //private List<FlightTrack> _fakeFlightTracks;


        [SetUp]
        public void Setup()
        {
           // _fakeView = Substitute.For<IView>();
           // _observerEvents = Substitute.For<IFlightObserver>();
            _timer = Substitute.For<ITimer>();
           // _fakeFlightTracks = Substitute.For<List<FlightTrack>>();
           // //_timer = new EventTimer(5000);
           //_fakeTrack = Substitute.For<FlightTrack>(" ");
           //_fakeAirspaceEventHandlerEventHandler = Substitute.For<AirspaceEventHandler>(_fakeView, _observerEvents);
        }

        [Test]
        public void Timer_test_Interval_5s()
        {
            double tm = 5000;
            
            //_uut = new EventTimer(5000);

            
            //Assert.That(tm.Equals(_uut._interval));
        }

        [Test]
        public void Timer_Event_received_Elapsed()
        {
            //var timerFake = Substitute.For<ITimer>();
            //var wasCalled = false;
            //timerFake.Elapsed += (sender, args) => wasCalled = true;
            //timerFake.Elapsed += Raise.Event()
            //timerFake.Elapsed += Raise.EventWith(timerFake, ElapsedEventArgs(timerFake.Elapsed));
        }
    }
}

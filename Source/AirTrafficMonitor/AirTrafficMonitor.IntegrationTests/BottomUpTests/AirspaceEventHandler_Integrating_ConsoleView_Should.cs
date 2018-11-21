using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.IntegrationTests.BottomUpTests
{
    [TestFixture]
    public class AirspaceEventHandler_Integrating_ConsoleView_Should
    {
        private AirspaceEventHandler _airspaceEventHandler;
        private IView _View;
        private IFlightObserver _fakeFlightObserver;
        private IFlightTrack _fakeFlightTrack;
        private List<IFlightTrack> _fakeFlightTracks;
        [SetUp]
        public void Setup()
        {
            _fakeFlightTracks = Substitute.For<List<IFlightTrack>>();
            _fakeFlightTrack = Substitute.For<IFlightTrack>();
            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            _View = new ConsoleView();
            _airspaceEventHandler = new AirspaceEventHandler(_fakeFlightObserver, _View);
        }

        [Test]
        public void AirspaceEvent_View_Recived()
        {

            _fakeFlightTrack = new FlightTrack("BB123")
            {
                Position = new Position(11000, 910000, 5000),
                LatestTime = DateTime.MinValue
            };

            _fakeFlightTracks = new List<IFlightTrack>();
            _fakeFlightObserver.LeftAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(_fakeFlightTrack));

           
        }
    }
}

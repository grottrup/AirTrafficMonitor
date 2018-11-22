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

namespace AirTrafficMonitor.IntegrationTests.BottomUpTests
{
    /// <summary>
    /// Integration step 4
    /// </summary>
    [TestFixture]
    public class AirspaceEventHandler_Integrating_ConsoleView_DependingOn_FlightTracks_Should
    {
        private AirspaceEventHandler _sut;
        private ConsoleView _ssut_view;
        private IFlightObserver _fakeFlightObserver;
        private ISeperationHandler _fakeSeparationHandler;

        [SetUp]
        public void Setup()
        {
            _fakeSeparationHandler = Substitute.For<ISeperationHandler>();
            _fakeFlightObserver = Substitute.For<IFlightObserver>();
            var fakeConsole = Substitute.For<IConsole>();
            var fakeLogger = Substitute.For<Infrastructure.ILogger>();
            _ssut_view = new ConsoleView(fakeConsole);
            _sut = new AirspaceEventHandler(_fakeFlightObserver, _ssut_view, fakeLogger, _fakeSeparationHandler);
        }

        [TestCase("AA123")]
        public void LeftAirspace_Adds_To_WhatShouldBeShow(string tag1)
        {
            // arrange
            IFlightTrack track = new FlightTrack(tag1)
            {
                LatestTime = new DateTime(2018, 1, 1),
                NavigationCourse = double.NaN,
                Position = new Position(0, 0, 0),
                Velocity = 0
            };

            //act
            _fakeFlightObserver.LeftAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(track));

            //assert
            Assert.That(_ssut_view.ThingsToRender.First().Item1, Does.Contain(tag1));
        }

        [TestCase("AA123")]
        public void EnterAirspace_Adds_To_WhatShouldBeShow(string tag1)
        {
            // arrange
            IFlightTrack track = new FlightTrack(tag1)
            {
                LatestTime = new DateTime(2018, 1, 1),
                NavigationCourse = double.NaN,
                Position = new Position(0, 0, 0),
                Velocity = 0
            };

            //act
            _fakeFlightObserver.EnteredAirspace += Raise.EventWith(_fakeFlightObserver, new FlightTrackEventArgs(track));

            //assert
            Assert.That(_ssut_view.ThingsToRender.First().Item1, Does.Contain(tag1));
        }

        [TestCase("AA123", "BB123")]
        public void ProximityEvent_Adds_To_WhatShouldBeShow(string tag1, string tag2)
        {
            // arrange
            IFlightTrack track1 = new FlightTrack(tag1)
            {
                LatestTime = new DateTime(2018, 1, 1),
                NavigationCourse = double.NaN,
                Position = new Position(0, 0, 0),
                Velocity = 0
            };

            IFlightTrack track2 = new FlightTrack(tag2)
            {
                LatestTime = new DateTime(2018, 1, 1),
                NavigationCourse = double.NaN,
                Position = new Position(0, 0, 0),
                Velocity = 0
            };

            //act
            _fakeSeparationHandler.FlightsInProximity += Raise.EventWith(_fakeSeparationHandler, new FlightInProximityEventArgs(new Tuple<IFlightTrack, IFlightTrack>( track1, track2)));

            //assert
            Assert.That(_ssut_view.ThingsToRender.First().Item1, Does.Contain(tag1));
            Assert.That(_ssut_view.ThingsToRender.First().Item1, Does.Contain(tag2));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public class SeparationHandler : ISeperationHandler
    {
        public event EventHandler<FlightInProximityEventArgs> FlightsInProximity;
        private ILogger _logger;
        private IView _view;


        public SeparationHandler(ILogger logger, IView view)
        {
            _logger = logger;
            _view = view;
        }

        public void DetectCollision(ICollection<IFlightTrack> tracks)
        {
            foreach (var track1 in tracks)
            {
                foreach (var track2 in tracks)
                {
                    if (IsInCloseAirspace(track1, track2) && WithinTimespan(track1, track2) && track1.Tag != track2.Tag)
                    {
                        var args = new FlightInProximityEventArgs(new Tuple<IFlightTrack, IFlightTrack>(track1, track2));
                        FlightsInProximity?.Invoke(this, args);
                    }
                }
            }
            
        }

        private bool IsInCloseAirspace(IFlightTrack track1, IFlightTrack track2)
        {
            var altitudeMeter = 300;
            var horizontitalPlaneMeter = 500;
            return CalculateHorizontialDistance(track1, track2) < 5000 && CalculateVerticalDistance(track1, track2) < altitudeMeter;
        }

        private bool WithinTimespan(IFlightTrack track1, IFlightTrack track2)
        {
            TimeSpan interval = new TimeSpan(0, 0, 3); // 3 seconds

            if (track1.LatestTime - track2.LatestTime <= interval)
            {
                return true;
            }
            return false;
        }

        private double CalculateHorizontialDistance(IFlightTrack track1, IFlightTrack track2) //checks if new FlightTrack update's position is too close to any other flight
        {
            return Math.Round(Math.Abs(Math.Pow(track1.Position.Latitude - track2.Position.Latitude, 2)
                                + Math.Pow(track1.Position.Longitude - track2.Position.Longitude, 2)));
        }

        private double CalculateVerticalDistance(IFlightTrack track1, IFlightTrack track2) //checks if new FlightTrack update's altitude is too close to any other flight
        {
            return Math.Abs(track1.Position.Altitude - track2.Position.Altitude);
        }
    }
}

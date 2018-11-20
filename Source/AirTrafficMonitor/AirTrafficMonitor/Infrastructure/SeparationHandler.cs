using System;
using System.Collections.Generic;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public class SeparationHandler : ISeperationHandler
    {
        private List<FlightTrack> ProximityList;
        private readonly ILogger _logger;

        public event EventHandler<FlightInProximityEventArgs> FlightsInProximity;

        public SeparationHandler(ILogger logger)
        {
            _logger = logger;
        }

        public class FlightInProximityEventArgs : EventArgs
        {
            public FlightTrack FlightTrack { get; private set; }
            private List<FlightTrack> ProximityList;

            public FlightInProximityEventArgs(List<FlightTrack> tracks)
            {
                ProximityList = tracks;
            }
        }

        protected virtual void OnFlightsInProximity(FlightInProximityEventArgs eventArgs)
        {
            EventHandler<FlightInProximityEventArgs> handler = FlightsInProximity;

            handler?.Invoke(this, eventArgs);
        }

        public bool IsTimeEqual(List<FlightTrack> tracks)
        {
            for (int i = 0; i < tracks.Count - 1; i++)
            {
                return tracks[i].LatestTime == tracks[i + 1].LatestTime;
            }
            return false;
        }

        public double CalculateHorizontialDistance(List<FlightTrack> tracks)
        {
            for (int i = 0; i < tracks.Count - 1; i++)
            {
                return Math.Round(Math.Abs(Math.Pow(tracks[i].Position.Latitude - tracks[i + 1].Position.Latitude, 2)
                                    + Math.Pow(tracks[i].Position.Longitude - tracks[i + 1].Position.Longitude, 2)));
            }
            return 0;
        }

        public double CalculateVerticalDistance(List<FlightTrack> tracks)
        {
            for (int i = 0; i < tracks.Count - 1; i++)
            {
                return Math.Abs(tracks[i].Position.Altitude - tracks[i + 1].Position.Altitude);
            }
            return 0;
        }

        public void DetectCollision(List<FlightTrack> tracks)
        {
            if (IsTimeEqual(tracks))
            {
                if (CalculateHorizontialDistance(tracks) < 5000 && CalculateVerticalDistance(tracks) < 300)
                {

                    for (int i = 0; i < tracks.Count - 1; i++)
                    {
                        var args = new FlightInProximityEventArgs(tracks);
                        OnFlightsInProximity(args);

                        //OnFlightsInProximity(new FlightInCollision(tracks[i].Tag, tracks[i + 1].Tag, tracks[i].LatestTime));
                    }
                }
            }
        }
    }
}

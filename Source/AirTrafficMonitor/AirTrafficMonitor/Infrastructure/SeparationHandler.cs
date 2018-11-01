using System;
using System.Collections.Generic;
using System.Linq;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public class SeparationHandler : ISeperationHandler
    {
        private List<FlightTrack> ProximityList;
        private readonly ILogger _logger;

        public event EventHandler<FlightInCollision> FlightsInProximity;

        public SeparationHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected virtual void OnFlightsInProximity(FlightInCollision eventArgs)
        {
            EventHandler<FlightInCollision> handler = FlightsInProximity;

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
                        OnFlightsInProximity(new FlightInCollision(tracks[i].Tag, tracks[i + 1].Tag,
                            tracks[i].LatestTime));
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public class SeparationHandler : ISeperationHandler
    {
        private readonly List<IFlightTrack> _flightsInProximityList;
        private readonly ILogger _logger;

        public event EventHandler<Tuple<IFlightTrack, IFlightTrack>> FlightsInProximity;

        public SeparationHandler(ILogger logger)
        {
            _logger = logger;
        }

        protected virtual void OnFlightsInProximity(Tuple<IFlightTrack, IFlightTrack> eventArgs)
        {
            EventHandler<Tuple<IFlightTrack, IFlightTrack>> handler = FlightsInProximity;

            handler?.Invoke(this, eventArgs);
        }

        public double CalculateHorizontialDistance(ICollection<IFlightTrack> tracks) // Wrong
        {
            for (int i = 0; i < tracks.Count - 1; i++)
            {
                return Math.Round(Math.Abs(Math.Pow(tracks.First().Position.Latitude - tracks.Last().Position.Latitude, 2)
                                    + Math.Pow(tracks.First().Position.Longitude - tracks.Last().Position.Longitude, 2)));
            }
            return 0;
        }

        public double CalculateVerticalDistance(ICollection<IFlightTrack> tracks) //Wrong
        {
            for (int i = 0; i < tracks.Count - 1; i++)
            {
                return Math.Abs(tracks.First().Position.Altitude - tracks.Last().Position.Altitude);
            }
            return 0;
        }

        public void DetectCollision(ICollection<IFlightTrack> tracks) //????
        {
            if(false)//just make false so mike can continue coding
            {
                if (CalculateHorizontialDistance(tracks) < 5000 && CalculateVerticalDistance(tracks) < 300) // TODO dont use magic numbers!!!!! :<
                {
                    for (int i = 0; i < tracks.Count - 1; i++)
                    {
                        OnFlightsInProximity(new Tuple<IFlightTrack, IFlightTrack>(tracks.First(), tracks.Last()));
                    }
                }
            }
            
        }
    }
}

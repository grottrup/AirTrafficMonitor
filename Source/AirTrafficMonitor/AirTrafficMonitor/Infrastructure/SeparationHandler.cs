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

        public SeparationHandler()
        {
        }

        public void DetectCollision(Tuple<IFlightTrack, IFlightTrack> tracks)
        {
            if (WithinTimespan(tracks))//checks if new FlightTrack update is close to any other flight.
            {
                if (CalculateHorizontialDistance(tracks) < 5000 && CalculateVerticalDistance(tracks) < 300) //checks if new FlightTrack update is too close to any other flight
                {
                    var args = new FlightInProximityEventArgs(tracks);
                    FlightsInProximity?.Invoke(this, args);

                }
            }
        }

        public bool WithinTimespan(Tuple<IFlightTrack, IFlightTrack> tracks) //checks if new FlightTrack update is close to any other flight.
        {
            TimeSpan interval = new TimeSpan(0, 2, 0);

            if (tracks != null)
            {
                if (tracks.Item1.LatestTime - tracks.Item2.LatestTime <= interval)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public double CalculateHorizontialDistance(Tuple<IFlightTrack, IFlightTrack> tracks) //checks if new FlightTrack update's position is too close to any other flight
        {
            return Math.Round(Math.Abs(Math.Pow(tracks.Item1.Position.Latitude - tracks.Item2.Position.Latitude, 2)
                                + Math.Pow(tracks.Item1.Position.Longitude - tracks.Item2.Position.Longitude, 2)));
        }

        public double CalculateVerticalDistance(Tuple<IFlightTrack, IFlightTrack> tracks) //checks if new FlightTrack update's altitude is too close to any other flight
        {
            return Math.Abs(tracks.Item1.Position.Altitude - tracks.Item2.Position.Altitude);
        }
    }
}

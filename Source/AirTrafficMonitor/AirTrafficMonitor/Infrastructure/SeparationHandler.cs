using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Infrastructure
{
    public class SeparationHandler : ISeperationHandler
    {
        //private List<FlightTrack> ProximityList;
        private Tuple<IFlightTrack, IFlightTrack> ProximityList;
        private readonly ILogger _logger;

        public event EventHandler<FlightInProximityEventArgs> FlightsInProximity;

        public SeparationHandler(ILogger logger)
        {
            _logger = logger; //We do not use the logger. Is it neccessary in the constructor?
        }

        //Eventhandler
        protected virtual void OnFlightsInProximity(FlightInProximityEventArgs eventArgs)
        {
            EventHandler<FlightInProximityEventArgs> handler = FlightsInProximity;
            handler?.Invoke(this, eventArgs);
        }

        //Controller - Logic
        public void DetectCollision(Tuple<IFlightTrack, IFlightTrack> tracks)
        {
            if (WithinTimespan(tracks))//checks if new FlightTrack update is close to any other flight.
            {
                if (CalculateHorizontialDistance(tracks) < 5000 && CalculateVerticalDistance(tracks) < 300) //checks if new FlightTrack update is too close to any other flight
                {
                    //for (int i = 0; i < tracks - 1; i++)
                    //{
                        var args = new FlightInProximityEventArgs(tracks);
                        OnFlightsInProximity(args);

                        //OnFlightsInProximity(new FlightInCollision(tracks[i].Tag, tracks[i + 1].Tag, tracks[i].LatestTime));
                    //}
                }
            }
        }

        public bool WithinTimespan(Tuple<IFlightTrack, IFlightTrack> tracks) //checks if new FlightTrack update is close to any other flight.
        {   
            //for (int i = 0; i < tracks.Count - 1; i++)
            //{
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
            //}
            //return false;
        }

        public double CalculateHorizontialDistance(Tuple<IFlightTrack, IFlightTrack> tracks) //checks if new FlightTrack update's position is too close to any other flight
        {
            //for (int i = 0; i < tracks.Count - 1; i++)
            //{
                return Math.Round(Math.Abs(Math.Pow(tracks.Item1.Position.Latitude - tracks.Item2.Position.Latitude, 2)
                                    + Math.Pow(tracks.Item1.Position.Longitude - tracks.Item2.Position.Longitude, 2)));
            //}
            //return 0;
        }

        public double CalculateVerticalDistance(Tuple<IFlightTrack, IFlightTrack> tracks) //checks if new FlightTrack update's altitude is too close to any other flight
        {
            //for (int i = 0; i < tracks.Count - 1; i++)
            //{
                return Math.Abs(tracks.Item1.Position.Altitude - tracks.Item2.Position.Altitude);
            //}
            //return 0;
        }

    }
}

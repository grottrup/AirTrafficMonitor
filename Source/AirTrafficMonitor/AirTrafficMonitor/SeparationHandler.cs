using System;
using System.Collections.Generic;
using System.Linq;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor
{
    public class SeparationHandler : ISeperationHandler
    {

        public event EventHandler<FlightInCollision> FlightsInProximity;
        public List<FlightTrack> ProximityList;
        protected virtual void OnFlightsInProximity(FlightInCollision eventArgs)
        {
            EventHandler<FlightInCollision> handler = FlightsInProximity;

            handler?.Invoke(this, eventArgs);
        }

        public bool IstimeEquel(List<FlightTrack> tracks)
        {
                for (int i = 0; i < tracks.Count - 1; i++)
                {
                    return tracks[i].LatestTime == tracks[i + 1].LatestTime;
                }
            return false;
        }

        public double CalculateHorizontialDistance(List<FlightTrack> tracks)
        {
            for (int i = 0; i < tracks.Count-1; i++)
            {
                return Math.Round(Math.Abs(Math.Pow(tracks[i].Position.X - tracks[i + 1].Position.X, 2)
                                    + Math.Pow(tracks[i].Position.Y - tracks[i + 1].Position.Y, 2)));
            }
            return 0;
        }

        public double CalculateVerticalDistance(List<FlightTrack> tracks)
        {
            for (int i = 0; i < tracks.Count-1; i++)
            {
                return Math.Abs(tracks[i].Position.Altitude - tracks[i + 1].Position.Altitude);
            }
            return 0;
        }

        //public void UpdateIsProximity(List<FlightInCollision> tracks, bool addOrRemove)
        //{
        //    if (addOrRemove)
        //    {
        //        //add to list
                

        //    }
        //    else
        //    {
        //        //remove from list
        //    }
        //}

        public void DetectCollision(List<FlightTrack> tracks)
        {
            if (IstimeEquel(tracks))
            {
                if (CalculateHorizontialDistance(tracks) < 5000 && CalculateVerticalDistance(tracks) < 300 )
                {

                     for (int i = 0; i < tracks.Count - 1; i++)
                    { 
                            //if (!ProximityList.Contains(tracks[i]))
                            //{
                                OnFlightsInProximity(new FlightInCollision(tracks[i].Tag, tracks[i + 1].Tag,
                                    tracks[i].LatestTime));
                               // ProximityList.Add(tracks[i]);

                            //}
                           // else
                           // {
                                //ProximityList.Remove(tracks[i]);
                           // }

                     }
                    

                }
            }
        }


        //public flightincollision _flightincollisiondata;
        //public list<flightincollision> _flightincollisiondetected;
        //public ilogger _logger;



        //public SeparationHandler(FlightInCollision flightInCollisionData, ILogger logger)
        //{
        //    _flightInCollisionData = flightInCollisionData;
        //    _FlightInCollisionDetected = new List<FlightInCollision>();
        //    _Logger = logger;
        //}

        //public void DetectCollision(List<FlightTrack> tracks)
        //{

        //        if (TagState(tracks))
        //         {
        //             if (TimeState(tracks))
        //             {
        //                 if (Verticaldistance(tracks) < 300 && Horizontaldistance(tracks) < 5000)
        //                 {

        //                         for (int i = 0; i < tracks.Count - 1; i++)
        //                         {

        //                             _flightInCollisionData.Tag1 = tracks[i]._records[tracks[i]._records.Count - 1].Tag;
        //                             _flightInCollisionData.Tag2 =
        //                                 tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Tag;
        //                             _flightInCollisionData.TimeStamp =
        //                                 tracks[i]._records[tracks[i]._records.Count - 1].Timestamp;

        //                             _FlightInCollisionDetected.Add(_flightInCollisionData);

        //                             _Logger.DataLog(_flightInCollisionData.Tag1, _flightInCollisionData.Tag2, _flightInCollisionData.TimeStamp);
        //                             //_Logger.ConsoleLog(_flightInCollisionData.Tag1, _flightInCollisionData.Tag2, _flightInCollisionData.TimeStamp);
        //                         }


        //                 }
        //             }
        //         }
        //}

        //public bool TagState(List<FlightTrack> tracks)
        //{
        //    if (tracks.Count != 0)
        //    {
        //        for (int i = 0; i < tracks.Count - 1; i++)
        //        {

        //            return tracks[i]._records[tracks[i]._records.Count - 1].Tag !=
        //                   tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Tag;
        //        }
        //    }

        //    return false;
        //}
        //public bool TimeState(List<FlightTrack> tracks)
        //{
        //    if (tracks.Count != 0)
        //    { 
        //        for (int i = 0; i < tracks.Count-1; i++)
        //        {
        //            return tracks[i]._records[tracks[i]._records.Count - 1].Timestamp ==
        //                   tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Timestamp;
        //        }
        //    }

        //    return false;

        //}
        //public double Horizontaldistance(List<FlightTrack> tracks)
        //{
        //    if (tracks.Count != 0)
        //    { 
        //        for (int i = 0; i < tracks.Count-1; i++)
        //        {
        //            return Math.Round(Math.Abs(Math.Pow(tracks[i]._records[tracks[i]._records.Count - 1].Position.X - tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Position.X, 2) 
        //                                       + Math.Pow(tracks[i]._records[tracks[i]._records.Count - 1].Position.Y - tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Position.Y, 2)));
        //        }
        //    }

        //    return 0;
        //}
        //public double Verticaldistance(List<FlightTrack> tracks)
        //{
        //    if (tracks.Count != 0)
        //    { 
        //        for (int i = 0; i < tracks.Count-1; i++)

        //        {
        //            return Math.Abs(tracks[i]._records[tracks[i]._records.Count - 1].Altitude -
        //                            tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Altitude);
        //        }
        //    }

        //    return 0;
        //}
    }
}

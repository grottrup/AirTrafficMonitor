using System;
using System.Collections.Generic;
using System.Linq;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor
{
    public class SeparationHandler : ISeperationHandler
    {

        public FlightInCollision _flightInCollisionData;
        public List<FlightInCollision> _FlightInCollisionDetected;
        public ILogger _Logger;

        public void DetectCollision(List<FlightTrack> tracks)
        {
            throw new NotImplementedException();
        }

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

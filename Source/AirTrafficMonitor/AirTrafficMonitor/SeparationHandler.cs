using System;
using System.Collections.Generic;
using AirTrafficMonitor.View;

namespace AirTrafficMonitor
{
    public class SeparationHandler : ISeperationHandler
    {
        //private SeparationData _separationData;
        //public event EventHandler SeparationAlert;
        //public SubscribePls = new AirTrafficMonitor.Observer;
        //public void Update(AirTrafficRecord update)
        //{
        //}
        public bool State = false;
        public int buf = 0;
        public void DetectCollision(List<FlightTrack> tracks)
        {
            foreach (var flights in tracks)
            {
                for (int i = 0; i < tracks.Count - 1; i++)
                {
                    if (tracks[i]._records[tracks[i]._records.Count - 1].Timestamp == tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Timestamp)
                    {   //Beregn hori dist
                        var HorizontialDistance = Math.Abs(Math.Sqrt(
                            Math.Pow(tracks[i]._records[tracks[i]._records.Count - 1].Position.X - tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Position.X, 2) +
                            Math.Pow(tracks[i]._records[tracks[i]._records.Count - 1].Position.Y - tracks[i]._records[tracks[i]._records.Count - 1].Position.Y, 2)));

                        var VerticalDistance =
                            Math.Abs(tracks[i]._records[tracks[i]._records.Count - 1].Altitude - tracks[i + 1]._records[tracks[i + 1]._records.Count - 1].Altitude);

                        if (VerticalDistance < 300 && HorizontialDistance < 5000)
                        {
                            Console.WriteLine("JUHUUU eller AAH NEJ");

                            //handler

                            //tate = true;

                            //tracks > _record = fly.tag > ATRecord > Data

                        }
                        else
                            continue;
                    }
                    else
                        continue;
                }
            }
        }
    }
}
using AirTrafficMonitor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Util
{
    public static class TrackListRecordSorter
    {
        public static void SortRecordByTag(this List<FlightTrack> tracks, FlightRecord update)
        {
            if (!tracks.Any(track => track.Tag == update.Tag))
            {
                var newTrack = new FlightTrack(update.Tag);
                newTrack.Add(update);
                tracks.Add(newTrack);
            }
            else
            {
                foreach (var track in tracks)
                {
                    if (track.Tag == update.Tag)
                    {
                        track.Add(update);
                    }
                }
            }
        }
    }
}

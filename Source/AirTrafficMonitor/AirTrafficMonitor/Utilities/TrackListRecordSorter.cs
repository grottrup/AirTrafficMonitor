using AirTrafficMonitor.Domain;
using System.Collections.Generic;
using System.Linq;

namespace AirTrafficMonitor.Utilities
{
    public static class TrackListRecordSorter
    {
        public static FlightTrack SortRecordByTag(this ICollection<FlightTrack> tracks, FlightRecord update)
        {
            if (!tracks.Any(track => track.Tag == update.Tag))
            {
                var newTrack = new FlightTrack(update.Tag);
                newTrack.Update(update);
                tracks.Add(newTrack);
                return newTrack;
            }
            else
            {
                var updatedTrack = tracks.First(track => track.Tag == update.Tag);
                updatedTrack.Update(update);
                return updatedTrack;
            }
        }
    }
}

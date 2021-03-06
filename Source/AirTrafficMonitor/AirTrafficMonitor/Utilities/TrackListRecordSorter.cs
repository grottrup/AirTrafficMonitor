﻿using AirTrafficMonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTrafficMonitor.Utilities
{
    public static class TrackListRecordSorter
    {
        public static IFlightTrack SortRecordByTag(this ICollection<IFlightTrack> tracks, FlightRecord update)
        {
            if (tracks == null)
                throw new ArgumentNullException(nameof(tracks));

            if (!tracks.Any(track => track.Tag == update.Tag))
            {
                IFlightTrack newTrack = new FlightTrack(update.Tag);
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

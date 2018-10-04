using System;
using System.Collections.Generic;
using AirTrafficMonitor.Observer;

namespace AirTrafficMonitor.View
{
    public class FlightObserver : Observer.IObserver<FlightRecord> //might be deleted later
    {
        private readonly List<FlightTrack> _tracks;
        private readonly IView _view;
        private readonly ISeperationHandler _handler;
        private readonly Airspace _space;

        public FlightObserver(IView view, ISeperationHandler handler)
        {
            _view = view;
            _handler = handler;
            _tracks = new List<FlightTrack>();
            _space = new Airspace();
        }

        public void Update(FlightRecord update)
        {
            if (update.Position.IsWithin(_space))
            {
                foreach (var track in _tracks)
                {
                    if (track.Tag == update.Tag)
                    {
                        track.Add(update);
                    }
                }
                _handler.DetectCollision(_tracks);
                _view.Render(update); //only update updated tracks
            }
            else{
                //code for when record is not in airspace
            }
        }
    }
}
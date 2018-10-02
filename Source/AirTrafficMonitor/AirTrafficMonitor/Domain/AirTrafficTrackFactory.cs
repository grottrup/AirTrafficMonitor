using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Domain
{

    public class AirTrafficTrackFactory : IAirTrafficTrackFactory
    {
        public AirTrafficRecord CreateRecord(string rawTrackData)
        {
            var split = rawTrackData.Split(';');
            var track = new AirTrafficRecord(rawTrackData) //remove raw
            {
                Position = new Position(Int32.Parse(split[1]), Int32.Parse(split[2]))
            };
            return track;
        }
    }
}

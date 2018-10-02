using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Domain
{

    public class FlightRecordFactory : IAirTrafficTrackFactory
    {
        public AirTrafficRecord CreateRecord(string rawTrackData)
        {
            var flightDataSplitArr = rawTrackData.Split(';');

            var provider = CultureInfo.InvariantCulture;
            var format = "yyyyMMddhhmmssfff";
            DateTime time;
            DateTime.TryParseExact(flightDataSplitArr[4], format, provider,
                DateTimeStyles.None, out time);

            var record = new AirTrafficRecord(rawTrackData) //remove raw
            {
                Tag = flightDataSplitArr[0],
                Position = new Position(Int32.Parse(flightDataSplitArr[1]), Int32.Parse(flightDataSplitArr[2])),
                Altitude = Int32.Parse(flightDataSplitArr[3]),
                Timestamp = time
            };
            return record;
        }
    }
}
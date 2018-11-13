using AirTrafficMonitor.Domain;
using System;
using System.Globalization;

namespace AirTrafficMonitor.AntiCorruptionLayer
{

    public class FlightRecordFactory : IFlightRecordFactory
    {
        public FlightRecord CreateRecord(string rawRecordData)
        {
            var flightDataSplitArr = rawRecordData.Split(';');
            var provider = CultureInfo.InvariantCulture;
            var latitude = Int32.Parse(flightDataSplitArr[1], provider);
            var longitude = Int32.Parse(flightDataSplitArr[2], provider);
            var altitude = Int32.Parse(flightDataSplitArr[3], provider);

            var format = "yyyyMMddHHmmssfff";
            DateTime.TryParseExact(flightDataSplitArr[4], format, provider,
                DateTimeStyles.None, out var time);

            var record = new FlightRecord()
            {
                Tag = flightDataSplitArr[0],
                Position = new Position(latitude, longitude, altitude),
                Timestamp = time
            };
            return record;
        }
    }
}
﻿using AirTrafficMonitor.Domain;
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
            var format = "yyyyMMddHHmmssfff";
            DateTime.TryParseExact(flightDataSplitArr[4], format, provider,
                DateTimeStyles.None, out var time);

            var record = new FlightRecord()
            {
                Tag = flightDataSplitArr[0],
                Position = new Position(Int32.Parse(flightDataSplitArr[1]), Int32.Parse(flightDataSplitArr[2]), Int32.Parse(flightDataSplitArr[3])),
                Timestamp = time
            };
            return record;
        }
    }
}
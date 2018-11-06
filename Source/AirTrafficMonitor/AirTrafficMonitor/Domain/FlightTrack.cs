using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTrafficMonitor.Domain
{
    public class FlightTrack
    {
        private readonly Queue<FlightRecord> _records;

        public string Tag { get; }
        public DateTime LatestTime { get; private set; }
        public int NavigationCourse { get; private set; }
        public int Velocity { get; private set; }
        public Position Position { get; private set; }

        public FlightTrack(string tag)
        {
            Tag = tag;
            _records = new Queue<FlightRecord>(2);
        }

        public void Update(FlightRecord record)
        {
            if (record != null)
            {
                if(_records.Count == 2) _records.Dequeue();  
                _records.Enqueue(record);
                LatestTime = record.Timestamp;
                Position = record.Position;
                NavigationCourse = CalculateNavigationCourse();
                Velocity = 0;
            }
        }

        private int CalculateNavigationCourse()
        {
            if (_records.Count == 2)
            {
                int lon1 = _records.First().Position.Longitude;
                int lat1 = _records.First().Position.Latitude;
                int lon2 = _records.Last().Position.Longitude;
                int lat2 = _records.Last().Position.Latitude;
                int deltaLon = Math.Abs(lon1 - lon2);
                int deltaLat = Math.Abs(lat1 - lat2);
                if (deltaLat > 0)
                {
                    return (int) (90 - Math.Atan(Math.Sin(deltaLat / deltaLon)) * 180 / Math.PI);
                }
                else if (deltaLat < 0)
                {
                    return (int) (270 - Math.Atan(Math.Sin(deltaLon / deltaLat)) * 180 / Math.PI);
                }
                else if (deltaLat == 0 && deltaLon < 0) // south
                {
                    return 180;
                }
                else if (deltaLat == 0 && deltaLon > 0) // north
                {
                    return 0;
                }
            }
            return -1;
            //return (int)Math.Atan2(Math.Sin(deltaLon) * Math.Cos(lat2), Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(deltaLat));
        }

        public override string ToString()
        {
            return $"[Tag: {Tag}, Time: {LatestTime}, NavigationCourse: {NavigationCourse}, Position: {Position}]";
        }
    }
}
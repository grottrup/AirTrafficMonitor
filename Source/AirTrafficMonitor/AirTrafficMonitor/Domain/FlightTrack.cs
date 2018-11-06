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
        public double Velocity { get; private set; }
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
                Velocity = CalculateVelocity();
            }
        }

        private double CalculateVelocity()
        {
            if (_records.Count == 2)
            {
                var lon1 = _records.First().Position.Longitude;
                var lat1 = _records.First().Position.Latitude;
                var time1 = _records.First().Timestamp;

                var lon2 = _records.Last().Position.Longitude;
                var lat2 = _records.Last().Position.Latitude;
                var time2 = _records.Last().Timestamp;

                int deltaPosition = (int) Math.Sqrt(Math.Pow(lon1 - lon2, 2) + Math.Pow(lon2 - lat2, 2));

                double deltaTime = (time2 - time1).TotalSeconds;

                return deltaPosition / deltaTime;
            }

            return 0;
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
            return 0;
        }

        public override string ToString()
        {
            return $"[Tag: {Tag}, Time: {LatestTime}, NavigationCourse: {NavigationCourse}, Position: {Position}]";
        }
    }
}
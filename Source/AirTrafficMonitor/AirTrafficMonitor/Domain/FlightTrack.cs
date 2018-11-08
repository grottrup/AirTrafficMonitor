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
        public double NavigationCourse { get; private set; }
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

               int deltaPosition = (int) Math.Sqrt(Math.Pow(lon1 - lon2, 2) + Math.Pow(lat1 - lat2, 2));

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

                int deltaLon = (lon1 - lon2);
                int deltaLat = (lat1 - lat2);

                var radians = Math.Atan2(deltaLon, deltaLat);
                var course = (Math.Round((radians * (180 / Math.PI)),0));

                if (course < 0 && course<360)
                {
                    return (int) course + 360;
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
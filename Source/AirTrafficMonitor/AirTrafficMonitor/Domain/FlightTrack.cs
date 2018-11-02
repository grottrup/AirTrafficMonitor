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
        public int Course { get; private set; }
        public int Velocity { get; private set; }
        public Position Position { get; private set; }

        public FlightTrack(string tag)
        {
            Tag = tag;
            _records = new Queue<FlightRecord>(2);
        }

        public void Update(FlightRecord record)
        {
            if(_records.Count == 2) _records.Dequeue();  
            _records.Enqueue(record);
            LatestTime = record.Timestamp;
            Position = record.Position;
            Course = CalculateCourse();
        }

        private int CalculateCourse() // TODO: Test
        {
            int long1 = _records.First().Position.Longitude;
            int long2 = _records.Last().Position.Longitude;
            int lat1 = _records.First().Position.Latitude;
            int lat2 = _records.Last().Position.Latitude;
            int deltaLong = long1 - long2;
            int deltaLat = lat1 - lat2;
            return (int)Math.Atan2(Math.Sin(deltaLong) * Math.Cos(lat2), Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(deltaLat));
        }

        public override string ToString()
        {
            return $"[Tag: {Tag}, Time: {LatestTime}, Course: {Course}, Position: {Position}]";
        }
    }
}
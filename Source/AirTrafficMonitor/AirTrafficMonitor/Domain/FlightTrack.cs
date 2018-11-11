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
                if (_records.Count == 2) _records.Dequeue();
                _records.Enqueue(record);
                LatestTime = record.Timestamp;
                Position = record.Position;


                NavigationCourse = CalculateNavigationCourse(_records.First().Position.Latitude, _records.First().Position.Longitude, _records.Last().Position.Latitude, _records.Last().Position.Longitude);
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

                int deltaPosition = (int)Math.Sqrt(Math.Pow(lon1 - lon2, 2) + Math.Pow(lat1 - lat2, 2));

                double deltaTime = (time2 - time1).TotalSeconds;

                return deltaPosition / deltaTime;
            }

            return 0;
        }

        // http://mathforum.org/library/drmath/view/55417.html
        // https://aerocontent.honeywell.com/aero/common/documents/myaerospacecatalog-documents/Defense_Brochures-documents/Magnetic__Literature_Application_notes-documents/AN203_Compass_Heading_Using_Magnetometers.pdf
        private double CalculateNavigationCourse(int lat1, int lon1, int lat2, int lon2)
        {
            int deltaLat = (lat2 - lat1);
            int deltaLon = (lon2 - lon1);

            double course = double.NaN;

            if (deltaLat > 0)
            {
                if (deltaLon > 0) course = Math.Atan(deltaLat / deltaLon) * 180 / Math.PI;
                else if (deltaLon < 0) course = 180 + Math.Atan(deltaLat / deltaLon) * 180 / Math.PI;
                else if (deltaLon == 0) course = 90;
            }
            else if (deltaLat < 0)
            {
                if (deltaLon > 0) course = 270 - Math.Atan(deltaLat / deltaLon) * 180 / Math.PI;
                else if (deltaLon < 0) course = 180 + Math.Atan(deltaLat / deltaLon) * 180 / Math.PI;
                else if (deltaLon == 0) course = 270;
            }
            else if (deltaLat == 0)
            {
                if (deltaLon > 0) course = 0;
                else if (deltaLon < 0) course = 180;
                else if (deltaLon == 0) course = double.NaN;
            }
            return course;
        }

        public override string ToString()
        {
            return $"[Tag: {Tag}, Time: {LatestTime}, NavigationCourse: {NavigationCourse}, Position: {Position}]";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.View;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    class SeparationHandlerTest
    {
        private List<FlightTrack> tracks;
        private List<FlightInCollision> flightsFlightInCollisionsDetected;
        private FlightInCollision flightsCollisionData;
        private FlightTrack FT1, FT2, FT3, FT4, FT5, FT6;
        private FlightRecordFactory record;
        private SeparationHandler separation;

        [SetUp]
        public void SetUp()
        {
            tracks = new List<FlightTrack>();
            flightsFlightInCollisionsDetected = new List<FlightInCollision>();
            flightsCollisionData = new FlightInCollision();
            record = new FlightRecordFactory();
            separation = new SeparationHandler(flightsCollisionData);

            //Alt er ens untagen tag
            var record1 = record.CreateRecord("AAJ063;39563;95000;16800;20181001160609975");
            var record2 = record.CreateRecord("BBJ063;39563;95000;16800;20181001160609975");
            //Horizontial > 5000 Vertical < 300
            var record3 = record.CreateRecord("CGJ063;39563;95000;16800;20181001160609975");
            var record4 = record.CreateRecord("DGJ063;39563;95000;16800;20181001160609975");
            //alt er ens untagen tags. Dette er til at se om FlightInCollision liste.count = 2
            var record5 = record.CreateRecord("EEJ063;38563;90000;15800;20181001090605975");
            var record6 = record.CreateRecord("FFJ063;38563;90000;11800;20181001090609975");

            FT1 = new FlightTrack();
            FT2 = new FlightTrack();
            FT3 = new FlightTrack();
            FT4 = new FlightTrack();
            FT5 = new FlightTrack();
            FT6 = new FlightTrack();

            FT1._records.Add(record1);
            FT2._records.Add(record2);
            FT3._records.Add(record3);
            FT4._records.Add(record4);
            FT5._records.Add(record5);
            FT6._records.Add(record6);

            
        }
        //True da det er på samme tid
        
        // Vertical distance = 0

        [TestCase(TestName = "Test tag compare")]
        public void Test1()
        {
            tracks = new List<FlightTrack>() {FT1, FT2};

            separation.DetectCollision(tracks);
            Assert.IsTrue(separation.TagState(tracks));

            Assert.That(separation.TagState(tracks), Is.EqualTo(true));
        }
        [TestCase(TestName = "Test time compare")]
        public void Test2()
        {
            tracks = new List<FlightTrack>() { FT1, FT2 };

            separation.DetectCollision(tracks);

            Assert.IsTrue(separation.TimeState(tracks));
        }
        [TestCase(TestName = "Test horizontal compare")]
        public void Test3()
        {
            tracks = new List<FlightTrack>() { FT1, FT2 };

            separation.DetectCollision(tracks);
            // horizontial distance = 0

            Assert.That(separation.Horizontaldistance(tracks), Is.EqualTo(0));

        }
        [TestCase(TestName = "Test vertical compare")]
        public void Test4()
        {
            tracks = new List<FlightTrack> {FT1, FT2};

            separation.DetectCollision(tracks);
            
            Assert.That(separation.Verticaldistance(tracks), Is.EqualTo(0));

        }

        [TestCase(TestName = "Test its in list ")]
        public void Test5()
        {
            tracks = new List<FlightTrack> { FT1, FT2, FT5, FT6};

            separation.DetectCollision(tracks);

            Assert.That(separation._FlightInCollisionDetected.Count, Is.EqualTo(2));
            //Assert.That(flightsFlightInCollisionsDetected.Count, Is.EqualTo(2));
        }
    }
}

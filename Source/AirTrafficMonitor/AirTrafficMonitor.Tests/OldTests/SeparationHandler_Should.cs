//using System.Collections.Generic;
//using AirTrafficMonitor.AntiCorruptionLayer;
//using AirTrafficMonitor.Domain;
//using AirTrafficMonitor.Infrastructure;
//using NSubstitute;
//using NUnit.Framework;

//namespace AirTrafficMonitor.Tests.UnitTests
//{

//    [TestFixture]
//    class SeparationHandler_Should
//    {

//        private List<FlightTrack> tracks;
//        private List<FlightInCollision> flightsFlightInCollisionsDetected;
//        private FlightInCollision flightsCollisionData;
//        private FlightTrack FT1, FT2, FT3, FT4, FT5, FT6;
//        private FlightRecordFactory record;
//        private SeparationHandler separation;
//        private ILogger _fakeLogger;

//        [SetUp]
//        public void SetUp()
//        {
//            tracks = new List<FlightTrack>();
//            flightsFlightInCollisionsDetected = new List<FlightInCollision>();
//            record = new FlightRecordFactory();
//            _fakeLogger = Substitute.For<ILogger>();
//            separation = new SeparationHandler(_fakeLogger);


//            //Alt er ens untagen tag
//            var record1 = record.CreateRecord("AAJ063;39563;95000;16800;20181001160609975");
//            var record2 = record.CreateRecord("BBJ063;39563;95000;16800;20181001160609975");
//            //Horizontial > 5000 Vertical < 300
//            var record3 = record.CreateRecord("CGJ063;39563;95000;16800;20181001160609975");
//            var record4 = record.CreateRecord("DGJ063;39563;95000;16800;20181001160609975");
//            //alt er ens untagen tags. Dette er til at se om FlightInCollision liste.count = 2
//            var record5 = record.CreateRecord("EEJ063;38563;90000;15800;20181001090605975");
//            var record6 = record.CreateRecord("FFJ063;38563;90000;11800;20181001090609975");

//            FT1 = new FlightTrack(record1.Tag);
//            FT2 = new FlightTrack(record2.Tag);
//            FT3 = new FlightTrack(record3.Tag);
//            FT4 = new FlightTrack(record4.Tag);
//            FT5 = new FlightTrack(record5.Tag);
//            FT6 = new FlightTrack(record6.Tag);


//            FT1.Update(record1);
//            FT2.Update(record2);
//            FT3.Update(record3);
//            FT4.Update(record4);
//            FT5.Update(record5);
//            FT6.Update(record6);


//        }

//        [Test]
//        public void Istime()
//        {
//            tracks = new List<FlightTrack>() { FT1, FT2 };

//            separation.DetectCollision(tracks);

//            Assert.IsTrue(separation.IsTimeEqual(tracks));
//        }

//        [Test]
//        public void horizontalcompare()
//        {
//            tracks = new List<FlightTrack>() { FT1, FT2 };

//            separation.DetectCollision(tracks);
//            // horizontial distance = 0

//            Assert.That(separation.CalculateHorizontialDistance(tracks), Is.EqualTo(0));

//        }

//        [Test]
//        public void verticalcompare()
//        {
//            tracks = new List<FlightTrack> { FT1, FT2 };

//            separation.DetectCollision(tracks);

//            Assert.That(separation.CalculateVerticalDistance(tracks), Is.EqualTo(0));

//        }
//    }
//}
///*[TestCase(TestName = "Test its in list ")]
//public void Test5()
//{
//    tracks = new List<FlightTrack> { FT1, FT2, FT5, FT6 };

//    separation.DetectCollision(tracks);

//    Assert.That(separation.ProximityList.Count, Is.EqualTo(2));
//    //Assert.That(flightsFlightInCollisionsDetected.Count, Is.EqualTo(2));
//}

//}*/


using System.Collections.Generic;
using AirTrafficMonitor.Domain;
using AirTrafficMonitor.Infrastructure;
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
        private ILogger _logger;

        [SetUp]
        public void SetUp()
        {
            tracks = new List<FlightTrack>();
            flightsFlightInCollisionsDetected = new List<FlightInCollision>();
            _logger = new Logger();
            record = new FlightRecordFactory();
            separation = new SeparationHandler();


            //Alt er ens untagen tag
            var record1 = record.CreateRecord("AAJ063;39563;95000;16800;20181001160609975");
            var record2 = record.CreateRecord("BBJ063;39563;95000;16800;20181001160609975");
            //Horizontial > 5000 Vertical < 300
            var record3 = record.CreateRecord("CGJ063;39563;95000;16800;20181001160609975");
            var record4 = record.CreateRecord("DGJ063;39563;95000;16800;20181001160609975");
            //alt er ens untagen tags. Dette er til at se om FlightInCollision liste.count = 2
            var record5 = record.CreateRecord("EEJ063;38563;90000;15800;20181001090605975");
            var record6 = record.CreateRecord("FFJ063;38563;90000;11800;20181001090609975");

            FT1 = new FlightTrack(record1.Tag);
            FT2 = new FlightTrack(record2.Tag);
            FT3 = new FlightTrack(record3.Tag);
            FT4 = new FlightTrack(record4.Tag);
            FT5 = new FlightTrack(record5.Tag);
            FT6 = new FlightTrack(record6.Tag);


            FT1.Add(record1);
            FT2.Add(record2);
            FT3.Add(record3);
            FT4.Add(record4);
            FT5.Add(record5);
            FT6.Add(record6);


        }

        [TestCase(TestName = "Test Istime")]
        public void Test2()
        {
            tracks = new List<FlightTrack>() {FT1, FT2};

            separation.DetectCollision(tracks);

            Assert.IsTrue(separation.IstimeEquel(tracks));
        }

        [TestCase(TestName = "Test horizontal compare")]
        public void Test3()
        {
            tracks = new List<FlightTrack>() {FT1, FT2};

            separation.DetectCollision(tracks);
            // horizontial distance = 0

            Assert.That(separation.CalculateHorizontialDistance(tracks), Is.EqualTo(0));

        }

        [TestCase(TestName = "Test vertical compare")]
        public void Test4()
        {
            tracks = new List<FlightTrack> {FT1, FT2};

            separation.DetectCollision(tracks);

            Assert.That(separation.CalculateVerticalDistance(tracks), Is.EqualTo(0));

        }
    }
}
/*[TestCase(TestName = "Test its in list ")]
public void Test5()
{
    tracks = new List<FlightTrack> { FT1, FT2, FT5, FT6 };

    separation.DetectCollision(tracks);

    Assert.That(separation.ProximityList.Count, Is.EqualTo(2));
    //Assert.That(flightsFlightInCollisionsDetected.Count, Is.EqualTo(2));
}

}*/


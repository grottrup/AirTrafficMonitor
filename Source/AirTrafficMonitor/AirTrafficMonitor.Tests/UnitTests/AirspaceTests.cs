using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class AirspaceTests
    {
        [TestCase(TestName = "Check position of new flights")]
        public void test1()
        {
            var factory = new FlightRecordFactory();
            var record1 = factory.CreateRecord("AGJ063;39563;80000;16800;20181001160609975"); //True
            var record2 = factory.CreateRecord("AGJ063;80000;09000;26800;20181001160609975"); //False
            var record3 = factory.CreateRecord("AGJ063;39563;91000;16800;20181001160609975"); //False
            var record4 = factory.CreateRecord("AGJ063;40563;80000;13800;20181001160609975"); //True

            //Create airspace
            var Space = new Airspace();

            Assert.IsTrue(Space.IsWithin(record1.Position, record1.Altitude));
            Assert.IsFalse(Space.IsWithin(record2.Position, record2.Altitude));
            Assert.IsFalse(Space.IsWithin(record3.Position, record3.Altitude));
            Assert.IsTrue(Space.IsWithin(record4.Position, record4.Altitude));
            //test Airspace.IsWithin()
        }
    }
}

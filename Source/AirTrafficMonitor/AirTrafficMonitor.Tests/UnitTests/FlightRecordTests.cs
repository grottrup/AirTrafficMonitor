using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class FlightRecordTests
    {
        [TestCase(TestName = "Each record have the following data")]
        public void Test1() //should we make a track history?
        {
            var factory = new FlightRecordFactory();
            var record = factory.CreateRecord("AGJ063;39563;95000;16800;20181001160609975");

            Assert.AreEqual("AGJ063", record.Tag);
            Assert.AreEqual(39563, record.Position.X);
            Assert.AreEqual(95000, record.Position.Y);
            Assert.AreEqual(16800, record.Altitude);
            Assert.AreEqual(new DateTime(2018, 10, 01, 16, 06, 09, 975), record.Timestamp);
        }
    }
}

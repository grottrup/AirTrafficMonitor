using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Domain;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class Position_Should
    {
        [TestCase("AGJ063;39563;80000;16800;20181001160609975", true)]
        [TestCase("AGJ063;80000;09000;26800;20181001160609975", false)]
        [TestCase("AGJ063;39563;91000;16800;20181001160609975", false)]
        [TestCase("AGJ063;40563;80000;13800;20181001160609975", true)]
        public void BeAbleToCheck_WhetherItIsWitin_Airspace(string rawData, bool expectedResult)
        {
            var factory = new FlightRecordFactory();
            var record1 = factory.CreateRecord(rawData);
            var airspace = new Airspace();

            Assert.That(record1.Position.IsWithin(airspace), Is.EqualTo(expectedResult));
        }
    }
}

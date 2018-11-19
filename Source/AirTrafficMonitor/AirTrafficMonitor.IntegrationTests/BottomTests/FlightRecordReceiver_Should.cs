using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.IntegrationTests
{
    [TestFixture]
    public class FlightRecordReceiver_Should
    {
        private FlightRecordReceiver _sut;

        [SetUp]
        public void SetUp()
        {
            var subSystem1 = new FlightRecordFactory();
            _sut = new FlightRecordReceiver(subSystem1);
        }

        [Test]
        public void test1()
        {

        }
    }
}

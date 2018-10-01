using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class RenderTests
    {
        [TestCase(TestName = "The system shall render all tracks currently in the monitored airspace.")]
        public void Test1()
        {

        }

        [TestCase(TestName = "The system shall not render any tracks that are outside the monitored airspace.")]
        public void Test2()
        {

        }
    }
}

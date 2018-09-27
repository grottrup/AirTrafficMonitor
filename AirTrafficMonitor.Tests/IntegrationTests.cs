using System;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        [TestCase(TestName = "The system shall monitor one (1) airspace.")]
        public void Test1()
        {

        }

        [TestCase(TestName = "The system shall render all tracks currently in the monitored airspace.")]
        public void Test2()
        {

        }

        //TODO what do we want to render it to?
        [TestCase(TestName = "Rendition of the tracks in the airspace shall be [either to a file or to the console]???")]
        public void Test3()
        {

        }

        [TestCase(TestName = "The monitored airspace has a boundary")]
        public void Test4()
        {

        }

        [TestCase(TestName = "The monitored airspace has a boundary")]
        public void Test5()
        {

        }
    }
}
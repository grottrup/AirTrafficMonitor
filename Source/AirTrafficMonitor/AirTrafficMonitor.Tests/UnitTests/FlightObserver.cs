using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.View;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.IntegrationTests
{
    [TestFixture]
    public class FlightObserver
    {
        //[SetUp]
        //public void SetUp()
        //{

        //}

        //stub test

        //mock test
        [Test]
        public void mock()
        {
            //Arrange
            var viewMock = Substitute.For<IView>();
            var seperationMock = Substitute.For<ISeperationHandler>();


        }

    }
}

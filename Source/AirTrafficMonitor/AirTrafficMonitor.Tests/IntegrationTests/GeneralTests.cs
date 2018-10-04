using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.View;
using DependencyInjection;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using AirTrafficMonitor;
using AirTrafficMonitor.Domain;

namespace AirTrafficMonitor.Tests.IntegrationTests
{
    [TestFixture()]
    public class GeneralTests
    {
        private Container _container;

        [SetUp]
        public void SetUp()
        {
            _container = new Container();
            _container.Configure();
        }

        [Test]
        public void Test1()
        {
            var factory = new FlightRecordFactory();
            var fakeView = Substitute.For<IView>();

            var str = string.Empty;

            //stub
            fakeView
                .Render(Arg.Do<FlightRecord>(arg => str = arg.Tag));

            var record1 = factory.CreateRecord("AGJ063;39563;80000;16800;20181001160609975");

            fakeView.Render(record1);
            
            Assert.AreEqual(record1.Tag, str);
        }

        [Test]
        public void Test2()
        {
            var factory = new FlightRecordFactory();
            
        }
    }
}

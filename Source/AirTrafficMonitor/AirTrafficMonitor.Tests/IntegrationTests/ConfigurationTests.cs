using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class ConfigurationTests
    {
        private Container _container;

        [SetUp]
        public void SetUp()
        {
            _container = new Container();
            _container.Configure();
        }

        [Test]
        public void Configurator_Resolving_ReturnsInstances()
        {
            var logger = _container.Resolve<ILogger>();
            var subject = _container.Resolve<IObservable<AirTrafficReport>>();
            var observer = _container.Resolve<IObserver<AirTrafficReport>>();


            Assert.IsNotNull(logger);
            Assert.IsNotNull(subject);
            Assert.IsNotNull(observer);
        }
    }
}

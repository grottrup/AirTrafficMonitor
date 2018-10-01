using AirTrafficMonitor.Observer;
using DependencyInjection;
using NUnit.Framework;

namespace AirTrafficMonitor.Tests.IntegrationTests
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
            var subject = _container.Resolve<ISubject<AirTrafficRecord>>();
            var observer = _container.Resolve<IObserver<AirTrafficRecord>>();

            Assert.IsNotNull(logger);
            Assert.IsNotNull(subject);
            Assert.IsNotNull(observer);
        }
    }
}

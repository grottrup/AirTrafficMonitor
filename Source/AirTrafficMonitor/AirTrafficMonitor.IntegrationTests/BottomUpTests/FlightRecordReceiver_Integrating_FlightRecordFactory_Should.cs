using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AntiCorruptionLayer;
using AirTrafficMonitor.Domain;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace AirTrafficMonitor.IntegrationTests
{
    /// <summary>
    /// Integration step 1
    /// </summary>
    [TestFixture]
    public class FlightRecordReceiver_Integrating_FlightRecordFactory_Should
    {
        private FlightRecordReceiver _sut;
        private FlightRecordFactory _ssut_flightRecordFactory;
        private ITransponderReceiver _fakeTransponder;

        [SetUp]
        public void SetUp()
        {
            _fakeTransponder = Substitute.For<ITransponderReceiver>();
            _ssut_flightRecordFactory = new FlightRecordFactory();
            _sut = new FlightRecordReceiver(_fakeTransponder, _ssut_flightRecordFactory);
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975", "AGJ063", 39563, 95000, 16800)]
        public void WhenRaisingTransponderDataReady_CreateRecordObject_ThatASubscriperCanReceive(string rawData, string expTag, int expLat, int expLong, int expAlt)
        {
            // ARRANGE
            var transponderData = new List<string>();
            transponderData.Add(rawData);

            FlightRecord persistedArgs = null;
            _sut.FlightRecordReceived += (sender, e) =>
            {
                persistedArgs = e.FlightRecord;
            };

            //ACT
            _fakeTransponder.TransponderDataReady += Raise.EventWith(_fakeTransponder, new RawTransponderDataEventArgs(transponderData));

            // ASSERT
            Assert.That(persistedArgs.Tag, Is.Not.Null);
            Assert.That(persistedArgs.Tag, Is.EqualTo(expTag));
            Assert.That(persistedArgs.Position.Altitude, Is.EqualTo(expAlt));
            Assert.That(persistedArgs.Position.Latitude, Is.EqualTo(expLat));
            Assert.That(persistedArgs.Position.Longitude, Is.EqualTo(expLong));
            Assert.That(persistedArgs.Timestamp, Is.Not.EqualTo(DateTime.MinValue));
        }
    }
}
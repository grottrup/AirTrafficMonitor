﻿using System;
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
    public class FlightRecordFactory_Should
    {
        private FlightRecordFactory _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new FlightRecordFactory();
        }

        [Test]
        public void FromAString_CreateRecordsWithSpecificData()
        {
            var record = _uut.CreateRecord("AGJ063;39563;95000;16800;20181001160609975"); //make into test cases

            Assert.That(record.Tag, Is.EqualTo("AGJ063"));
            Assert.That(record.Position.X, Is.EqualTo(39563));
            Assert.That(record.Position.Y, Is.EqualTo(95000));
            Assert.That(record.Position.Altitude, Is.EqualTo(16800));
            Assert.That(record.Timestamp, Is.EqualTo(new DateTime(2018, 10, 01, 16, 06, 09, 975)));
        }

        [TestCase("AGJ063;39563;95000;16800;20181001160609975")]
        public void CreateARecord_WithAValidDateTimeValue(string rawData)
        {
            var record = _uut.CreateRecord(rawData);

            Assert.That(record.Timestamp, Is.Not.EqualTo(DateTime.MinValue)); // MinValue is the default DateTime value and this indicated an error
        }
    }
}

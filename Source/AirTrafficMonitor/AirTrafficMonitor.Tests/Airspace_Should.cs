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

namespace AirTrafficMonitor.Tests
{
    [TestFixture]
    public class Airspace_Should
    {
        [TestCase(39563,80000,16800, true)]
        [TestCase(80000,09000,26800, false)]
        [TestCase(39563,91000,16800, false)]
        [TestCase(40563,80000,13800, true)]
        public void BeAbleToCheck_WhetherPositionIsWithin_Airspace(int lat, int lon, int alt, bool expectedResult)
        {
            var uut = new Airspace();
            var position = new Position()
            {
                Latitude = lat,
                Longitude = lon,
                Altitude = alt
            };

            Assert.That(uut.HasPositionWithinBoundaries(position), Is.EqualTo(expectedResult));
        }
    }
}

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

namespace AirTrafficMonitor.Tests.DomainTests
{
    [TestFixture]
    public class Airspace_Should
    {
        //Random Numbers both inside and outside the airspace
        [TestCase(39563, 80000, 16800, true)]
        [TestCase(80000, 09000, 26800, false)]
        [TestCase(39563, 91000, 16800, false)]
        [TestCase(40563, 80000, 13800, true)]
        //Negative numbers
        [TestCase(-40563, -80000, -13800, false)]
        //Null
        [TestCase(0, 0, 0, false)]
        //Testing the minimum and maximum coordinates at the upper and lower boundary
        [TestCase(10000, 10000, 500, true)]
        [TestCase(90000, 90000, 500, true)]
        [TestCase(90000, 10000, 500, true)]
        [TestCase(10000, 90000, 500, true)]
        [TestCase(10000, 10000, 20000, true)]
        [TestCase(90000, 90000, 20000, true)]
        [TestCase(90000, 10000, 20000, true)]
        [TestCase(10000, 90000, 20000, true)]
        public void BeAbleToCheck_WhetherItIsWithin_Airspace(int lat, int lon, int alt, bool expectedResult)
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
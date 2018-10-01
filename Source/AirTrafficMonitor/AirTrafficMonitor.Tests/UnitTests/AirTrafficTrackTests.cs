using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AirTrafficMonitor.Tests.UnitTests
{
    [TestFixture]
    public class AirTrafficTrackTests
    {
        [TestCase(TestName = "Each track shall be have with the following data")]
        public void Test1()
        {
            var factory = new AirTrafficTrackFactory();
            var track = factory.CreateTrack("AGJ063;39563;95000;16800;20181001160609975");

            //Assert.AreEqual("AGJ063", track.Tag);
            Assert.AreEqual(39563, track.Position.X);
            Assert.AreEqual(95000, track.Position.Y);
            //Assert.AreEqual(16800, track.Altitude);
            //Assert.AreEqual(new DateTime(2018,10,01,16,06,09,975), track.Timestamp);
        }
    }


    //TODO: use in implementation as well
    public interface IAirTrafficTrackFactory
    {
        AirTrafficTrack CreateTrack(string rawTrackData);
    }

    public class AirTrafficTrackFactory : IAirTrafficTrackFactory
    {
        public AirTrafficTrack CreateTrack(string rawTrackData)
        {
            var split = rawTrackData.Split(';');
            var track = new AirTrafficTrack(rawTrackData) //remove raw
            {
                Position = new Position(Int32.Parse(split[1]), Int32.Parse(split[2]))
            }; 
            return track;
        }
    }
}

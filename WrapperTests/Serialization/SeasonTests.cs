using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;
using System.Collections.Generic;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class SeasonTests
    {
        #region Test Data

        public readonly string SeasonSampleJson = @"{
    ""data"": [
        {
            ""type"": ""season"",
            ""id"": ""division.bro.official.2017-beta"",
            ""attributes"": {
                ""isCurrentSeason"": false,
                ""isOffseason"": false
            }
        },
        {
            ""type"": ""season"",
            ""id"": ""division.bro.official.pc-2018-03"",
            ""attributes"": {
                ""isOffseason"": true,
                ""isCurrentSeason"": true
            }
        }
    ],
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/seasons""
    },
    ""meta"": {}
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            List<Season> season = Season.Deserialize(SeasonSampleJson);

            Assert.AreEqual(2, season.Count);

            Assert.AreEqual("division.bro.official.2017-beta", season[0].Id);
            Assert.IsFalse(season[0].IsCurrentSeason);
            Assert.IsFalse(season[0].IsOffSeason);

            Assert.AreEqual("division.bro.official.pc-2018-03", season[1].Id);
            Assert.IsTrue(season[1].IsCurrentSeason);
            Assert.IsTrue(season[1].IsOffSeason);

        }
    }
}

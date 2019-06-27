using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;
using System.Collections.Generic;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class TournamentTests
    {
        #region Test Data
        
        public static string SampleJson = @"{
    ""data"": [
        {
            ""type"": ""tournament"",
            ""id"": ""sea-pvs19"",
            ""attributes"": {
                ""createdAt"": ""2019-06-07T11:42:55Z""
            }
        },
        {
            ""type"": ""tournament"",
            ""id"": ""na-nplf"",
            ""attributes"": {
                ""createdAt"": ""2019-05-26T21:48:22Z""
            }
        }
    ],
    ""links"": {
        ""self"": ""https://api.pubg.com/tournaments""
    },
    ""meta"": {}
}";

        public static string MatchesSampleJson = @"{
    ""data"": {
        ""type"": ""tournament"",
        ""id"": ""na-nplf"",
        ""relationships"": {
            ""matches"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""4a55a58b-e3f0-4c76-b662-809ed57b0389""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""36134043-bd34-45d4-94dc-8eccf076e22c""
                    }
                ]
            }
        }
    },
    ""included"": [
        {
            ""type"": ""match"",
            ""id"": ""8d1cf495-6e2e-4e9e-a057-0b3d40d557f0"",
            ""attributes"": {
                ""createdAt"": ""2019-05-26T21:58:39Z""
            }
        },
        {
            ""type"": ""match"",
            ""id"": ""2c7d0708-0ded-4eae-8c4c-13fd49fbdd41"",
            ""attributes"": {
                ""createdAt"": ""2019-05-26T21:15:54Z""
            }
        }
    ],
    ""links"": {
        ""self"": ""https://api.pubg.com/tournaments/na-nplf""
    },
    ""meta"": {}
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesTournamentListsCorrectly()
        {
            List<Tournament> tournaments = Tournament.Deserialize(SampleJson);

            Assert.AreEqual(2, tournaments.Count);

            Assert.AreEqual("sea-pvs19", tournaments[0].Id);
            Assert.AreEqual("6/7/2019 11:42:55 AM", tournaments[0].Created.ToString());

            Assert.AreEqual("na-nplf", tournaments[1].Id);
            Assert.AreEqual("5/26/2019 9:48:22 PM", tournaments[1].Created.ToString());
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesTournamentMatchesCorrectly()
        {
            TournamentMatches tournamentMatches = TournamentMatches.Deserialize(MatchesSampleJson);

            Assert.AreEqual("na-nplf", tournamentMatches.Id);

            Assert.AreEqual(2, tournamentMatches.Matches.Count);

            Assert.AreEqual("8d1cf495-6e2e-4e9e-a057-0b3d40d557f0", tournamentMatches.Matches[0].Id);
            Assert.AreEqual("5/26/2019 9:58:39 PM", tournamentMatches.Matches[0].Created.ToString());

            Assert.AreEqual("2c7d0708-0ded-4eae-8c4c-13fd49fbdd41", tournamentMatches.Matches[1].Id);
            Assert.AreEqual("5/26/2019 9:15:54 PM", tournamentMatches.Matches[1].Created.ToString());
        }
    }
}

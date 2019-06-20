using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;
using System.Collections.Generic;
using System.Linq;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class PlayerTests
    {
        #region Test Data
        
        public string SamplePlayerJson = @"{
    ""data"": {
        ""type"": ""player"",
        ""id"": ""account.123-abc"",
        ""attributes"": {
            ""name"": ""PlayerName"",
            ""stats"": null,
            ""titleId"": ""bluehole-pubg"",
            ""shardId"": ""steam"",
            ""patchVersion"": """"
        },
        ""relationships"": {
            ""assets"": {
                ""data"": []
            },
            ""matches"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""456-def""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""789-ghi""
                    }
                ]
            }
        },
        ""links"": {
            ""self"": ""https://api.playbattlegrounds.com/shards/steam/players/account.123-abc"",
            ""schema"": """"
        }
    },
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/players/account.123-abc""
    },
    ""meta"": {}
}";

        public string SamplePlayerListJson = @"{
    ""data"": [
        {
            ""type"": ""player"",
            ""id"": ""account.123-abc"",
            ""attributes"": {
                ""patchVersion"": """",
                ""name"": ""PlayerName"",
                ""stats"": null,
                ""titleId"": ""bluehole-pubg"",
                ""shardId"": ""steam""
            },
            ""relationships"": {
                ""assets"": {
                    ""data"": []
                },
                ""matches"": {
                    ""data"": [
                        {
                            ""type"": ""match"",
                            ""id"": ""456-def""
                        },
                        {
                            ""type"": ""match"",
                            ""id"": ""789-ghi""
                        }
                    ]
                }
            },
            ""links"": {
                ""schema"": """",
                ""self"": ""https://api.playbattlegrounds.com/shards/steam/players/account.123-abc""
            }
        },
        {
            ""type"": ""player"",
            ""id"": ""account.abc-123"",
            ""attributes"": {
                ""shardId"": ""steam"",
                ""patchVersion"": """",
                ""name"": ""PlayerName-2"",
                ""stats"": null,
                ""titleId"": ""bluehole-pubg""
            },
            ""relationships"": {
                ""assets"": {
                    ""data"": []
                },
                ""matches"": {
                    ""data"": [
                        {
                            ""type"": ""match"",
                            ""id"": ""def-456""
                        },
                        {
                            ""type"": ""match"",
                            ""id"": ""ghi-789""
                        }
                    ]
                }
            },
            ""links"": {
                ""self"": ""https://api.playbattlegrounds.com/shards/steam/players/account.abc-123"",
                ""schema"": """"
            }
        }
    ],
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/players?filter[playerNames]=PlayerName,PlayerName-2""
    },
    ""meta"": {}
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerCorrectly()
        {
            Player result = Player.Deserialize(SamplePlayerJson);

            Assert.AreEqual("account.123-abc", result.Id);
            Assert.AreEqual("steam", result.Shard);
            Assert.AreEqual("bluehole-pubg", result.Title);
            Assert.AreEqual("", result.Version);

            Assert.AreEqual(2, result.MatchIds.Count);
            Assert.IsTrue(result.MatchIds.Contains("456-def"));
            Assert.IsTrue(result.MatchIds.Contains("789-ghi"));
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerListsCorrectly()
        {
            List<Player> results = Player.DeserializePlayerList(SamplePlayerListJson);

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Any(x => x.Id == "account.123-abc"));
            Assert.IsTrue(results.Any(x => x.Id == "account.abc-123"));
        }
    }
}

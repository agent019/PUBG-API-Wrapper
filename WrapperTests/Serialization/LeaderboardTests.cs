using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class LeaderboardTests
    {
        #region Test Data

        public static string SampleJson = @"{
    ""data"": {
        ""type"": ""leaderboard"",
        ""id"": ""0e504272-95b7-4a6e-82c9-d051f19491b8"",
        ""attributes"": {
            ""shardId"": ""steam"",
            ""gameMode"": ""solo""
        },
        ""relationships"": {
            ""players"": {
                ""data"": [
                    {
                        ""type"": ""player"",
                        ""id"": ""account.123abc""
                    },
                    {
                        ""type"": ""player"",
                        ""id"": ""account.456def""
                    }
                ]
            }
        }
    },
    ""included"": [
        {
            ""type"": ""player"",
            ""id"": ""account.456def"",
            ""attributes"": {
                ""stats"": {
                    ""rankPoints"": 6051,
                    ""wins"": 15,
                    ""games"": 954,
                    ""winRatio"": 0.0157232713,
                    ""averageDamage"": 147,
                    ""kills"": 1623,
                    ""killDeathRatio"": 1.30419827,
                    ""averageRank"": 30.127882
                },
                ""name"": ""Player2"",
                ""rank"": 2
            }
        },
        {
            ""type"": ""player"",
            ""id"": ""account.123abc"",
            ""attributes"": {
                ""stats"": {
                    ""rankPoints"": 6238,
                    ""wins"": 52,
                    ""games"": 1504,
                    ""winRatio"": 0.0345744677,
                    ""averageDamage"": 196,
                    ""kills"": 1895,
                    ""killDeathRatio"": 1.72843456,
                    ""averageRank"": 38.2879
                },
                ""name"": ""Player1"",
                ""rank"": 1
            }
        }
    ],
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/leaderboards/solo?page[number]=0""
    },
    ""meta"": {}
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            Leaderboard leaderboard = Leaderboard.Deserialize(SampleJson);

            Assert.AreEqual("steam", leaderboard.Shard);
            Assert.AreEqual("solo", leaderboard.GameMode);

            Assert.AreEqual(2, leaderboard.PlayerStats.Count);

            // Results are ordered by rank
            Assert.AreEqual("Player1", leaderboard.PlayerStats[0].Name);
            Assert.AreEqual("account.123abc", leaderboard.PlayerStats[0].Id);
            Assert.AreEqual(1, leaderboard.PlayerStats[0].Rank);
            Assert.AreEqual(6238, leaderboard.PlayerStats[0].RankPoints);
            Assert.AreEqual(52, leaderboard.PlayerStats[0].Wins);
            Assert.AreEqual(1504, leaderboard.PlayerStats[0].Games);
            Assert.AreEqual(0.0345744677, leaderboard.PlayerStats[0].WinRatio);
            Assert.AreEqual(196, leaderboard.PlayerStats[0].AverageDamage);
            Assert.AreEqual(1895, leaderboard.PlayerStats[0].Kills);
            Assert.AreEqual(1.72843456, leaderboard.PlayerStats[0].KillDeathRatio);
            Assert.AreEqual(38.2879, leaderboard.PlayerStats[0].AverageRank);

            Assert.AreEqual("Player2", leaderboard.PlayerStats[1].Name);
            Assert.AreEqual("account.456def", leaderboard.PlayerStats[1].Id);
            Assert.AreEqual(2, leaderboard.PlayerStats[1].Rank);
            Assert.AreEqual(6051, leaderboard.PlayerStats[1].RankPoints);
            Assert.AreEqual(15, leaderboard.PlayerStats[1].Wins);
            Assert.AreEqual(954, leaderboard.PlayerStats[1].Games);
            Assert.AreEqual(0.0157232713, leaderboard.PlayerStats[1].WinRatio);
            Assert.AreEqual(147, leaderboard.PlayerStats[1].AverageDamage);
            Assert.AreEqual(1623, leaderboard.PlayerStats[1].Kills);
            Assert.AreEqual(1.30419827, leaderboard.PlayerStats[1].KillDeathRatio);
            Assert.AreEqual(30.127882, leaderboard.PlayerStats[1].AverageRank);
        }
    }
}

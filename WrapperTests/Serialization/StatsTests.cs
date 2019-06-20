using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class StatsTests
    {
        #region Test Data

        public readonly string SeasonStatsSampleJson = @"{
    ""data"": {
        ""type"": ""playerSeason"",
        ""attributes"": {
            ""gameModeStats"": {
                ""duo"": {
                    ""assists"": 0,
                    ""bestRankPoint"": 0,
                    ""boosts"": 0,
                    ""dBNOs"": 0,
                    ""dailyKills"": 0,
                    ""dailyWins"": 0,
                    ""damageDealt"": 0,
                    ""days"": 0,
                    ""headshotKills"": 0,
                    ""heals"": 0,
                    ""killPoints"": 0,
                    ""kills"": 0,
                    ""longestKill"": 0,
                    ""longestTimeSurvived"": 0,
                    ""losses"": 0,
                    ""maxKillStreaks"": 0,
                    ""mostSurvivalTime"": 0,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 0,
                    ""rideDistance"": 0,
                    ""roadKills"": 0,
                    ""roundMostKills"": 0,
                    ""roundsPlayed"": 0,
                    ""suicides"": 0,
                    ""swimDistance"": 0,
                    ""teamKills"": 0,
                    ""timeSurvived"": 0,
                    ""top10s"": 0,
                    ""vehicleDestroys"": 0,
                    ""walkDistance"": 0,
                    ""weaponsAcquired"": 0,
                    ""weeklyKills"": 0,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 0
                },
                ""duo-fpp"": {
                    ""assists"": 14,
                    ""bestRankPoint"": 5938.2236,
                    ""boosts"": 43,
                    ""dBNOs"": 31,
                    ""dailyKills"": 0,
                    ""dailyWins"": 0,
                    ""damageDealt"": 7172.7104,
                    ""days"": 4,
                    ""headshotKills"": 13,
                    ""heals"": 41,
                    ""killPoints"": 0,
                    ""kills"": 52,
                    ""longestKill"": 181.2526,
                    ""longestTimeSurvived"": 1845.436,
                    ""losses"": 29,
                    ""maxKillStreaks"": 4,
                    ""mostSurvivalTime"": 1845.436,
                    ""rankPoints"": 1636.6414,
                    ""rankPointsTitle"": ""2-2"",
                    ""revives"": 8,
                    ""rideDistance"": 18362.006,
                    ""roadKills"": 0,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 30,
                    ""suicides"": 1,
                    ""swimDistance"": 33.158485,
                    ""teamKills"": 1,
                    ""timeSurvived"": 17911.068,
                    ""top10s"": 5,
                    ""vehicleDestroys"": 0,
                    ""walkDistance"": 28520.5,
                    ""weaponsAcquired"": 118,
                    ""weeklyKills"": 0,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 1
                },
                ""solo"": {
                    ""assists"": 6,
                    ""bestRankPoint"": 6080.0293,
                    ""boosts"": 159,
                    ""dBNOs"": 0,
                    ""dailyKills"": 5,
                    ""dailyWins"": 0,
                    ""damageDealt"": 29210.25,
                    ""days"": 32,
                    ""headshotKills"": 54,
                    ""heals"": 135,
                    ""killPoints"": 0,
                    ""kills"": 259,
                    ""longestKill"": 378.1534,
                    ""longestTimeSurvived"": 1903.294,
                    ""losses"": 79,
                    ""maxKillStreaks"": 2,
                    ""mostSurvivalTime"": 1903.294,
                    ""rankPoints"": 2536.376,
                    ""rankPointsTitle"": ""3-3"",
                    ""revives"": 0,
                    ""rideDistance"": 229423.25,
                    ""roadKills"": 11,
                    ""roundMostKills"": 16,
                    ""roundsPlayed"": 84,
                    ""suicides"": 2,
                    ""swimDistance"": 0,
                    ""teamKills"": 2,
                    ""timeSurvived"": 62538.79,
                    ""top10s"": 9,
                    ""vehicleDestroys"": 7,
                    ""walkDistance"": 88102.68,
                    ""weaponsAcquired"": 375,
                    ""weeklyKills"": 5,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 5
                },
                ""solo-fpp"": {
                    ""assists"": 168,
                    ""bestRankPoint"": 6136.96,
                    ""boosts"": 2702,
                    ""dBNOs"": 0,
                    ""dailyKills"": 47,
                    ""dailyWins"": 2,
                    ""damageDealt"": 399131.38,
                    ""days"": 63,
                    ""headshotKills"": 1006,
                    ""heals"": 1755,
                    ""killPoints"": 0,
                    ""kills"": 3495,
                    ""longestKill"": 470.58044,
                    ""longestTimeSurvived"": 2008.959,
                    ""losses"": 968,
                    ""maxKillStreaks"": 13,
                    ""mostSurvivalTime"": 2008.959,
                    ""rankPoints"": 6136.96,
                    ""rankPointsTitle"": ""7-0"",
                    ""revives"": 0,
                    ""rideDistance"": 1143347.8,
                    ""roadKills"": 25,
                    ""roundMostKills"": 17,
                    ""roundsPlayed"": 1095,
                    ""suicides"": 17,
                    ""swimDistance"": 6125.8164,
                    ""teamKills"": 17,
                    ""timeSurvived"": 827820.8,
                    ""top10s"": 288,
                    ""vehicleDestroys"": 28,
                    ""walkDistance"": 1517026.2,
                    ""weaponsAcquired"": 4256,
                    ""weeklyKills"": 131,
                    ""weeklyWins"": 5,
                    ""winPoints"": 0,
                    ""wins"": 127
                },
                ""squad"": {
                    ""assists"": 0,
                    ""bestRankPoint"": 5661.111,
                    ""boosts"": 2,
                    ""dBNOs"": 7,
                    ""dailyKills"": 0,
                    ""dailyWins"": 0,
                    ""damageDealt"": 960.0909,
                    ""days"": 6,
                    ""headshotKills"": 1,
                    ""heals"": 3,
                    ""killPoints"": 0,
                    ""kills"": 7,
                    ""longestKill"": 27.203735,
                    ""longestTimeSurvived"": 857.556,
                    ""losses"": 7,
                    ""maxKillStreaks"": 3,
                    ""mostSurvivalTime"": 857.556,
                    ""rankPoints"": 1021.8562,
                    ""rankPointsTitle"": ""2-5"",
                    ""revives"": 0,
                    ""rideDistance"": 3379.6392,
                    ""roadKills"": 0,
                    ""roundMostKills"": 5,
                    ""roundsPlayed"": 7,
                    ""suicides"": 2,
                    ""swimDistance"": 11.177678,
                    ""teamKills"": 2,
                    ""timeSurvived"": 2257.8892,
                    ""top10s"": 0,
                    ""vehicleDestroys"": 0,
                    ""walkDistance"": 2840.188,
                    ""weaponsAcquired"": 18,
                    ""weeklyKills"": 0,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 0
                },
                ""squad-fpp"": {
                    ""assists"": 13,
                    ""bestRankPoint"": 6102.871,
                    ""boosts"": 133,
                    ""dBNOs"": 226,
                    ""dailyKills"": 10,
                    ""dailyWins"": 0,
                    ""damageDealt"": 30653.082,
                    ""days"": 21,
                    ""headshotKills"": 49,
                    ""heals"": 148,
                    ""killPoints"": 0,
                    ""kills"": 225,
                    ""longestKill"": 218.47418,
                    ""longestTimeSurvived"": 1953.946,
                    ""losses"": 77,
                    ""maxKillStreaks"": 3,
                    ""mostSurvivalTime"": 1953.946,
                    ""rankPoints"": 1757.2577,
                    ""rankPointsTitle"": ""2-2"",
                    ""revives"": 1,
                    ""rideDistance"": 37989.67,
                    ""roadKills"": 1,
                    ""roundMostKills"": 11,
                    ""roundsPlayed"": 78,
                    ""suicides"": 0,
                    ""swimDistance"": 169.76602,
                    ""teamKills"": 0,
                    ""timeSurvived"": 44453.367,
                    ""top10s"": 16,
                    ""vehicleDestroys"": 1,
                    ""walkDistance"": 79026.46,
                    ""weaponsAcquired"": 268,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 1
                }
            }
        },
        ""relationships"": {
            ""matchesSquadFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""4b8ba16a-533a-4450-8b60-badc64dcf281""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""0adca14c-7b81-4b39-9d1d-0c805fe95eee""
                    }
                ]
            },
            ""season"": {
                ""data"": {
                    ""type"": ""season"",
                    ""id"": ""division.bro.official.pc-2018-03""
                }
            },
            ""player"": {
                ""data"": {
                    ""type"": ""player"",
                    ""id"": ""account.c0e530e9b7244b358def282782f893af""
                }
            },
            ""matchesSolo"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""7c6fea92-b3a0-429d-8ad9-d261518e22bc""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""fc9e4281-b255-412e-9920-2d5777636170""
                    }
                ]
            },
            ""matchesSoloFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""f2f34433-b136-4d8b-ab00-d3f5c3c45151""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""77c88fc1-5da3-4665-ad28-3c7559e6538b""
                    }
                ]
            },
            ""matchesDuo"": {
                ""data"": []
            },
            ""matchesDuoFPP"": {
                ""data"": []
            },
            ""matchesSquad"": {
                ""data"": []
            }
        }
    },
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/players/account.c0e530e9b7244b358def282782f893af/seasons/division.bro.official.pc-2018-03""
    },
    ""meta"": {}
}";

        public readonly string LifetimeStatsSampleJson = @"{
    ""data"": {
        ""type"": ""playerSeason"",
        ""attributes"": {
            ""gameModeStats"": {
                ""duo"": {
                    ""assists"": 0,
                    ""bestRankPoint"": 1007.8809,
                    ""boosts"": 0,
                    ""dBNOs"": 2,
                    ""dailyKills"": 0,
                    ""dailyWins"": 0,
                    ""damageDealt"": 99.84,
                    ""days"": 3,
                    ""headshotKills"": 0,
                    ""heals"": 0,
                    ""killPoints"": 0,
                    ""kills"": 0,
                    ""longestKill"": 0,
                    ""longestTimeSurvived"": 754.901,
                    ""losses"": 3,
                    ""maxKillStreaks"": 0,
                    ""mostSurvivalTime"": 754.901,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 0,
                    ""rideDistance"": 0,
                    ""roadKills"": 0,
                    ""roundMostKills"": 0,
                    ""roundsPlayed"": 3,
                    ""suicides"": 1,
                    ""swimDistance"": 0,
                    ""teamKills"": 3,
                    ""timeSurvived"": 1442.609,
                    ""top10s"": 0,
                    ""vehicleDestroys"": 0,
                    ""walkDistance"": 934.9639,
                    ""weaponsAcquired"": 2,
                    ""weeklyKills"": 0,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 0
                },
                ""duo-fpp"": {
                    ""assists"": 24,
                    ""bestRankPoint"": 1225.6593,
                    ""boosts"": 88,
                    ""dBNOs"": 68,
                    ""dailyKills"": 0,
                    ""dailyWins"": 0,
                    ""damageDealt"": 15851.533,
                    ""days"": 13,
                    ""headshotKills"": 31,
                    ""heals"": 72,
                    ""killPoints"": 0,
                    ""kills"": 121,
                    ""longestKill"": 415.238,
                    ""longestTimeSurvived"": 1845.436,
                    ""losses"": 53,
                    ""maxKillStreaks"": 4,
                    ""mostSurvivalTime"": 1845.436,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 13,
                    ""rideDistance"": 24249.71,
                    ""roadKills"": 0,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 55,
                    ""suicides"": 1,
                    ""swimDistance"": 56.660755,
                    ""teamKills"": 1,
                    ""timeSurvived"": 36485.418,
                    ""top10s"": 12,
                    ""vehicleDestroys"": 1,
                    ""walkDistance"": 62092.8,
                    ""weaponsAcquired"": 216,
                    ""weeklyKills"": 0,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 2
                },
                ""solo"": {
                    ""assists"": 27,
                    ""bestRankPoint"": 1800.2811,
                    ""boosts"": 340,
                    ""dBNOs"": 0,
                    ""dailyKills"": 5,
                    ""dailyWins"": 0,
                    ""damageDealt"": 63769.53,
                    ""days"": 44,
                    ""headshotKills"": 123,
                    ""heals"": 256,
                    ""killPoints"": 0,
                    ""kills"": 570,
                    ""longestKill"": 408.95074,
                    ""longestTimeSurvived"": 2145.787,
                    ""losses"": 138,
                    ""maxKillStreaks"": 3,
                    ""mostSurvivalTime"": 2145.787,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 0,
                    ""rideDistance"": 395045.62,
                    ""roadKills"": 20,
                    ""roundMostKills"": 22,
                    ""roundsPlayed"": 155,
                    ""suicides"": 3,
                    ""swimDistance"": 0,
                    ""teamKills"": 3,
                    ""timeSurvived"": 133482.19,
                    ""top10s"": 29,
                    ""vehicleDestroys"": 13,
                    ""walkDistance"": 197576.75,
                    ""weaponsAcquired"": 718,
                    ""weeklyKills"": 5,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 17
                },
                ""solo-fpp"": {
                    ""assists"": 395,
                    ""bestRankPoint"": 5532.407,
                    ""boosts"": 6077,
                    ""dBNOs"": 0,
                    ""dailyKills"": 47,
                    ""dailyWins"": 2,
                    ""damageDealt"": 888205.06,
                    ""days"": 189,
                    ""headshotKills"": 2177,
                    ""heals"": 3755,
                    ""killPoints"": 0,
                    ""kills"": 7628,
                    ""longestKill"": 525.50714,
                    ""longestTimeSurvived"": 2008.959,
                    ""losses"": 2325,
                    ""maxKillStreaks"": 13,
                    ""mostSurvivalTime"": 2008.959,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 0,
                    ""rideDistance"": 2159229.8,
                    ""roadKills"": 36,
                    ""roundMostKills"": 17,
                    ""roundsPlayed"": 2589,
                    ""suicides"": 32,
                    ""swimDistance"": 12032.03,
                    ""teamKills"": 32,
                    ""timeSurvived"": 1950499.6,
                    ""top10s"": 692,
                    ""vehicleDestroys"": 45,
                    ""walkDistance"": 3463579.5,
                    ""weaponsAcquired"": 9628,
                    ""weeklyKills"": 131,
                    ""weeklyWins"": 5,
                    ""winPoints"": 0,
                    ""wins"": 265
                },
                ""squad"": {
                    ""assists"": 1,
                    ""bestRankPoint"": 983.21893,
                    ""boosts"": 4,
                    ""dBNOs"": 10,
                    ""dailyKills"": 0,
                    ""dailyWins"": 0,
                    ""damageDealt"": 1500.985,
                    ""days"": 12,
                    ""headshotKills"": 1,
                    ""heals"": 3,
                    ""killPoints"": 0,
                    ""kills"": 10,
                    ""longestKill"": 70.910675,
                    ""longestTimeSurvived"": 883.839,
                    ""losses"": 21,
                    ""maxKillStreaks"": 3,
                    ""mostSurvivalTime"": 883.839,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 0,
                    ""rideDistance"": 12622.473,
                    ""roadKills"": 0,
                    ""roundMostKills"": 5,
                    ""roundsPlayed"": 21,
                    ""suicides"": 3,
                    ""swimDistance"": 22.140682,
                    ""teamKills"": 3,
                    ""timeSurvived"": 9071.485,
                    ""top10s"": 0,
                    ""vehicleDestroys"": 0,
                    ""walkDistance"": 5845.925,
                    ""weaponsAcquired"": 31,
                    ""weeklyKills"": 0,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 0
                },
                ""squad-fpp"": {
                    ""assists"": 26,
                    ""bestRankPoint"": 1074.947,
                    ""boosts"": 324,
                    ""dBNOs"": 481,
                    ""dailyKills"": 10,
                    ""dailyWins"": 0,
                    ""damageDealt"": 72728.7,
                    ""days"": 45,
                    ""headshotKills"": 117,
                    ""heals"": 291,
                    ""killPoints"": 0,
                    ""kills"": 498,
                    ""longestKill"": 369.6648,
                    ""longestTimeSurvived"": 1989.017,
                    ""losses"": 197,
                    ""maxKillStreaks"": 4,
                    ""mostSurvivalTime"": 1989.017,
                    ""rankPoints"": 0,
                    ""rankPointsTitle"": """",
                    ""revives"": 2,
                    ""rideDistance"": 113054.34,
                    ""roadKills"": 1,
                    ""roundMostKills"": 14,
                    ""roundsPlayed"": 200,
                    ""suicides"": 0,
                    ""swimDistance"": 316.81268,
                    ""teamKills"": 0,
                    ""timeSurvived"": 121290.32,
                    ""top10s"": 40,
                    ""vehicleDestroys"": 3,
                    ""walkDistance"": 210933.39,
                    ""weaponsAcquired"": 718,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 0,
                    ""winPoints"": 0,
                    ""wins"": 3
                }
            }
        },
        ""relationships"": {
            ""matchesSolo"": {
                ""data"": []
            },
            ""matchesSoloFPP"": {
                ""data"": []
            },
            ""matchesDuo"": {
                ""data"": []
            },
            ""matchesDuoFPP"": {
                ""data"": []
            },
            ""matchesSquad"": {
                ""data"": []
            },
            ""matchesSquadFPP"": {
                ""data"": []
            },
            ""season"": {
                ""data"": {
                    ""type"": ""season"",
                    ""id"": ""lifetime""
                }
            },
            ""player"": {
                ""data"": {
                    ""type"": ""player"",
                    ""id"": ""account.c0e530e9b7244b358def282782f893af""
                }
            }
        }
    },
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/players/account.c0e530e9b7244b358def282782f893af/seasons/lifetime""
    },
    ""meta"": {}
}";

        #endregion


        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesSeasonStatsCorrectly()
        {
            Stats seasonStats = Stats.Deserialize(SeasonStatsSampleJson);
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesLifetimeStatsCorrectly()
        {
            Stats lifetimeStats = Stats.Deserialize(LifetimeStatsSampleJson);
        }
    }
}

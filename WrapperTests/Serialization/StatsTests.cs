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
                ""solo"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""solo-fpp"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""duo"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""duo-fpp"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""squad"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""squad-fpp"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                }
            }
        },
        ""relationships"": {
            ""matchesSolo"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-solo-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-solo-2""
                    }
                ]
            },
            ""matchesSoloFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-soloFPP-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-soloFPP-2""
                    }
                ]
            },
            ""matchesDuo"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duo-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duo-2""
                    }
                ]
            },
            ""matchesDuoFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duoFPP-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duoFPP-2""
                    }
                ]
            },
            ""matchesSquad"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squad-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squad-2""
                    }
                ]
            },
            ""matchesSquadFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squadFPP-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squadFPP-2""
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
                    ""id"": ""account.id""
                }
            }
        }
    },
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/players/account.id/seasons/division.bro.official.pc-2018-03""
    },
    ""meta"": {}
}";

        public readonly string LifetimeStatsSampleJson = @"{
    ""data"": {
        ""type"": ""playerSeason"",
        ""attributes"": {
            ""gameModeStats"": {
                ""solo"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""solo-fpp"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""duo"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""duo-fpp"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""squad"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                },
                ""squad-fpp"": {
                    ""assists"": 10,
                    ""bestRankPoint"": 100.1234,
                    ""boosts"": 10,
                    ""dBNOs"": 10,
                    ""dailyKills"": 10,
                    ""dailyWins"": 10,
                    ""damageDealt"": 100.1234,
                    ""days"": 10,
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPoints"": 10,
                    ""kills"": 10,
                    ""longestKill"": 100.1234,
                    ""longestTimeSurvived"": 100.1234,
                    ""losses"": 10,
                    ""maxKillStreaks"": 10,
                    ""mostSurvivalTime"": 100.1234,
                    ""rankPoints"": 10,
                    ""rankPointsTitle"": ""10-10"",
                    ""revives"": 10,
                    ""rideDistance"": 100.1234,
                    ""roadKills"": 10,
                    ""roundMostKills"": 10,
                    ""roundsPlayed"": 10,
                    ""suicides"": 10,
                    ""swimDistance"": 100.1234,
                    ""teamKills"": 10,
                    ""timeSurvived"": 100.1234,
                    ""top10s"": 10,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 100.1234,
                    ""weaponsAcquired"": 10,
                    ""weeklyKills"": 10,
                    ""weeklyWins"": 10,
                    ""winPoints"": 10,
                    ""wins"": 10
                }
            }
        },
        ""relationships"": {
            ""matchesSolo"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-solo-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-solo-2""
                    }
                ]
            },
            ""matchesSoloFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-soloFPP-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-soloFPP-2""
                    }
                ]
            },
            ""matchesDuo"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duo-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duo-2""
                    }
                ]
            },
            ""matchesDuoFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duoFPP-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-duoFPP-2""
                    }
                ]
            },
            ""matchesSquad"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squad-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squad-2""
                    }
                ]
            },
            ""matchesSquadFPP"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squadFPP-1""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""matchid-squadFPP-2""
                    }
                ]
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
                    ""id"": ""account.id""
                }
            }
        }
    },
    ""links"": {
        ""self"": ""https://api.pubg.com/shards/steam/players/account.id/seasons/lifetime""
    },
    ""meta"": {}
}";

        #endregion
        
        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesSeasonStatsCorrectly()
        {
            Stats seasonStats = Stats.Deserialize(SeasonStatsSampleJson);

            #region Assertions

            Assert.AreEqual("account.id", seasonStats.AccountId);
            Assert.AreEqual("division.bro.official.pc-2018-03", seasonStats.SeasonId);
            
            Assert.AreEqual("matchid-solo-1", seasonStats.SoloTPPMatchIds[0]);
            Assert.AreEqual("matchid-solo-2", seasonStats.SoloTPPMatchIds[1]);

            Assert.AreEqual("matchid-soloFPP-2", seasonStats.SoloFPPMatchIds[0]);
            Assert.AreEqual("matchid-soloFPP-2", seasonStats.SoloFPPMatchIds[1]);

            Assert.AreEqual("matchid-duo-2", seasonStats.DuoTPPMatchIds[0]);
            Assert.AreEqual("matchid-duo-2", seasonStats.DuoTPPMatchIds[1]);

            Assert.AreEqual("matchid-duoFPP-2", seasonStats.DuoFPPMatchIds[0]);
            Assert.AreEqual("matchid-duoFPP-2", seasonStats.DuoFPPMatchIds[1]);

            Assert.AreEqual("matchid-squad-2", seasonStats.SquadTPPMatchIds[0]);
            Assert.AreEqual("matchid-squad-2", seasonStats.SquadTPPMatchIds[1]);

            Assert.AreEqual("matchid-squadFPP-2", seasonStats.SquadFPPMatchIds[0]);
            Assert.AreEqual("matchid-squadFPP-2", seasonStats.SquadFPPMatchIds[1]);

            Assert.AreEqual(10, seasonStats.SoloTPP.Assists);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.BestRankPoint);
            Assert.AreEqual(10, seasonStats.SoloTPP.Boosts);
            Assert.AreEqual(10, seasonStats.SoloTPP.DailyKills);
            Assert.AreEqual(10, seasonStats.SoloTPP.DailyWins);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.DamageDealt);
            Assert.AreEqual(10, seasonStats.SoloTPP.Days);
            Assert.AreEqual(10, seasonStats.SoloTPP.DBNOs);
            Assert.AreEqual(10, seasonStats.SoloTPP.HeadshotKills);
            Assert.AreEqual(10, seasonStats.SoloTPP.Heals);
            Assert.AreEqual(10, seasonStats.SoloTPP.Kills);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.LongestKill);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.LongestTimeSurvived);
            Assert.AreEqual(10, seasonStats.SoloTPP.Losses);
            Assert.AreEqual(10, seasonStats.SoloTPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.MostSurvivalTime);
            Assert.AreEqual(10, seasonStats.SoloTPP.RankPoints);
            Assert.AreEqual("10-10", seasonStats.SoloTPP.RankPointsTitle);
            Assert.AreEqual(10, seasonStats.SoloTPP.Revives);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.RideDistance);
            Assert.AreEqual(10, seasonStats.SoloTPP.RoadKills);
            Assert.AreEqual(10, seasonStats.SoloTPP.RoundMostKills);
            Assert.AreEqual(10, seasonStats.SoloTPP.RoundsPlayed);
            Assert.AreEqual(10, seasonStats.SoloTPP.Suicides);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.SwimDistance);
            Assert.AreEqual(10, seasonStats.SoloTPP.TeamKills);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.TimeSurvived);
            Assert.AreEqual(10, seasonStats.SoloTPP.Top10s);
            Assert.AreEqual(10, seasonStats.SoloTPP.VehicleDestroys);
            Assert.AreEqual(100.1234, seasonStats.SoloTPP.WalkDistance);
            Assert.AreEqual(10, seasonStats.SoloTPP.WeaponsAcquired);
            Assert.AreEqual(10, seasonStats.SoloTPP.WeeklyKills);
            Assert.AreEqual(10, seasonStats.SoloTPP.WeeklyWins);
            Assert.AreEqual(10, seasonStats.SoloTPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, seasonStats.SoloTPP.KillPoints);
            // Assert.AreEqual(10, seasonStats.SoloTPP.WinPoints);

            Assert.AreEqual(10, seasonStats.SoloFPP.Assists);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.BestRankPoint);
            Assert.AreEqual(10, seasonStats.SoloFPP.Boosts);
            Assert.AreEqual(10, seasonStats.SoloFPP.DailyKills);
            Assert.AreEqual(10, seasonStats.SoloFPP.DailyWins);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.DamageDealt);
            Assert.AreEqual(10, seasonStats.SoloFPP.Days);
            Assert.AreEqual(10, seasonStats.SoloFPP.DBNOs);
            Assert.AreEqual(10, seasonStats.SoloFPP.HeadshotKills);
            Assert.AreEqual(10, seasonStats.SoloFPP.Heals);
            Assert.AreEqual(10, seasonStats.SoloFPP.Kills);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.LongestKill);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.LongestTimeSurvived);
            Assert.AreEqual(10, seasonStats.SoloFPP.Losses);
            Assert.AreEqual(10, seasonStats.SoloFPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.MostSurvivalTime);
            Assert.AreEqual(10, seasonStats.SoloFPP.RankPoints);
            Assert.AreEqual("10-10", seasonStats.SoloFPP.RankPointsTitle);
            Assert.AreEqual(10, seasonStats.SoloFPP.Revives);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.RideDistance);
            Assert.AreEqual(10, seasonStats.SoloFPP.RoadKills);
            Assert.AreEqual(10, seasonStats.SoloFPP.RoundMostKills);
            Assert.AreEqual(10, seasonStats.SoloFPP.RoundsPlayed);
            Assert.AreEqual(10, seasonStats.SoloFPP.Suicides);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.SwimDistance);
            Assert.AreEqual(10, seasonStats.SoloFPP.TeamKills);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.TimeSurvived);
            Assert.AreEqual(10, seasonStats.SoloFPP.Top10s);
            Assert.AreEqual(10, seasonStats.SoloFPP.VehicleDestroys);
            Assert.AreEqual(100.1234, seasonStats.SoloFPP.WalkDistance);
            Assert.AreEqual(10, seasonStats.SoloFPP.WeaponsAcquired);
            Assert.AreEqual(10, seasonStats.SoloFPP.WeeklyKills);
            Assert.AreEqual(10, seasonStats.SoloFPP.WeeklyWins);
            Assert.AreEqual(10, seasonStats.SoloFPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, seasonStats.SoloFPP.KillPoints);
            // Assert.AreEqual(10, seasonStats.SoloFPP.WinPoints);

            Assert.AreEqual(10, seasonStats.DuoTPP.Assists);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.BestRankPoint);
            Assert.AreEqual(10, seasonStats.DuoTPP.Boosts);
            Assert.AreEqual(10, seasonStats.DuoTPP.DailyKills);
            Assert.AreEqual(10, seasonStats.DuoTPP.DailyWins);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.DamageDealt);
            Assert.AreEqual(10, seasonStats.DuoTPP.Days);
            Assert.AreEqual(10, seasonStats.DuoTPP.DBNOs);
            Assert.AreEqual(10, seasonStats.DuoTPP.HeadshotKills);
            Assert.AreEqual(10, seasonStats.DuoTPP.Heals);
            Assert.AreEqual(10, seasonStats.DuoTPP.Kills);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.LongestKill);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.LongestTimeSurvived);
            Assert.AreEqual(10, seasonStats.DuoTPP.Losses);
            Assert.AreEqual(10, seasonStats.DuoTPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.MostSurvivalTime);
            Assert.AreEqual(10, seasonStats.DuoTPP.RankPoints);
            Assert.AreEqual("10-10", seasonStats.DuoTPP.RankPointsTitle);
            Assert.AreEqual(10, seasonStats.DuoTPP.Revives);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.RideDistance);
            Assert.AreEqual(10, seasonStats.DuoTPP.RoadKills);
            Assert.AreEqual(10, seasonStats.DuoTPP.RoundMostKills);
            Assert.AreEqual(10, seasonStats.DuoTPP.RoundsPlayed);
            Assert.AreEqual(10, seasonStats.DuoTPP.Suicides);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.SwimDistance);
            Assert.AreEqual(10, seasonStats.DuoTPP.TeamKills);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.TimeSurvived);
            Assert.AreEqual(10, seasonStats.DuoTPP.Top10s);
            Assert.AreEqual(10, seasonStats.DuoTPP.VehicleDestroys);
            Assert.AreEqual(100.1234, seasonStats.DuoTPP.WalkDistance);
            Assert.AreEqual(10, seasonStats.DuoTPP.WeaponsAcquired);
            Assert.AreEqual(10, seasonStats.DuoTPP.WeeklyKills);
            Assert.AreEqual(10, seasonStats.DuoTPP.WeeklyWins);
            Assert.AreEqual(10, seasonStats.DuoTPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, seasonStats.DuoTPP.KillPoints);
            // Assert.AreEqual(10, seasonStats.DuoTPP.WinPoints);

            Assert.AreEqual(10, seasonStats.DuoFPP.Assists);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.BestRankPoint);
            Assert.AreEqual(10, seasonStats.DuoFPP.Boosts);
            Assert.AreEqual(10, seasonStats.DuoFPP.DailyKills);
            Assert.AreEqual(10, seasonStats.DuoFPP.DailyWins);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.DamageDealt);
            Assert.AreEqual(10, seasonStats.DuoFPP.Days);
            Assert.AreEqual(10, seasonStats.DuoFPP.DBNOs);
            Assert.AreEqual(10, seasonStats.DuoFPP.HeadshotKills);
            Assert.AreEqual(10, seasonStats.DuoFPP.Heals);
            Assert.AreEqual(10, seasonStats.DuoFPP.Kills);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.LongestKill);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.LongestTimeSurvived);
            Assert.AreEqual(10, seasonStats.DuoFPP.Losses);
            Assert.AreEqual(10, seasonStats.DuoFPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.MostSurvivalTime);
            Assert.AreEqual(10, seasonStats.DuoFPP.RankPoints);
            Assert.AreEqual("10-10", seasonStats.DuoFPP.RankPointsTitle);
            Assert.AreEqual(10, seasonStats.DuoFPP.Revives);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.RideDistance);
            Assert.AreEqual(10, seasonStats.DuoFPP.RoadKills);
            Assert.AreEqual(10, seasonStats.DuoFPP.RoundMostKills);
            Assert.AreEqual(10, seasonStats.DuoFPP.RoundsPlayed);
            Assert.AreEqual(10, seasonStats.DuoFPP.Suicides);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.SwimDistance);
            Assert.AreEqual(10, seasonStats.DuoFPP.TeamKills);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.TimeSurvived);
            Assert.AreEqual(10, seasonStats.DuoFPP.Top10s);
            Assert.AreEqual(10, seasonStats.DuoFPP.VehicleDestroys);
            Assert.AreEqual(100.1234, seasonStats.DuoFPP.WalkDistance);
            Assert.AreEqual(10, seasonStats.DuoFPP.WeaponsAcquired);
            Assert.AreEqual(10, seasonStats.DuoFPP.WeeklyKills);
            Assert.AreEqual(10, seasonStats.DuoFPP.WeeklyWins);
            Assert.AreEqual(10, seasonStats.DuoFPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, seasonStats.DuoFPP.KillPoints);
            // Assert.AreEqual(10, seasonStats.DuoFPP.WinPoints);

            Assert.AreEqual(10, seasonStats.SquadTPP.Assists);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.BestRankPoint);
            Assert.AreEqual(10, seasonStats.SquadTPP.Boosts);
            Assert.AreEqual(10, seasonStats.SquadTPP.DailyKills);
            Assert.AreEqual(10, seasonStats.SquadTPP.DailyWins);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.DamageDealt);
            Assert.AreEqual(10, seasonStats.SquadTPP.Days);
            Assert.AreEqual(10, seasonStats.SquadTPP.DBNOs);
            Assert.AreEqual(10, seasonStats.SquadTPP.HeadshotKills);
            Assert.AreEqual(10, seasonStats.SquadTPP.Heals);
            Assert.AreEqual(10, seasonStats.SquadTPP.Kills);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.LongestKill);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.LongestTimeSurvived);
            Assert.AreEqual(10, seasonStats.SquadTPP.Losses);
            Assert.AreEqual(10, seasonStats.SquadTPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.MostSurvivalTime);
            Assert.AreEqual(10, seasonStats.SquadTPP.RankPoints);
            Assert.AreEqual("10-10", seasonStats.SquadTPP.RankPointsTitle);
            Assert.AreEqual(10, seasonStats.SquadTPP.Revives);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.RideDistance);
            Assert.AreEqual(10, seasonStats.SquadTPP.RoadKills);
            Assert.AreEqual(10, seasonStats.SquadTPP.RoundMostKills);
            Assert.AreEqual(10, seasonStats.SquadTPP.RoundsPlayed);
            Assert.AreEqual(10, seasonStats.SquadTPP.Suicides);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.SwimDistance);
            Assert.AreEqual(10, seasonStats.SquadTPP.TeamKills);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.TimeSurvived);
            Assert.AreEqual(10, seasonStats.SquadTPP.Top10s);
            Assert.AreEqual(10, seasonStats.SquadTPP.VehicleDestroys);
            Assert.AreEqual(100.1234, seasonStats.SquadTPP.WalkDistance);
            Assert.AreEqual(10, seasonStats.SquadTPP.WeaponsAcquired);
            Assert.AreEqual(10, seasonStats.SquadTPP.WeeklyKills);
            Assert.AreEqual(10, seasonStats.SquadTPP.WeeklyWins);
            Assert.AreEqual(10, seasonStats.SquadTPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, seasonStats.SquadTPP.KillPoints);
            // Assert.AreEqual(10, seasonStats.SquadTPP.WinPoints);

            Assert.AreEqual(10, seasonStats.SquadFPP.Assists);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.BestRankPoint);
            Assert.AreEqual(10, seasonStats.SquadFPP.Boosts);
            Assert.AreEqual(10, seasonStats.SquadFPP.DailyKills);
            Assert.AreEqual(10, seasonStats.SquadFPP.DailyWins);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.DamageDealt);
            Assert.AreEqual(10, seasonStats.SquadFPP.Days);
            Assert.AreEqual(10, seasonStats.SquadFPP.DBNOs);
            Assert.AreEqual(10, seasonStats.SquadFPP.HeadshotKills);
            Assert.AreEqual(10, seasonStats.SquadFPP.Heals);
            Assert.AreEqual(10, seasonStats.SquadFPP.Kills);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.LongestKill);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.LongestTimeSurvived);
            Assert.AreEqual(10, seasonStats.SquadFPP.Losses);
            Assert.AreEqual(10, seasonStats.SquadFPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.MostSurvivalTime);
            Assert.AreEqual(10, seasonStats.SquadFPP.RankPoints);
            Assert.AreEqual("10-10", seasonStats.SquadFPP.RankPointsTitle);
            Assert.AreEqual(10, seasonStats.SquadFPP.Revives);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.RideDistance);
            Assert.AreEqual(10, seasonStats.SquadFPP.RoadKills);
            Assert.AreEqual(10, seasonStats.SquadFPP.RoundMostKills);
            Assert.AreEqual(10, seasonStats.SquadFPP.RoundsPlayed);
            Assert.AreEqual(10, seasonStats.SquadFPP.Suicides);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.SwimDistance);
            Assert.AreEqual(10, seasonStats.SquadFPP.TeamKills);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.TimeSurvived);
            Assert.AreEqual(10, seasonStats.SquadFPP.Top10s);
            Assert.AreEqual(10, seasonStats.SquadFPP.VehicleDestroys);
            Assert.AreEqual(100.1234, seasonStats.SquadFPP.WalkDistance);
            Assert.AreEqual(10, seasonStats.SquadFPP.WeaponsAcquired);
            Assert.AreEqual(10, seasonStats.SquadFPP.WeeklyKills);
            Assert.AreEqual(10, seasonStats.SquadFPP.WeeklyWins);
            Assert.AreEqual(10, seasonStats.SquadFPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, seasonStats.SquadFPP.KillPoints);
            // Assert.AreEqual(10, seasonStats.SquadFPP.WinPoints);

            #endregion
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesLifetimeStatsCorrectly()
        {
            Stats lifetimeStats = Stats.Deserialize(LifetimeStatsSampleJson);

            #region Assertions

            Assert.AreEqual("account.id", lifetimeStats.AccountId);
            Assert.AreEqual("division.bro.official.pc-2018-03", lifetimeStats.SeasonId);

            Assert.AreEqual("matchid-solo-1", lifetimeStats.SoloTPPMatchIds[0]);
            Assert.AreEqual("matchid-solo-2", lifetimeStats.SoloTPPMatchIds[1]);

            Assert.AreEqual("matchid-soloFPP-2", lifetimeStats.SoloFPPMatchIds[0]);
            Assert.AreEqual("matchid-soloFPP-2", lifetimeStats.SoloFPPMatchIds[1]);

            Assert.AreEqual("matchid-duo-2", lifetimeStats.DuoTPPMatchIds[0]);
            Assert.AreEqual("matchid-duo-2", lifetimeStats.DuoTPPMatchIds[1]);

            Assert.AreEqual("matchid-duoFPP-2", lifetimeStats.DuoFPPMatchIds[0]);
            Assert.AreEqual("matchid-duoFPP-2", lifetimeStats.DuoFPPMatchIds[1]);

            Assert.AreEqual("matchid-squad-2", lifetimeStats.SquadTPPMatchIds[0]);
            Assert.AreEqual("matchid-squad-2", lifetimeStats.SquadTPPMatchIds[1]);

            Assert.AreEqual("matchid-squadFPP-2", lifetimeStats.SquadFPPMatchIds[0]);
            Assert.AreEqual("matchid-squadFPP-2", lifetimeStats.SquadFPPMatchIds[1]);

            Assert.AreEqual(10, lifetimeStats.SoloTPP.Assists);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.BestRankPoint);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Boosts);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.DailyKills);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.DailyWins);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.DamageDealt);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Days);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.DBNOs);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.HeadshotKills);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Heals);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Kills);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.LongestKill);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.LongestTimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Losses);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.MostSurvivalTime);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.RankPoints);
            Assert.AreEqual("10-10", lifetimeStats.SoloTPP.RankPointsTitle);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Revives);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.RideDistance);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.RoadKills);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.RoundMostKills);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.RoundsPlayed);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Suicides);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.SwimDistance);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.TeamKills);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.TimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Top10s);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.VehicleDestroys);
            Assert.AreEqual(100.1234, lifetimeStats.SoloTPP.WalkDistance);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.WeaponsAcquired);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.WeeklyKills);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.WeeklyWins);
            Assert.AreEqual(10, lifetimeStats.SoloTPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, lifetimeStats.SoloTPP.KillPoints);
            // Assert.AreEqual(10, lifetimeStats.SoloTPP.WinPoints);

            Assert.AreEqual(10, lifetimeStats.SoloFPP.Assists);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.BestRankPoint);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Boosts);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.DailyKills);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.DailyWins);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.DamageDealt);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Days);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.DBNOs);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.HeadshotKills);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Heals);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Kills);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.LongestKill);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.LongestTimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Losses);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.MostSurvivalTime);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.RankPoints);
            Assert.AreEqual("10-10", lifetimeStats.SoloFPP.RankPointsTitle);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Revives);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.RideDistance);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.RoadKills);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.RoundMostKills);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.RoundsPlayed);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Suicides);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.SwimDistance);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.TeamKills);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.TimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Top10s);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.VehicleDestroys);
            Assert.AreEqual(100.1234, lifetimeStats.SoloFPP.WalkDistance);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.WeaponsAcquired);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.WeeklyKills);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.WeeklyWins);
            Assert.AreEqual(10, lifetimeStats.SoloFPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, lifetimeStats.SoloFPP.KillPoints);
            // Assert.AreEqual(10, lifetimeStats.SoloFPP.WinPoints);

            Assert.AreEqual(10, lifetimeStats.DuoTPP.Assists);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.BestRankPoint);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Boosts);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.DailyKills);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.DailyWins);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.DamageDealt);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Days);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.DBNOs);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.HeadshotKills);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Heals);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Kills);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.LongestKill);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.LongestTimeSurvived);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Losses);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.MostSurvivalTime);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.RankPoints);
            Assert.AreEqual("10-10", lifetimeStats.DuoTPP.RankPointsTitle);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Revives);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.RideDistance);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.RoadKills);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.RoundMostKills);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.RoundsPlayed);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Suicides);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.SwimDistance);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.TeamKills);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.TimeSurvived);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Top10s);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.VehicleDestroys);
            Assert.AreEqual(100.1234, lifetimeStats.DuoTPP.WalkDistance);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.WeaponsAcquired);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.WeeklyKills);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.WeeklyWins);
            Assert.AreEqual(10, lifetimeStats.DuoTPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, lifetimeStats.DuoTPP.KillPoints);
            // Assert.AreEqual(10, lifetimeStats.DuoTPP.WinPoints);

            Assert.AreEqual(10, lifetimeStats.DuoFPP.Assists);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.BestRankPoint);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Boosts);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.DailyKills);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.DailyWins);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.DamageDealt);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Days);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.DBNOs);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.HeadshotKills);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Heals);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Kills);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.LongestKill);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.LongestTimeSurvived);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Losses);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.MostSurvivalTime);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.RankPoints);
            Assert.AreEqual("10-10", lifetimeStats.DuoFPP.RankPointsTitle);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Revives);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.RideDistance);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.RoadKills);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.RoundMostKills);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.RoundsPlayed);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Suicides);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.SwimDistance);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.TeamKills);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.TimeSurvived);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Top10s);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.VehicleDestroys);
            Assert.AreEqual(100.1234, lifetimeStats.DuoFPP.WalkDistance);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.WeaponsAcquired);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.WeeklyKills);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.WeeklyWins);
            Assert.AreEqual(10, lifetimeStats.DuoFPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, lifetimeStats.DuoFPP.KillPoints);
            // Assert.AreEqual(10, lifetimeStats.DuoFPP.WinPoints);

            Assert.AreEqual(10, lifetimeStats.SquadTPP.Assists);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.BestRankPoint);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Boosts);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.DailyKills);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.DailyWins);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.DamageDealt);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Days);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.DBNOs);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.HeadshotKills);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Heals);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Kills);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.LongestKill);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.LongestTimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Losses);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.MostSurvivalTime);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.RankPoints);
            Assert.AreEqual("10-10", lifetimeStats.SquadTPP.RankPointsTitle);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Revives);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.RideDistance);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.RoadKills);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.RoundMostKills);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.RoundsPlayed);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Suicides);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.SwimDistance);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.TeamKills);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.TimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Top10s);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.VehicleDestroys);
            Assert.AreEqual(100.1234, lifetimeStats.SquadTPP.WalkDistance);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.WeaponsAcquired);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.WeeklyKills);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.WeeklyWins);
            Assert.AreEqual(10, lifetimeStats.SquadTPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, lifetimeStats.SquadTPP.KillPoints);
            // Assert.AreEqual(10, lifetimeStats.SquadTPP.WinPoints);

            Assert.AreEqual(10, lifetimeStats.SquadFPP.Assists);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.BestRankPoint);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Boosts);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.DailyKills);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.DailyWins);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.DamageDealt);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Days);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.DBNOs);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.HeadshotKills);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Heals);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Kills);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.LongestKill);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.LongestTimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Losses);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.MaxKillStreaks);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.MostSurvivalTime);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.RankPoints);
            Assert.AreEqual("10-10", lifetimeStats.SquadFPP.RankPointsTitle);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Revives);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.RideDistance);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.RoadKills);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.RoundMostKills);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.RoundsPlayed);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Suicides);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.SwimDistance);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.TeamKills);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.TimeSurvived);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Top10s);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.VehicleDestroys);
            Assert.AreEqual(100.1234, lifetimeStats.SquadFPP.WalkDistance);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.WeaponsAcquired);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.WeeklyKills);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.WeeklyWins);
            Assert.AreEqual(10, lifetimeStats.SquadFPP.Wins);
            // Obsolete
            // Assert.AreEqual(10, lifetimeStats.SquadFPP.KillPoints);
            // Assert.AreEqual(10, lifetimeStats.SquadFPP.WinPoints);

            #endregion
        }
    }
}

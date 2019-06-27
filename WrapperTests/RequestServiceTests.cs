using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PUBGAPIWrapper;
using PUBGAPIWrapper.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using WrapperTests.Serialization;

namespace WrapperTests
{
    [TestClass]
    public class RequestServiceTests
    {
        public static string ApiKey = "A1B2C3D4";
        public static int HeaderCount = 2;
        public static PlatformShard Shard = PlatformShard.Steam;
        public static string GameMode = "squad";

        public static List<string> Ids = new List<string>()
        {
            "account.id-123", "account.id-456"
        };

        public static List<KeyValuePair<string, string>> ExpectedHeaders = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("Authorization", "Bearer " + ApiKey),
            new KeyValuePair<string, string>("Accept", "application/vnd.api+json")
        };

        [TestClass]
        public class Players
        {
            public List<string> Names = new List<string>()
            {
                "Player1", "Player2"
            };

            public static IRestResponse PlayerResponse = new RestResponse()
            {
                Content = PlayerTests.SampleJson
            };

            public static IRestResponse PlayerListResponse = new RestResponse()
            {
                Content = PlayerTests.SampleListJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetPlayerId_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerListResponse);

                var result = arrangement.Instance.GetPlayerId(Shard, Names[0]);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetPlayerId_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerListResponse);

                var result = arrangement.Instance.GetPlayerId(Shard, Names[0]);

                Assert.AreEqual(Ids[0], result);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetPlayer_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerResponse);

                var result = arrangement.Instance.GetPlayer(Shard, Ids[0]);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetPlayer_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerResponse);

                var result = arrangement.Instance.GetPlayer(Shard, Ids[0]);

                Assert.AreEqual(Names[0], result.Name);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetPlayers_ById_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerListResponse);

                var result = arrangement.Instance.GetPlayers(Shard, Ids, null);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetPlayers_ByName_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerListResponse);

                var result = arrangement.Instance.GetPlayers(Shard, null, Names);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetPlayers_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(PlayerListResponse);

                var result = arrangement.Instance.GetPlayers(Shard, Ids, null);

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(Names[0], result[0].Name);
                Assert.AreEqual(Names[1], result[1].Name);
            }
        }

        [TestClass]
        public class Seasons
        {
            public static IRestResponse Response = new RestResponse()
            {
                Content = SeasonTests.SampleJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetSeasons_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetSeasons(Shard);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSeasons_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetSeasons(Shard);

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("division.bro.official.2017-beta", result[0].Id);
                Assert.AreEqual("division.bro.official.pc-2018-03", result[1].Id);
            }
        }

        [TestClass]
        public class Stats
        {
            public string SeasonId = "season1";

            public static IRestResponse SeasonResponse = new RestResponse()
            {
                Content = StatsTests.SampleSeasonJson
            };

            public static IRestResponse LifetimeResponse = new RestResponse()
            {
                Content = StatsTests.SampleLifetimeJson
            };

            public static IRestResponse ListResponse = new RestResponse()
            {
                Content = StatsTests.SampleListJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetSeasonStatsForPlayer_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(SeasonResponse);

                var result = arrangement.Instance.GetSeasonStatsForPlayer(Shard, Ids[0], SeasonId);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSeasonStatsForPlayer_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(SeasonResponse);

                var result = arrangement.Instance.GetSeasonStatsForPlayer(Shard, Ids[0], SeasonId);

                Assert.AreEqual(Ids[0], result.AccountId);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSeasonStatsForMultiplePlayers_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(ListResponse);

                var result = arrangement.Instance.GetSeasonStatsForMultiplePlayers(Shard, SeasonId, GameMode, Ids);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSeasonStatsForMultiplePlayers_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(ListResponse);

                var result = arrangement.Instance.GetSeasonStatsForMultiplePlayers(Shard, SeasonId, GameMode, Ids);

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(Ids[0], result[0].AccountId);
                Assert.AreEqual(Ids[1], result[1].AccountId);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetLifetimeStatsForPlayer_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(LifetimeResponse);

                var result = arrangement.Instance.GetLifetimeStatsForPlayer(Shard, Ids[0]);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetLifetimeStatsForPlayer_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(LifetimeResponse);

                var result = arrangement.Instance.GetLifetimeStatsForPlayer(Shard, Ids[0]);

                Assert.AreEqual(Ids[0], result.AccountId);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetLifetimeStatsForMultiplePlayers_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(ListResponse);

                var result = arrangement.Instance.GetLifetimeStatsForMultiplePlayers(Shard, GameMode, Ids);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetLifetimeStatsForMultiplePlayers_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(ListResponse);

                var result = arrangement.Instance.GetLifetimeStatsForMultiplePlayers(Shard, GameMode, Ids);

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(Ids[0], result[0].AccountId);
                Assert.AreEqual(Ids[1], result[1].AccountId);
            }
        }

        [TestClass]
        public class Matches
        {
            public string MatchId = "match.id-123";
            public DateTime CreatedAtFilter = new DateTime(2000, 1, 1);

            public static IRestResponse Response = new RestResponse()
            {
                Content = MatchTests.SampleJson
            };

            public static IRestResponse SampleResponse = new RestResponse()
            {
                Content = SampleTests.SampleJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetMatch_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetMatch(Shard, MatchId);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetMatch_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetMatch(Shard, MatchId);

                Assert.AreEqual("546b7a2d-92ef-49c5-926c-7a1101497006", result.Id);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSampleMatches_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(SampleResponse);

                var result = arrangement.Instance.GetSampleMatches(Shard);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSampleMatches_ItMakesTheCorrectRequest_AndAppliesCreatedAtFilter()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(SampleResponse);

                var result = arrangement.Instance.GetSampleMatches(Shard, CreatedAtFilter);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetSampleMatches_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(SampleResponse);

                var result = arrangement.Instance.GetSampleMatches(Shard);

                Assert.AreEqual(2, result.Ids.Count);
            }
        }

        [TestClass]
        public class Leaderboards
        {
            public int Page = 0;

            public static IRestResponse Response = new RestResponse()
            {
                Content = LeaderboardTests.SampleJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetLeaderboard_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetLeaderboard(Shard, GameMode, Page);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetLeaderboard_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetLeaderboard(Shard, GameMode, Page);

                Assert.AreEqual(2, result.PlayerStats.Count);
            }
        }

        [TestClass]
        public class Tournament
        {
            public string Id = "tournament.id-123";

            public static IRestResponse Response = new RestResponse()
            {
                Content = TournamentTests.SampleJson
            };

            public static IRestResponse MatchesResponse = new RestResponse()
            {
                Content = TournamentTests.MatchesSampleJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetTournament_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(MatchesResponse);

                var result = arrangement.Instance.GetTournament(Id);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetTournament_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(MatchesResponse);

                var result = arrangement.Instance.GetTournament(Id);

                Assert.AreEqual("na-nplf", result.Id);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetTournamentsList_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetTournamentsList();
            }

            [TestMethod, TestCategory("Unit")]
            public void GetTournamentsList_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetTournamentsList();

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("sea-pvs19", result[0].Id);
                Assert.AreEqual("na-nplf", result[1].Id);
            }
        }

        [TestClass]
        public class Telemetry
        {
            public string Uri = "www.test.com";

            public static IRestResponse Response = new RestResponse()
            {
                Content = TelemetryTests.SampleJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetTelemetry_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetTelemetry(Uri);
            }

            [TestMethod, TestCategory("Unit")]
            public void GetTelemetry_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetTelemetry(Uri);
                
                Assert.AreEqual(1, result.ArmorDestroyEvents.Count);
                Assert.AreEqual(1, result.CarePackageLandEvents.Count);
                Assert.AreEqual(1, result.CarePackageSpawnEvents.Count);
                Assert.AreEqual(1, result.GameStatePeriodicEvents.Count);
                Assert.AreEqual(2, result.HealEvents.Count);
                Assert.AreEqual(1, result.ItemAttachEvents.Count);
                Assert.AreEqual(1, result.ItemDetachEvents.Count);
                Assert.AreEqual(1, result.ItemDropEvents.Count);
                Assert.AreEqual(1, result.ItemEquipEvents.Count);
                Assert.AreEqual(1, result.ItemPickupEvents.Count);
                Assert.AreEqual(1, result.ItemPickupFromCarePackageEvents.Count);
                Assert.AreEqual(1, result.ItemPickupFromLootBoxEvents.Count);
                Assert.AreEqual(1, result.ItemUnequipEvents.Count);
                Assert.AreEqual(1, result.ItemUseEvents.Count);
                Assert.AreEqual(1, result.MatchDefinitionEvents.Count);
                Assert.AreEqual(1, result.MatchEndEvents.Count);
                Assert.AreEqual(1, result.MatchStartEvents.Count);
                Assert.AreEqual(1, result.ObjectDestroyEvents.Count);
                Assert.AreEqual(1, result.ParachuteLandingEvents.Count);
                Assert.AreEqual(1, result.PlayerAttackEvents.Count);
                Assert.AreEqual(1, result.PlayerCreateEvents.Count);
                Assert.AreEqual(1, result.PlayerKillEvents.Count);
                Assert.AreEqual(1, result.PlayerLoginEvents.Count);
                Assert.AreEqual(1, result.PlayerLogoutEvents.Count);
                Assert.AreEqual(1, result.PlayerMakeGroggyEvents.Count);
                Assert.AreEqual(1, result.PlayerPositionEvents.Count);
                Assert.AreEqual(1, result.PlayerTakeDamageEvents.Count);
                Assert.AreEqual(1, result.RedZoneEndedEvents.Count);
                Assert.AreEqual(1, result.SwimEndEvents.Count);
                Assert.AreEqual(1, result.SwimStartEvents.Count);
                Assert.AreEqual(1, result.VaultStartEvents.Count);
                Assert.AreEqual(3, result.VehicleDestroyEvents.Count);
                Assert.AreEqual(1, result.VehicleLeaveEvents.Count);
                Assert.AreEqual(1, result.VehicleRideEvents.Count);
                Assert.AreEqual(1, result.WeaponFireCountEvents.Count);
                Assert.AreEqual(1, result.WheelDestroyEvents.Count);
            }
        }

        [TestClass]
        public class Status
        {
            public static IRestResponse Response = new RestResponse()
            {
                Content = StatusTests.SampleJson
            };

            [TestMethod, TestCategory("Unit")]
            public void GetStatus_ItMakesTheCorrectRequest()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetStatus();

                arrangement.MockClient.Verify(x => x.Execute(It.Is<RestRequest>(r =>
                    AssertParameters(r) &&
                    r.Resource == "/status")));
            }

            [TestMethod, TestCategory("Unit")]
            public void GetStatus_ItReturnsTheCorrectResponse()
            {
                var arrangement = new Arrangement()
                    .WithRequestReturning(Response);

                var result = arrangement.Instance.GetStatus();

                Assert.AreEqual("pubg-api", result.Id);
            }
        }

        public static bool AssertParameters(RestRequest request)
        {
            if (request.Parameters.Count != HeaderCount) return false;
            foreach (KeyValuePair<string, string> entry in ExpectedHeaders)
            {
                if(request.Parameters.SingleOrDefault(p => 
                    p.Name == entry.Key && 
                    (string)p.Value == entry.Value) == null)
                    return false;
            }
            return true;
        }

        public class Arrangement
        {
            public RequestService Instance { get; set; }
            public Mock<IRestClient> MockClient { get; set; }

            public Arrangement()
            {
                MockClient = new Mock<IRestClient>();
                this.Instance = new RequestService(MockClient.Object, ApiKey);
            }
            public Arrangement WithRequestReturning(IRestResponse response)
            {
                MockClient.Setup(x => x.Execute(It.IsAny<IRestRequest>()))
                    .Returns(response);

                return this;
            }
        }
    }
}

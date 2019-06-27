using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class MatchTests
    {
        #region Test Data

        public static string SampleJson = @"{
    ""data"": {
        ""type"": ""match"",
        ""id"": ""546b7a2d-92ef-49c5-926c-7a1101497006"",
        ""attributes"": {
            ""createdAt"": ""2019-06-19T23:36:54Z"",
            ""duration"": 1897,
            ""stats"": null,
            ""gameMode"": ""squad"",
            ""tags"": null,
            ""titleId"": ""bluehole-pubg"",
            ""shardId"": ""steam"",
            ""mapName"": ""Erangel_Main"",
            ""isCustomMatch"": false,
            ""seasonState"": ""closed""
        },
        ""relationships"": {
            ""rosters"": {
                ""data"": [
                    {
                        ""type"": ""roster"",
                        ""id"": ""a0e9aa5d-e924-4846-8e3f-4f7d2409fbc3""
                    },
                    {
                        ""type"": ""roster"",
                        ""id"": ""1d00de40-0d0f-438c-92e8-fd2071e062c5""
                    }
                ]
            },
            ""assets"": {
                ""data"": [
                    {
                        ""type"": ""asset"",
                        ""id"": ""b7d13bd6-92ef-11e9-916e-0a5864679415""
                    }
                ]
            }
        },
        ""links"": {
            ""self"": ""https://api.playbattlegrounds.com/shards/steam/matches/546b7a2d-92ef-49c5-926c-7a1101497006"",
            ""schema"": """"
        }
    },
    ""included"": [
        {
            ""type"": ""participant"",
            ""id"": ""b152bc45-3bcc-4599-b8a8-db94fad54e83"",
            ""attributes"": {
                ""shardId"": ""steam"",
                ""stats"": {
                    ""DBNOs"": 10,
                    ""assists"": 10,
                    ""boosts"": 10,
                    ""damageDealt"": 10,
                    ""deathType"": ""byplayer"",
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPlace"": 73,
                    ""killPoints"": 10,
                    ""killPointsDelta"": 10,
                    ""killStreaks"": 10,
                    ""kills"": 10,
                    ""lastKillPoints"": 10,
                    ""lastWinPoints"": 10,
                    ""longestKill"": 10,
                    ""mostDamage"": 10,
                    ""name"": ""Player2"",
                    ""playerId"": ""account.id2"",
                    ""rankPoints"": 10,
                    ""revives"": 10,
                    ""rideDistance"": 10,
                    ""roadKills"": 10,
                    ""swimDistance"": 10,
                    ""teamKills"": 10,
                    ""timeSurvived"": 125.238,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 16.4002438,
                    ""weaponsAcquired"": 10,
                    ""winPlace"": 22,
                    ""winPoints"": 10,
                    ""winPointsDelta"": 10
                },
                ""actor"": """"
            }
        },
        {
            ""type"": ""participant"",
            ""id"": ""8526fea9-9ad3-4b29-a1f7-b65a9151cc2f"",
            ""attributes"": {
                ""stats"": {
                    ""DBNOs"": 10,
                    ""assists"": 10,
                    ""boosts"": 10,
                    ""damageDealt"": 132.959991,
                    ""deathType"": ""byplayer"",
                    ""headshotKills"": 10,
                    ""heals"": 10,
                    ""killPlace"": 29,
                    ""killPoints"": 10,
                    ""killPointsDelta"": 10,
                    ""killStreaks"": 10,
                    ""kills"": 10,
                    ""lastKillPoints"": 10,
                    ""lastWinPoints"": 10,
                    ""longestKill"": 1.89027333,
                    ""mostDamage"": 10,
                    ""name"": ""Player1"",
                    ""playerId"": ""account.id1"",
                    ""rankPoints"": 10,
                    ""revives"": 10,
                    ""rideDistance"": 10,
                    ""roadKills"": 10,
                    ""swimDistance"": 10,
                    ""teamKills"": 10,
                    ""timeSurvived"": 564.757,
                    ""vehicleDestroys"": 10,
                    ""walkDistance"": 793.2754,
                    ""weaponsAcquired"": 10,
                    ""winPlace"": 22,
                    ""winPoints"": 10,
                    ""winPointsDelta"": 10
                },
                ""actor"": """",
                ""shardId"": ""steam""
            }
        },
        {
            ""type"": ""roster"",
            ""id"": ""cef9da8a-659f-4313-bf6b-8725d0c0f6e4"",
            ""attributes"": {
                ""stats"": {
                    ""rank"": 1,
                    ""teamId"": 20
                },
                ""won"": ""true"",
                ""shardId"": ""steam""
            },
            ""relationships"": {
                ""team"": {
                    ""data"": null
                },
                ""participants"": {
                    ""data"": [
                        {
                            ""type"": ""participant"",
                            ""id"": ""1e3a5af2-4f60-46fb-8cca-5ab2fe09bb1d""
                        },
                        {
                            ""type"": ""participant"",
                            ""id"": ""09c7cef5-a673-4d61-be87-69b9302986e7""
                        },
                        {
                            ""type"": ""participant"",
                            ""id"": ""bb8ca5d0-0a59-4f4e-a469-a198e649351e""
                        }
                    ]
                }
            }
        },
        {
            ""type"": ""roster"",
            ""id"": ""a62b831b-9995-4549-a46f-3db293910ce8"",
            ""attributes"": {
                ""shardId"": ""steam"",
                ""stats"": {
                    ""rank"": 2,
                    ""teamId"": 19
                },
                ""won"": ""false""
            },
            ""relationships"": {
                ""team"": {
                    ""data"": null
                },
                ""participants"": {
                    ""data"": [
                        {
                            ""type"": ""participant"",
                            ""id"": ""3addfd8d-d6b7-4ad4-a40a-e9c858d62428""
                        },
                        {
                            ""type"": ""participant"",
                            ""id"": ""d5055b52-8ec8-4d2b-a5aa-76f91d15d163""
                        },
                        {
                            ""type"": ""participant"",
                            ""id"": ""30509d7a-4f77-4f27-8ecb-eea3507ce2a6""
                        },
                        {
                            ""type"": ""participant"",
                            ""id"": ""a7e6c340-e0a3-4b3f-aebe-9d7088550c7a""
                        }
                    ]
                }
            }
        },
        {
            ""type"": ""asset"",
            ""id"": ""b7d13bd6-92ef-11e9-916e-0a5864679415"",
            ""attributes"": {
                ""createdAt"": ""2019-06-20T00:09:49Z"",
                ""URL"": ""https://telemetry-cdn.playbattlegrounds.com/bluehole-pubg/pc-sa/2019/06/20/00/09/b7d13bd6-92ef-11e9-916e-0a5864679415-telemetry.json"",
                ""name"": ""telemetry"",
                ""description"": """"
            }
        },
    ],
    ""links"": {
        ""self"": ""https://api-origin.playbattlegrounds.com/shards/steam/matches/546b7a2d-92ef-49c5-926c-7a1101497006""
    },
    ""meta"": {}
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            Match match = Match.Deserialize(SampleJson);

            Assert.AreEqual("546b7a2d-92ef-49c5-926c-7a1101497006", match.Id);
            Assert.AreEqual("6/19/2019 11:36:54 PM", match.Created.ToString());
            Assert.AreEqual(1897, match.Duration);
            Assert.AreEqual("squad", match.GameMode);
            Assert.AreEqual("Erangel_Main", match.Map);
            Assert.IsFalse(match.IsCustomMatch);
            Assert.AreEqual("closed", match.SeasonState);
            Assert.AreEqual("steam", match.Shard);
            Assert.AreEqual("bluehole-pubg", match.Title);
            
            Assert.AreEqual(2, match.Rosters.Count);

            Assert.AreEqual("cef9da8a-659f-4313-bf6b-8725d0c0f6e4", match.Rosters[0].Id);
            Assert.IsTrue(match.Rosters[0].Won);
            Assert.AreEqual("steam", match.Rosters[0].Shard);
            Assert.AreEqual(1, match.Rosters[0].Rank);
            Assert.AreEqual(20, match.Rosters[0].TeamId);
            Assert.AreEqual(3, match.Rosters[0].ParticipantIds.Count);
            Assert.AreEqual("1e3a5af2-4f60-46fb-8cca-5ab2fe09bb1d", match.Rosters[0].ParticipantIds[0]);
            Assert.AreEqual("09c7cef5-a673-4d61-be87-69b9302986e7", match.Rosters[0].ParticipantIds[1]);
            Assert.AreEqual("bb8ca5d0-0a59-4f4e-a469-a198e649351e", match.Rosters[0].ParticipantIds[2]);

            Assert.AreEqual("a62b831b-9995-4549-a46f-3db293910ce8", match.Rosters[1].Id);
            Assert.IsFalse(match.Rosters[1].Won);
            Assert.AreEqual("steam", match.Rosters[1].Shard);
            Assert.AreEqual(2, match.Rosters[1].Rank);
            Assert.AreEqual(19, match.Rosters[1].TeamId);
            Assert.AreEqual(4, match.Rosters[1].ParticipantIds.Count);
            Assert.AreEqual("3addfd8d-d6b7-4ad4-a40a-e9c858d62428", match.Rosters[1].ParticipantIds[0]);
            Assert.AreEqual("d5055b52-8ec8-4d2b-a5aa-76f91d15d163", match.Rosters[1].ParticipantIds[1]);
            Assert.AreEqual("30509d7a-4f77-4f27-8ecb-eea3507ce2a6", match.Rosters[1].ParticipantIds[2]);
            Assert.AreEqual("a7e6c340-e0a3-4b3f-aebe-9d7088550c7a", match.Rosters[1].ParticipantIds[3]);

            Assert.AreEqual(2, match.Participants.Count);

            Assert.AreEqual("b152bc45-3bcc-4599-b8a8-db94fad54e83", match.Participants[0].Id);
            Assert.AreEqual("Player2", match.Participants[0].Name);
            Assert.AreEqual("account.id2", match.Participants[0].PlayerId);
            Assert.AreEqual("", match.Participants[0].Actor);
            Assert.AreEqual("steam", match.Participants[0].Shard);
            Assert.AreEqual(10, match.Participants[0].DBNOs);
            Assert.AreEqual(10, match.Participants[0].Assists);
            Assert.AreEqual(10, match.Participants[0].Boosts);
            Assert.AreEqual(10, match.Participants[0].DamageDealt);
            Assert.AreEqual("byplayer", match.Participants[0].DeathType);
            Assert.AreEqual(10, match.Participants[0].HeadshotKills);
            Assert.AreEqual(10, match.Participants[0].Heals);
            Assert.AreEqual(73, match.Participants[0].KillPlace);
            Assert.AreEqual(10, match.Participants[0].KillStreaks);
            Assert.AreEqual(10, match.Participants[0].Kills);
            Assert.AreEqual(10, match.Participants[0].LongestKill);
            Assert.AreEqual(10, match.Participants[0].Revives);
            Assert.AreEqual(10, match.Participants[0].RideDistance);
            Assert.AreEqual(10, match.Participants[0].RoadKills);
            Assert.AreEqual(10, match.Participants[0].SwimDistance);
            Assert.AreEqual(10, match.Participants[0].TeamKills);
            Assert.AreEqual(125.238, match.Participants[0].TimeSurvived);
            Assert.AreEqual(10, match.Participants[0].VehicleDestroys);
            Assert.AreEqual(16.4002438, match.Participants[0].WalkDistance);
            Assert.AreEqual(10, match.Participants[0].WeaponsAcquired);
            Assert.AreEqual(22, match.Participants[0].WinPlace);

            Assert.AreEqual("8526fea9-9ad3-4b29-a1f7-b65a9151cc2f", match.Participants[1].Id);
            Assert.AreEqual("Player1", match.Participants[1].Name);
            Assert.AreEqual("account.id1", match.Participants[1].PlayerId);
            Assert.AreEqual("", match.Participants[1].Actor);
            Assert.AreEqual("steam", match.Participants[1].Shard);
            Assert.AreEqual(10, match.Participants[1].DBNOs);
            Assert.AreEqual(10, match.Participants[1].Assists);
            Assert.AreEqual(10, match.Participants[1].Boosts);
            Assert.AreEqual(132.959991, match.Participants[1].DamageDealt);
            Assert.AreEqual("byplayer", match.Participants[1].DeathType);
            Assert.AreEqual(10, match.Participants[1].HeadshotKills);
            Assert.AreEqual(10, match.Participants[1].Heals);
            Assert.AreEqual(29, match.Participants[1].KillPlace);
            Assert.AreEqual(10, match.Participants[1].KillStreaks);
            Assert.AreEqual(10, match.Participants[1].Kills);
            Assert.AreEqual(1.89027333, match.Participants[1].LongestKill);
            Assert.AreEqual(10, match.Participants[1].Revives);
            Assert.AreEqual(10, match.Participants[1].RideDistance);
            Assert.AreEqual(10, match.Participants[1].RoadKills);
            Assert.AreEqual(10, match.Participants[1].SwimDistance);
            Assert.AreEqual(10, match.Participants[1].TeamKills);
            Assert.AreEqual(564.757, match.Participants[1].TimeSurvived);
            Assert.AreEqual(10, match.Participants[1].VehicleDestroys);
            Assert.AreEqual(793.2754, match.Participants[1].WalkDistance);
            Assert.AreEqual(10, match.Participants[1].WeaponsAcquired);
            Assert.AreEqual(22, match.Participants[1].WinPlace);

            Assert.AreEqual("b7d13bd6-92ef-11e9-916e-0a5864679415", match.Telemetry.Id);
            Assert.AreEqual("6/20/2019 12:09:49 AM", match.Telemetry.Created.ToString());
            Assert.AreEqual("https://telemetry-cdn.playbattlegrounds.com/bluehole-pubg/pc-sa/2019/06/20/00/09/b7d13bd6-92ef-11e9-916e-0a5864679415-telemetry.json", match.Telemetry.URL);
            Assert.AreEqual("telemetry", match.Telemetry.Name);
            Assert.AreEqual("", match.Telemetry.Description);
        }
    }
}

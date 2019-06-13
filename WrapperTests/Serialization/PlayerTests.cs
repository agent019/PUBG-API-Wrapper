using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PUBGAPIWrapper.Models;
using System.Collections.Generic;
using System.Linq;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class PlayerTests
    {
        public static PlayerDTO SamplePlayer = new PlayerDTO()
        {
            Data = new PlayerData()
            {
                Attributes = new Attributes()
                {
                    Name = "Name",
                    Shard = "pc-na",
                    Title = "Title",
                    Version = "v3"
                },
                Id = "123-ABC",
                Relationships = new PlayerRelationships()
                {
                    Matches = new PlayerMatches()
                    {
                        Data = new System.Collections.Generic.List<PlayerMatchesData>()
                        {
                            new PlayerMatchesData()
                            {
                                Id = "456-DEF"
                            },
                            new PlayerMatchesData()
                            {
                                Id = "789-GHI"
                            },
                        }
                    }
                }
            }
        };

        public static PlayerDTO SampleSecondPlayer = new PlayerDTO()
        {
            Data = new PlayerData()
            {
                Id = "ABC-123",
            }
        };

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayersCorrectly()
        {
            string serialized = JsonConvert.SerializeObject(SamplePlayer);

            Player result = Player.Deserialize(serialized);

            Assert.AreEqual("123-ABC", result.Id);
            Assert.AreEqual("pc-na", result.Shard);
            Assert.AreEqual("Title", result.Title);
            Assert.AreEqual("v3", result.Version);
            Assert.AreEqual(2, result.MatchIds.Count);
            Assert.IsTrue(result.MatchIds.Contains("456-DEF"));
            Assert.IsTrue(result.MatchIds.Contains("789-GHI"));
        }

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesPlayerListsCorrectly()
        {
            List<PlayerDTO> players = new List<PlayerDTO>()
            {
                SamplePlayer, SampleSecondPlayer
            };

            string serialized = JsonConvert.SerializeObject(players);

            List<Player> results = Player.DeserializePlayerList(serialized);

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Any(x => x.Id == "123-ABC"));
            Assert.IsTrue(results.Any(x => x.Id == "ABC-123"));
        }
    }
}

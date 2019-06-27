using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class SampleTests
    {
        #region Test Data

        public static string SampleJson = @"{
    ""data"": {
        ""type"": ""sample"",
        ""id"": ""d99c2292-a77e-482b-a7c1-03d9e0fa383d"",
        ""attributes"": {
            ""createdAt"": ""2019-06-18T00:00:00Z"",
            ""titleId"": ""bluehole-pubg"",
            ""shardId"": ""steam""
        },
        ""relationships"": {
            ""matches"": {
                ""data"": [
                    {
                        ""type"": ""match"",
                        ""id"": ""3d3a4664-b8cb-4180-a9a7-8e7f39aa3a3c""
                    },
                    {
                        ""type"": ""match"",
                        ""id"": ""92f722b5-73be-4734-8978-dff76a452fbf""
                    }
                ]
            }
        }
    }
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            Sample sample = Sample.Deserialize(SampleJson);

            Assert.AreEqual(2, sample.Ids.Count);
            Assert.IsTrue(sample.Ids.Contains("3d3a4664-b8cb-4180-a9a7-8e7f39aa3a3c"));
            Assert.IsTrue(sample.Ids.Contains("92f722b5-73be-4734-8978-dff76a452fbf"));
        }
    }
}

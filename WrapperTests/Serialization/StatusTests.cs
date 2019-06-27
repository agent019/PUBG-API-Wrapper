using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PUBGAPIWrapper.Models;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class StatusTests
    {
        #region Test Data

        public static string SampleJson = @"{
    ""data"": {
        ""type"": ""status"",
        ""id"": ""pubg-api""
    }
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            Status result = JsonConvert.DeserializeObject<Status>(SampleJson);
            
            Assert.AreEqual("pubg-api", result.Id);
            Assert.AreEqual("status", result.Type);
        }
    }
}

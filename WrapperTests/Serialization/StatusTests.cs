using Microsoft.VisualStudio.TestTools.UnitTesting;
using PUBGAPIWrapper.Models;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class StatusTests
    {
        #region Test Data

        public readonly string SampleStatusJson = @"{
    ""data"": {
        ""type"": ""status"",
        ""id"": ""pubg-api""
    }
}";

        #endregion

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            Status result = Status.Deserialize(SampleStatusJson);
            
            Assert.AreEqual("pubg-api", result.Id);
            Assert.AreEqual("status", result.Type);
        }
    }
}

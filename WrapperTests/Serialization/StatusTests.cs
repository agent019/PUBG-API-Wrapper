using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PUBGAPIWrapper.Models;
using System;

namespace WrapperTests.Serialization
{
    [TestClass]
    public class StatusTests
    {
        public static string Time = new DateTime(2000, 1, 1).ToString();

        public static StatusDTO SampleStatus = new StatusDTO()
        {
            Data = new StatusData()
            {
                Id = "123-ABC",
                Type = "Type"
            }
        };

        [TestMethod, TestCategory("Unit")]
        public void ItDeserializesCorrectly()
        {
            string serialized = JsonConvert.SerializeObject(SampleStatus);

            Status result = Status.Deserialize(serialized);
            
            Assert.AreEqual("123-ABC", result.Id);
            Assert.AreEqual("Type", result.Type);
        }
    }
}

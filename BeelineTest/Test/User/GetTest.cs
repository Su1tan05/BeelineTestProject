using System;
using System.Linq;
using System.Net;
using BeelineTest.ApiUtils;
using BeelineTest.Utils;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;

namespace BeelineTest.Test.User
{
    public class GetTest
    {
        private int maxUserIdValue = 12;

        [Test, Description("C000001 Get list of users")]
        public void TestGetListOfUsers()
        {
            int pageId = 2;
            LogUtils.Info("1. Send get request to https://reqres.in/api/users?page=2");
            JsonSchema schema = JsonSchema.Parse(@File.ReadAllText("Resources\\GetListOfUsersSchema.json"));
            JObject response = UserApi.GetUsersWithEntryParam($"page={pageId}");
            var data = response["data"].ToArray<object>();
            Assert.AreEqual(HttpStatusCode.OK, UserApi.GetStatusCode(), "Invalid status code");
            Assert.True(response.IsValid(schema), "Invalid json schema");
            Assert.True(data.Length > 0, "Empty data");
        }

        [Test, Description("C000002 GET single user")]
        public void TestGetSingleUser()
        {
            int userId = RandomUtil.GetRandomNumber(maxUserIdValue);
            LogUtils.Info($"1. Send get request to https://reqres.in/api/users/{userId}");
            JsonSchema schema = JsonSchema.Parse(@File.ReadAllText("Resources\\GetSingleUserSchema.json"));
            JObject response = UserApi.GetUsersPerId(userId);
            var data = response["data"].ToObject<object>();
            Assert.AreEqual(HttpStatusCode.OK, UserApi.GetStatusCode(), "Invalid status code");
            Assert.True(response.IsValid(schema), "Invalid json schema");
            Assert.True(!data.Equals(0), "Empty data");
        }

        [Test, Description("C000003 GET non-existent user")]
        public void TestGETNonExistentUser()
        {
            int userId = maxUserIdValue + RandomUtil.GetRandomNumber(maxUserIdValue);
            JObject response = UserApi.GetUsersPerId(userId);
            LogUtils.Info($"1. Send get request to https://reqres.in/api/users/{userId}");
            Assert.AreEqual(HttpStatusCode.NotFound, UserApi.GetStatusCode(), "Invalid status code");
            Assert.IsEmpty(response, "Non-empty data");
        }

        [Test, Description("C000007 GET list of users with delay")]
        public void TestGetListOfUsersWithDelay()
        {
            int delayTime = 3;
            LogUtils.Info($"1. Send get request to https://reqres.in/api/users?delay={delayTime}");
            JsonSchema schema = JsonSchema.Parse(@File.ReadAllText("Resources\\GetListOfUsersSchema.json"));
            int firstTime = DateTime.Now.Second;
            JObject response = UserApi.GetUsersWithEntryParam($"delay={delayTime}");
            int secendTime = DateTime.Now.Second;
            Assert.AreEqual(delayTime, secendTime - firstTime, "Invalid delay time");
            var data = response["data"].ToArray<object>();
            Assert.AreEqual(HttpStatusCode.OK, UserApi.GetStatusCode(), "Invalid status code");
            Assert.True(response.IsValid(schema), "Invalid json schema");
            Assert.True(data.Length > 0, "Empty data");
        }
    }
}

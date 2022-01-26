using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using BeelineTest.ApiUtils;
using BeelineTest.Utils;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json.Schema;

namespace BeelineTest.Test.Resourse
{
    public class GetTest
    {
        private int maxResourseId = 12;

        [Test, Description("C000004 GET list of resources")]
        public void TestGETListOfResources()
        {
            JObject response = ResourcesApi.GetResources();
            JsonSchema schema = JsonSchema.Parse(@File.ReadAllText("Resources\\GETListOfResourcesSchema.json"));
            var data = response["data"].ToArray<object>();
            Assert.AreEqual(HttpStatusCode.NotFound, ResourcesApi.GetStatusCode(), "Invalid status code");
            Assert.True(response.IsValid(schema), "Invalid json schema");
            Assert.True(data.Length > 0, "Empty data");
        }

        [Test, Description("C000005 GET single resource")]
        public void TestGETSingleResources()
        {
            int resourseId = RandomUtil.GetRandomNumber(maxResourseId);
            JObject response = ResourcesApi.GetResources(resourseId);
            JsonSchema schema = JsonSchema.Parse(@File.ReadAllText("Resources\\GetSingleResourceSchema.json"));
            var data = response["data"].ToObject<object>();
            Assert.AreEqual(HttpStatusCode.NotFound, ResourcesApi.GetStatusCode(), "Invalid status code");
            Assert.True(response.IsValid(schema), "Invalid json schema");
            Assert.True(!data.Equals(0), "Empty data");
        }

        [Test, Description("C000006 GET non-existent resourse")]
        public void TestGETNonExistentResourse()
        {
            JObject response = ResourcesApi.GetResources(maxResourseId + RandomUtil.GetRandomNumber(maxResourseId));
            Assert.AreEqual(HttpStatusCode.NotFound, ResourcesApi.GetStatusCode(), "Invalid status code");
            Assert.IsEmpty(response, "Non-empty data");
        }
    }
}
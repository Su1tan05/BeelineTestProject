using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using BeelineTest.Data;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BeelineTest.ApiUtils
{
    public static class UserApi
    {
        private static RestClient client = new RestClient(DataProvider.GetConfigData().ApiUrl);

        private static RestRequest request;
        private static HttpStatusCode status;
        private const string usersPath = "/users";
        private static string content;

        public static JObject GetUsersPerId(int userId)
        {
            request = new RestRequest($"{usersPath}/{userId}", DataFormat.Json);
            IRestResponse response = client.Get(request);
            status = response.StatusCode;
            content = GetContent(response);
            return JObject.Parse(content);
        }

        public static JObject GetUsersWithEntryParam(string entryParam)
        {
            request = new RestRequest($"{usersPath}?{entryParam}", DataFormat.Json);
            IRestResponse response = client.Get(request);
            status = response.StatusCode;
            content = GetContent(response);
            return JObject.Parse(content);
        }


        public static HttpStatusCode GetStatusCode() => status;
        public static string GetContent(IRestResponse restResponse) => restResponse.Content;

    }
}

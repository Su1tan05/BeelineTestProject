using BeelineTest.Data;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BeelineTest.ApiUtils
{
    public class ResourcesApi
    {
        private static RestClient client = new RestClient(DataProvider.GetConfigData().ApiUrl);

        private static RestRequest request;
        private static HttpStatusCode status;
        private const string resourcesPath = "/unknown";
        private static string content;

        public static JObject GetResources()
        {
            request = new RestRequest(resourcesPath, DataFormat.Json);
            IRestResponse response = client.Get(request);
            status = response.StatusCode;
            content = GetContent(response);
            return JObject.Parse(content);
        }

        public static JObject GetResources(int resourceId)
        {
            request = new RestRequest($"{resourcesPath}/{resourceId}", DataFormat.Json);
            IRestResponse response = client.Get(request);
            status = response.StatusCode;
            content = GetContent(response);
            return JObject.Parse(content);
        }

        public static HttpStatusCode GetStatusCode() => status;
        public static string GetContent(IRestResponse restResponse) => restResponse.Content;
    }
}

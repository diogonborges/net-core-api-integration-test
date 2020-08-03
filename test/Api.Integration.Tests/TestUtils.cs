using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Api.Integration.Tests
{
    public static class TestUtils
    {
        public static async Task<HttpResponseMessage> SendOkRequest(HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            return response;
        }

        public static HttpRequestMessage CreateGetRequest(string url)
        {
            return CreateMessage(url, HttpMethod.Get);
        }

        private static HttpRequestMessage CreateMessage(string url, HttpMethod method, HttpContent content = null)
        {
            var httpRequestMessage = new HttpRequestMessage(method, url)
            {
                Content = content
            };

            return httpRequestMessage;
        }

        public static async Task<object> Deserialize(HttpResponseMessage response)
        {
            var stringResponseAll = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(stringResponseAll);
        }
    }
}
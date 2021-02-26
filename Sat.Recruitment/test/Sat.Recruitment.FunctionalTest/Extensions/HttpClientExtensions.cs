using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sat.Recruitment.FunctionalTest.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            try
            {
                var dataAsString = JsonConvert.SerializeObject(data);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return httpClient.PostAsync(url, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Task<HttpResponseMessage> PutJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            try
            {
                var dataAsString = JsonConvert.SerializeObject(data);
                var content = new StringContent(dataAsString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return httpClient.PutAsync(url, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.None
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
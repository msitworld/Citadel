using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Citadel.RahkaranClient.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private static readonly HttpClient HttpClient;

        static HttpRequestService()
        {
            HttpClient = new HttpClient();
        }

        public async Task<T> SendAsync<T>(string url, HttpMethod httpMethod, string body = null)
        {
            var response = await SendRequestAsync(url, httpMethod, body);

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) throw new Exception($"{response.StatusCode}: {content}");

            var result = JsonConvert.DeserializeObject(content).ToString();

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<T> SendAsync<T>(string url, HttpMethod httpMethod, object body)
        {
            return await SendAsync<T>(url, httpMethod, JsonConvert.SerializeObject(body, new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            }));
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string url, HttpMethod httpMethod, string body = null)
        {
           if (SessionContext.Current == null)
           {
               SessionContext.Authorize();

               if (SessionContext.Current != null)
               {
                   HttpClient.BaseAddress = new Uri(SessionContext.BaseAddress);

                   HttpClient.DefaultRequestHeaders.Add("Cookie", SessionContext.Current.Cookie);
               }
           }

           try
           {
               HttpResponseMessage response;
               
               bool tryAgain;

               var i = 0;

               do
               {
                   var httpRequest = new HttpRequestMessage(httpMethod, $"/{SessionContext.SgName}/{url}");

                   if (!string.IsNullOrEmpty(body))
                   {
                       httpRequest.Content = new StringContent(body, Encoding.UTF8, "application/json");
                   }

                   response = await HttpClient.SendAsync(httpRequest);

                   if (response.StatusCode != HttpStatusCode.Unauthorized)
                   {
                       tryAgain = false;
                       continue;
                   }

                   SessionContext.Authorize();

                   HttpClient.DefaultRequestHeaders.Clear();

                   HttpClient.DefaultRequestHeaders.Add("Cookie", SessionContext.Current.Cookie);

                   tryAgain = true;

                   await Task.Delay(SessionContext.Current.AuthourizeRetryDelay * 1000);

               } while (tryAgain && i++ < SessionContext.Current.AuthourizeRetryTime);

               return response;

           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message);
           }
        }
    }
}

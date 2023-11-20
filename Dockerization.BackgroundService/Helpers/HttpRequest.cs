using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dockerization.BackgroundService.Helpers
{
    public class HttpRequest
    {
        public static async Task<HttpResponseMessage> HttpPost(string url, string content)
        {
            var result = new HttpResponseMessage();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            using (var stringContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json"))
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        result = await client.PostAsync(url, stringContent);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return result;

        }

        public static async Task<HttpResponseMessage> HttpGet(string url, string accessToken)
        {
            var result = new HttpResponseMessage();

            using (var client = new HttpClient())
            {
                try
                {
                    if(String.IsNullOrEmpty(accessToken))
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                    result = await client.GetAsync(url);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUtility
{
    public class WebApiUtil
    {
        public static async Task<HttpResponseMessage> GetAsync(string baseUrl, string uri)
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.Deflate;
            }
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}

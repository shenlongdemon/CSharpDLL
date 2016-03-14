using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiUtility
{
    public class WebApiUtil
    {
        public static async Task<HttpResponseMessage> GetAsync(string url)
        {           
            HttpClient client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/*"));

            var response = await client.GetAsync(url);
            return response;
        }
        public static async Task<string> GetContentSite(string link)
        {
            HttpResponseMessage response = await GetAsync(link);
            string content = "";
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }
            return content;
        }
    }
}

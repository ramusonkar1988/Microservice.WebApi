using IPPing.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IPPing.Service
{
    public class PingService : IPingService
    {
        public async Task<PingModel> GetPingDetailsAsync()
        {
            PingModel pingModel = new PingModel();
           string  input = "https://api.github.com/orgs/ping-api";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(input),

            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                pingModel = JsonConvert.DeserializeObject<PingModel>(responseData);
            }

            return pingModel;
        }
    }
}

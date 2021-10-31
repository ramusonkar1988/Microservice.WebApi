using Newtonsoft.Json;
using ReverseDNS.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReverseDNS.Service
{
    public class RDNSService : IRDNSService
    {
        public async Task<ReverseDNSModel> GetDetails(string input = "")
        {
            if (string.IsNullOrEmpty(input)) { input = "www.google.com"; }
            ReverseDNSModel reverseDNSModel = new ReverseDNSModel();
          Root dNSData = new Root();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://whoisapi-dns-lookup-v1.p.rapidapi.com/whoisserver/DNSService?domainname="+input+"&type=A&apiKey=at_fASX5ig0UXQWkjutDpQNyy1rIJu3l&outputFormat=JSON"),
                    Headers =
                            {
                                { "x-rapidapi-host", "whoisapi-dns-lookup-v1.p.rapidapi.com" },
                                { "x-rapidapi-key", "0c648123fbmsh56045994e03d6f6p1866e0jsnb6c30fe4012c" },
                            },
                                        };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    dNSData = JsonConvert.DeserializeObject<Root>(body);
                    reverseDNSModel.DNSData = dNSData;
                }
            }
            catch (Exception ex)
            {
                reverseDNSModel.ErrorMessage = ex.Message.ToString();
            }
            return reverseDNSModel;
        }
    }
}

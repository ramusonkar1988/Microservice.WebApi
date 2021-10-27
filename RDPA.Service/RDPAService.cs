using Newtonsoft.Json;
using RDPA.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDPA.Service
{
    public class RDPAService : IRDPAService
    {
        public async Task<Root> GetDetailsAsync()
        {
            Root rootModel = new Root();
            string input = "https://rdap.arin.net/registry/ip/8.8.8.8";
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
                rootModel = JsonConvert.DeserializeObject<Root>(responseData);
            }

            var client1 = new HttpClient();
            var request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://whoisapi-dns-lookup-v1.p.rapidapi.com/whoisserver/DNSService?domainname=google.com&type=A&apiKey=undefined&outputFormat=JSON"),
                Headers =
    {
        { "x-rapidapi-host", "whoisapi-dns-lookup-v1.p.rapidapi.com" },
        { "x-rapidapi-key", "0c648123fbmsh56045994e03d6f6p1866e0jsnb6c30fe4012c" },
    },
            };
            using (var response = await client1.SendAsync(request1))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }

            return rootModel;
        }
    }
}

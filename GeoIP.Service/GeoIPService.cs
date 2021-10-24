using GeoIP.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace GeoIP.Service
{
    public class GeoIPService : IGeoIPService
    {
        /// <summary>
        ///  This method will use to get GeoIp details based on IP
        /// </summary>
        /// <param name="input">Ip Address</param>
        /// <returns></returns>
        public async Task<object> GetGeoIPDetailsAsync(string input)
        {
            object geoIpModel;
            input = "http://ip-api.com/json/24.48.0.1";
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
                geoIpModel = JsonConvert.DeserializeObject<dynamic>(responseData); 
            }

            return geoIpModel;
        }
    }
}

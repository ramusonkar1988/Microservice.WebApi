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
        public async Task<GeoIpModel> GetGeoIPDetailsAsync(string input)
        {
            if (string.IsNullOrEmpty(input)) { input = "8.8.8.8"; }
                
            GeoIpModel geoIpModel =new GeoIpModel();
            try
            {
                input = "http://ip-api.com/json/" + input;
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
                    geoIpModel = JsonConvert.DeserializeObject<GeoIpModel>(responseData);
                }
            }
            catch (Exception ex)
            {
                geoIpModel.ErrorMessage = ex.Message.ToString();
            }

            return geoIpModel;
        }
    }
}

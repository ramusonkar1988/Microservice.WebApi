using Newtonsoft.Json;
using RDPA.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDPA.Service
{
    public class RDPAService : IRDPAService
    {
        public async Task<RDPAModel> GetDetailsAsync(string input = "")
        {
            if (string.IsNullOrEmpty(input))
                input = "8.8.8.8";


            RDPAModel rootModel = new RDPAModel(); 
            try
            {
                string url = "https://rdap.arin.net/registry/ip/"+ input;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url),

                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();
                    rootModel = JsonConvert.DeserializeObject<RDPAModel>(responseData);
                }
            }
            catch (Exception ex)
            {
                rootModel.ErrorMessage = ex.Message.ToString();
            } 
            return rootModel;
        }
    }
}

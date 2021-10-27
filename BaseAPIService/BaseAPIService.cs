using BaseAPI.Model;
using GeoIP.Model;
using IPPing.Model;
using Newtonsoft.Json;
using RDPA.Model;
using ReverseDNS.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseAPI.Service
{
    public class BaseAPIService : IBaseAPIService
    {
        private static string Url = "https://localhost:44382/";

        private static string GeoIp = "gateway/geoip";
        private static string IPPing = "gateway/ipping";
        private static string RDPA = "gateway/rdpa";
        private static string RDNS = "gateway/rdns";
        string strMessage = string.Empty;
        public async Task<BaseAPIModel>  GetAPIDetails(string input = "")
        {
            BaseAPIModel baseAPIModel = new BaseAPIModel();
            try
            {
                var geoIpModel  = Task.Factory.StartNew(() => GetGeoIPDetails(input));
                var pingModel =  Task.Factory.StartNew(() => GetPingDetails(input));
                var rDPAModel = Task.Factory.StartNew(() => GetRDPADetails(input));
                var  reverseDNSModel = Task.Factory.StartNew(() => GetReverseDNSDetails(input));

                // Wait for all task completion
                Task.WaitAll(geoIpModel, pingModel, rDPAModel, reverseDNSModel);

                baseAPIModel.GeoIpModel = await geoIpModel.Result;
                baseAPIModel.PingModel = await pingModel.Result;
                baseAPIModel.RDPAModel = await rDPAModel.Result;
                baseAPIModel.ReverseDNSModel = await reverseDNSModel.Result;

            }
            catch (Exception ex)
            {

                strMessage = ex.Message.ToString();
            }
            return baseAPIModel;
        }

        private async Task<GeoIpModel> GetGeoIPDetails(string input)
        {
            GeoIpModel geoIpModel = new GeoIpModel();
            try
            { 
                input = Url+ GeoIp;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(input),

                };
                using (var response =await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();
                    geoIpModel = JsonConvert.DeserializeObject<GeoIpModel>(responseData);
                }
            }
            catch (Exception ex)
            {

                strMessage = ex.Message.ToString();
            }

            return geoIpModel;
        }

        private async Task<PingModel> GetPingDetails(string input)
        {
            PingModel pingModel = new PingModel();
            try
            {
                input = Url + IPPing;
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
            }
            catch (Exception ex)
            {

                strMessage = ex.Message.ToString();
            }
            return pingModel;
        }
        private async Task<Root> GetRDPADetails(string input)
        {
            Root root = new Root();
            try
            {
                input = Url + RDPA;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(input),

                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseData =await response.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<Root>(responseData);
                }
            }
            catch (Exception ex)
            {

                strMessage = ex.Message.ToString();
            }
            return root;
        }
        private async Task<ReverseDNSModel> GetReverseDNSDetails(string input)
        {
            ReverseDNSModel reverseDNSModel = new ReverseDNSModel();
            try
            {
                input = Url + RDNS;
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(input),

                };
                using (var response =await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();
                    reverseDNSModel = JsonConvert.DeserializeObject<ReverseDNSModel>(responseData);
                }
            }
            catch (Exception ex)
            {

                strMessage = ex.Message.ToString();
            }
            return reverseDNSModel;
        }
    }
}

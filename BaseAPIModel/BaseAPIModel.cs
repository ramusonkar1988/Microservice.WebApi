using GeoIP.Model;
using IPPing.Model;
using RDPA.Model;
using ReverseDNS.Model;
using System;

namespace BaseAPI.Model
{
    public class BaseAPIModel
    {
        public GeoIpModel GeoIpModel { get; set; }
        public ReverseDNSModel ReverseDNSModel { get; set; }
        public RDPAModel RDPAModel { get; set; }
        public PingModel PingModel { get; set; }
        public string ErrorMessage { get; set; }

    }
}

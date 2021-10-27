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
        public Root RDPAModel { get; set; }
        public PingModel PingModel { get; set; }

    }
}

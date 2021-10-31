using System;
using System.Collections.Generic;

namespace ReverseDNS.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Audit
    {
        public string createdDate { get; set; }
        public string updatedDate { get; set; }
    }

    public class DnsRecord
    {
        public int type { get; set; }
        public string dnsType { get; set; }
        public string name { get; set; }
        public int ttl { get; set; }
        public int rRsetType { get; set; }
        public string rawText { get; set; }
        public string address { get; set; }
    }

    public class DNSData
    {
        public string domainName { get; set; }
        public List<int> types { get; set; }
        public string dnsTypes { get; set; }
        public Audit audit { get; set; }
        public List<DnsRecord> dnsRecords { get; set; }
    }

    public class Root
    {
        public DNSData DNSData { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ReverseDNSModel {
        public Root DNSData { get; set; }
        public string ErrorMessage { get; set; }
    }




}

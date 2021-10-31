using System;
using System.Collections.Generic;

namespace RDPA.Model
{ 
    public class Link
    {
        public string value { get; set; }
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Notice
    {
        public string title { get; set; }
        public List<string> description { get; set; }
        public List<Link> links { get; set; }
    }

    public class Event
    {
        public string eventAction { get; set; }
        public DateTime eventDate { get; set; }
    }

    public class Remark
    {
        public string title { get; set; }
        public List<string> description { get; set; }
    }

    public class Entity 
    {
        public string handle { get; set; }
        public List<object> vcardArray { get; set; }
        public List<string> roles { get; set; }
        public List<Remark> remarks { get; set; }
        public List<Link> links { get; set; }
        public List<Event> events { get; set; }
        public string port43 { get; set; }
        public string objectClassName { get; set; }
        public List<string> status { get; set; }
        public List<Entity> entities { get; set; }
    }

    public class Cidr0Cidrs
    {
        public string v4prefix { get; set; }
        public int length { get; set; }
    }

    public class RDPAModel
    {
        public List<string> rdapConformance { get; set; }
        public List<Notice> notices { get; set; }
        public string handle { get; set; }
        public string startAddress { get; set; }
        public string endAddress { get; set; }
        public string ipVersion { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string parentHandle { get; set; }
        public List<Event> events { get; set; }
        public List<Link> links { get; set; }
        public List<Entity> entities { get; set; }
        public string port43 { get; set; }
        public List<string> status { get; set; }
        public string objectClassName { get; set; }
        public List<Cidr0Cidrs> cidr0_cidrs { get; set; }
        public List<object> arin_originas0_originautnums { get; set; }
        public string ErrorMessage { get; set; }
    }

    //public class RDPAModel { 
    
    //    public Root RDPAData { get; set; }
    //}
}

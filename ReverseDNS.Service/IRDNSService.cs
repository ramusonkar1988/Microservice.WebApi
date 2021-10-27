using ReverseDNS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReverseDNS.Service
{
   public interface IRDNSService
    {
        Task<ReverseDNSModel> GetDetails(string input = "");
    }
}

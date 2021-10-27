using IPPing.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IPPing.Service
{
    public   interface IPingService
    {
        Task<PingModel> GetPingDetailsAsync();
    }
}

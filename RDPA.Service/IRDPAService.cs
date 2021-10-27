using RDPA.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RDPA.Service
{
   public interface IRDPAService
    {
        Task<Root> GetDetailsAsync();
    }
}

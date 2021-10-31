using ReverseDNS.Model;
using System.Threading.Tasks;

namespace ReverseDNS.Service
{
    public interface IRDNSService
    {
        Task<ReverseDNSModel> GetDetails(string input = "");
    }
}

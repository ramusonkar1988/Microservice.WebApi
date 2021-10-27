using GeoIP.Model;
using System.Threading.Tasks;

namespace GeoIP.Service
{
    public interface IGeoIPService
    {
        Task<GeoIpModel> GetGeoIPDetailsAsync(string input = "");
    }
}

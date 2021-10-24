using GeoIP.Model;
using System.Threading.Tasks;

namespace GeoIP.Service
{
    public interface IGeoIPService
    {
        Task<object> GetGeoIPDetailsAsync(string input = "");
    }
}

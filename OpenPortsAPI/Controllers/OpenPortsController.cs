using Microsoft.AspNetCore.Mvc;

namespace OpenPortsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenPortsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "OpenPorts";
        }
    }
}

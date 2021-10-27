using IPPing.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPPingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPPingController : ControllerBase
    {
        private readonly IPingService pingService;
        public IPPingController(IPingService _pingService)
        {
            pingService = _pingService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var result = await pingService.GetPingDetailsAsync();
            return Ok(result);
        }
    }
}

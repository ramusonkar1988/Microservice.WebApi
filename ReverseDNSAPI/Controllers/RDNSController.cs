using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReverseDNS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReverseDNSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RDNSController : ControllerBase
    {
        private readonly IRDNSService rDNSService;
        public RDNSController(IRDNSService _rDNSService)
        {
            rDNSService = _rDNSService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string input="")
        {
            var result = await rDNSService.GetDetails(input);
            return Ok(result);
        }
    }
}

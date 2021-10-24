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
        [HttpGet]
        public string Get()
        {
            return "IP Ping test";
        }
    }
}

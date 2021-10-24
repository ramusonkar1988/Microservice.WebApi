using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDPAAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RDPAController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "RDPA test";
        }
    }
}

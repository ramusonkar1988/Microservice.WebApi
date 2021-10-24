using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainstatusController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Domainstatus test";
        }
    }
}

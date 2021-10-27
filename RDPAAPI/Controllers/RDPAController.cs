using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDPA.Service;
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
        private readonly IRDPAService iRDPAService;
        public RDPAController(IRDPAService _rDPAService)
        {
            iRDPAService = _rDPAService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await iRDPAService.GetDetailsAsync();
            return Ok(result);
        }
    }
}

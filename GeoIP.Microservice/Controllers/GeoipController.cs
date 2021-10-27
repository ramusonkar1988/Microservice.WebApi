using GeoIP.Model;
using GeoIP.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoIP.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoipController : ControllerBase
    {
        private readonly IGeoIPService geoIPService;
        public GeoipController(IGeoIPService _geoIPService)
        {
            geoIPService = _geoIPService;
        }
        // GET: GeoIPController
        [HttpGet]
        public async Task<IActionResult> Get(string input)
        {
            input = "134.201.250.155";
            var result= await geoIPService.GetGeoIPDetailsAsync(input);
            return Ok(result);
        }

    }
}

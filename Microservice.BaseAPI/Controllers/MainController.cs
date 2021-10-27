using BaseAPI.Model;
using BaseAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Microservice.BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IBaseAPIService baseAPIService;
        public MainController(IBaseAPIService _baseAPIService)
        {
            baseAPIService = _baseAPIService;
        }

        [HttpGet]
        public async Task<BaseAPIModel> GetDetails(string input)
        {
            BaseAPIModel baseAPIModel = new BaseAPIModel();
            try
            {
                baseAPIModel = await baseAPIService.GetAPIDetails(input);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return baseAPIModel;
        }
        

    }
}

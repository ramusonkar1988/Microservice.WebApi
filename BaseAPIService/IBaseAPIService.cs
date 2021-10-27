using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BaseAPI.Model;

namespace BaseAPI.Service
{
  public  interface IBaseAPIService
    {
      Task<BaseAPIModel> GetAPIDetails(string input = "");
    }
}

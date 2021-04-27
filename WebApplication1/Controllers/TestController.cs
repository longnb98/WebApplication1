using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public Task<string> GetString()
        {
            return Task.FromResult<string>("test1234");
        }

        [HttpPost]
        [Route("long")]
        public Task<object> PostString([FromBody] object body)
        {
            return Task.FromResult<object>(true);
        }

        [HttpGet]
        [Route("long")]
        public Task<double> GetNumb()
        {
            return Task.FromResult<double>(95884594);
        }
    }
}
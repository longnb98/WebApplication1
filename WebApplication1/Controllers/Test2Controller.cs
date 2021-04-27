using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        // GET: api/Test2
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test2/5
        [HttpGet]
        [Route("{id?}")]
        public int Get(int id)
        {
            return id;
        }

        // POST: api/Test2
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return value;
        }

        // PUT: api/Test2/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            var _value = value;
            _value = "password";
            return $"Updated id = {id} : {value} => {_value}";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Deleted id = {id}";
        }
    }
}

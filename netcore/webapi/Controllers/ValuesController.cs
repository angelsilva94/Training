using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers {
    [Route ("api/[controller]")]
    public class ValuesController : Controller {
        // GET api/values
        [HttpGet]
        public IActionResult Get () {
            var msg = "Hola Mundo desde Net Core Web Api" + "sdasd";
            return Ok (msg);
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public string Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post ([FromQueryAttribute] string value) {
            return "The string is: " + value;

        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}
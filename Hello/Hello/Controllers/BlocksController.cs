using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hello.Controllers
{
    public class BlocksController : ApiController
    {
        // GET: api/Blocks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Blocks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Blocks
        public string Post([FromBody]string value)
        {
            return "hola";
        }

        // PUT: api/Blocks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Blocks/5
        public void Delete(int id)
        {
        }
    }
}

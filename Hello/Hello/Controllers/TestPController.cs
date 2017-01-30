using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hello.Controllers
{
    public class Student {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TestPController : ApiController
    {
        // GET: api/TestP
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestP/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TestP
        public Student Post(Student student) {
            Student aux = student;
            aux.Id = 234;
            aux.Name = "angel";

            return aux;
        }

        // PUT: api/TestP/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestP/5
        public void Delete(int id)
        {
        }
    }
}

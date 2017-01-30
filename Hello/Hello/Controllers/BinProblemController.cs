using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BinPacking;
using Hello.Models;
namespace Hello.Controllers
{
    public class BinProblemController : ApiController
    {
        // GET: api/BinProblem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BinProblem/5
        public HttpResponseMessage Get(int a, int b, int c) {
            Random random = new Random();
            int[] brown = new int[a];
            int[] clear = new int[b];
            int[] green = new int[c];
            for (int i = 0; i < a; i++) {
                brown[i] = random.Next(a);
                clear[i] = random.Next(b);
                green[i] = random.Next(c);
            }
            Rec rec = new Rec(brown, clear, green);
            ResponseBinModel responseBinModel = new ResponseBinModel();
            responseBinModel.order = new char[3];
            responseBinModel.order = rec.bottles;
            responseBinModel.res = rec.getM();
            return Request.CreateResponse(HttpStatusCode.OK,responseBinModel);
        }

        // POST: api/BinProblem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BinProblem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BinProblem/5
        public void Delete(int id)
        {
        }
    }
}

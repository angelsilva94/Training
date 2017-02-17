using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using BinPacking;
using Hello.Models;
using Models;
using Autofac;
using Libraries;

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
        public HttpResponseMessage Get(string a, string b, string c) {

            //if(!string.IsNullOrWhiteSpace(Request.que))
            if(a!=null && b !=null && c != null) { 
                try {
                    Random random = new Random();
                    int[] brown = new int[int.Parse(a)];
                    int[] clear = new int[int.Parse(b)];
                    int[] green = new int[int.Parse(a)];
                    ValidatorBin val = new ValidatorBin { number = random.Next(-9999, 99999) };
                    ErrorDispose errorDispose = new ErrorDispose();
                    if (val.Val(out errorDispose)) {
                        for (int i = 0; i < int.Parse(a); i++) {
                            brown[i] = random.Next(int.Parse(a));
                            clear[i] = random.Next(int.Parse(b));
                            green[i] = random.Next(int.Parse(c));
                        }

                        Rec rec = new Rec(brown, clear, green);

                        ResponseBinModel responseBinModel = new ResponseBinModel();
                        responseBinModel.order = new char[3];
                        responseBinModel.order = rec.bottles;//container.Resolve<Rec>().bottles;
                        responseBinModel.res = rec.getM();//container.Resolve<Rec>().getM();

                        return Request.CreateResponse(HttpStatusCode.OK, responseBinModel);
                    } else {
                        return Request.CreateResponse(HttpStatusCode.OK, errorDispose);
                    }

                } catch (System.FormatException) {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, new ErrorDispose { ErrorCode=1001,ErrorDesc="TUS PARAMETROS DEBEN DE SER NUMEROS INTENTALO DE NUEVO"});
                }
                

            } else {
                //MOQ
                //RHINOMOCK
                return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorDispose { ErrorCode = 100, ErrorDesc = "TUS PARAMETROS SON NULOS " });
            }
                

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

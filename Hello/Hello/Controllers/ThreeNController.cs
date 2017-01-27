using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using threeN.Process;
using threeN.Validator;
using Hello.Models;

namespace Hello.Controllers
{
    public class ThreeNController : ApiController
    {


        /*public ProcessInput Get(int x,int y) {


            return new ProcessInput(x,y);
        }*/
        // GET: api/ThreeN
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ThreeN/5
        /*public List<string> Get(int a,int b)
        {
            List<string> test = new List<string>();
            test.Add("primer numero es: "+a);
            test.Add("el segundo numero es: "+b);
            test.Add("la suma es: " + (a + b));

            return test;
        }*/


        //actionresult
        /* public /*ResponseModel List<string> Get(int x,int y) {
            List<string> l = new List<string>();
            ResponseModel responseModel = new ResponseModel {
                i = x,
                j = y };
            Validator val = new Validator(x, y);
            ErrorDispose e;
            if (val.Val(out e)) {
                ProcessInput ps = new ProcessInput(val.i, val.j);
                int count = ps.ProcessNumber();
                l.Add(val.i + " " + val.j + " " + count);
                foreach (var m in ps.result) {
                   l.Add(ps.result.ToString());

                }


                //return rs;
                return l;
            } else {
                l.Add("There was an error please check your parameters, the error code is : " + e.ErrorCode + " " + e.ErrorDesc);
                return l;
            }

        }*/
        public ResponseModel Get(int x, int y) {
            List<string> l = new List<string>();
            ResponseModel responseModel = new ResponseModel {
                i = x,
                j = y
            };
            Validator val = new Validator(x, y);
            ErrorDispose e;
            if (val.Val(out e)) {
                ProcessInput ps = new ProcessInput(val.i, val.j);
                int count = ps.ProcessNumber();
                l.Add(val.i + " " + val.j + " " + count);
                foreach (var m in ps.result) {
                    l.Add(ps.result.ToString());

                }


                return responseModel;
            } else {
                l.Add("There was an error please check your parameters, the error code is : " + e.ErrorCode + " " + e.ErrorDesc);
                return responseModel;
            }


        }


        // POST: api/ThreeN
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ThreeN/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ThreeN/5
        public void Delete(int id)
        {
        }
    }
}

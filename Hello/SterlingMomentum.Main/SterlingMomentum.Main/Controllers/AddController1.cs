﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SterlingMomentum.Main.Controllers {
    [RoutePrefix("Add")]
    public class AddController1 : ApiController {
        // GET api/<controller>
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("Get")]
        public string Get(int id) {

            return ""+id;
        }

        
    }
}
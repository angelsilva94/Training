using LoginRegister.Models;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Controllers
{
    [RoutePrefix("authentication")]
    public class AuthenticationController : ApiController
    {
        [Route("login")]
        public IHttpActionResult PostCredential(login loginInfo) {
            var check = new CheckUser();
            if (!check.login(loginInfo.name,loginInfo.pwd)) {
                return NotFound();
            }
            return Ok(check.idUser(loginInfo.name));
        }
    }
}

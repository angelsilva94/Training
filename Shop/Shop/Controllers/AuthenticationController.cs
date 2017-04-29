using LoginRegister.Models;
using Shop.Models;
using System.Web.Http;

namespace Shop.Controllers {

    [RoutePrefix("authentication")]
    public class AuthenticationController : ApiController {

        [Route("login")]
        public IHttpActionResult PostCredential(login loginInfo) {
            var check = new CheckUser();
            if (!check.login(loginInfo.name, loginInfo.pwd)) {
                return NotFound();
            }
            return Ok(check.idUser(loginInfo.name));
        }
    }
}
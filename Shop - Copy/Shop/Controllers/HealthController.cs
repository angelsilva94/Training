using System.Web.Http;

namespace Shop.Controllers {

    [RoutePrefix("health")]
    public class HealthController : ApiController {

        [Route("check")]
        public IHttpActionResult Get(bool deep = false) {
            return Ok("Everything is OK");
        }
    }
}
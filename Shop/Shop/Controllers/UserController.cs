using LoginRegister.Models;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using Shop.Models.DTO;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    [RoutePrefix("users")]
    public class UserController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/User
        //[Authentication]
        [Route("normal"), Authentication]
        public IQueryable<User> GetUserModels() {
            return db.User;
        }

        // GET: api/User
        //[Authentication]
        [Route("api/getUser"), Authentication]
        public IQueryable<UserDTO> GetUser() {
            var user = from x in db.User
                       select new UserDTO() {
                           UserId = x.UserId,
                           username = x.username,
                           password = x.password,
                           name = x.name,
                           lastName = x.lastName,
                           surname = x.surname,
                           age = x.age,
                           email = x.email,
                           regDate = x.regDate,
                           userType = x.userMode,
                           userInfo =
                               new UserInfoDTO {
                                   adress = x.UserInfo.adress,
                                   city = x.UserInfo.city,
                                   zip = x.UserInfo.zip,
                                   country = x.UserInfo.country,
                                   phone = x.UserInfo.phone,
                               }
                               //x.UserInfo.adress,
                               //x.UserInfo.city,
                               //x.UserInfo.zip,
                               //x.UserInfo.country,
                               //x.UserInfo.phone,
                       };
            //string hola = "adsfdfa";
            //bool xyz= hola.Check();

            return user;
        }

        // GET: api/User/5
        [ResponseType(typeof(User)),Authentication,Route("api/getUser")]
        //[Authentication]
        public async Task<IHttpActionResult> GetUserModel(int id) {
            User userModel = await db.User.FindAsync(id);
            if (userModel == null) {
                return NotFound();
            }

            return Ok(userModel);
        }

        //[Authentication]
        //public HttpResponseMessage Get(string usr) {
        //    return Request.CreateResponse(HttpStatusCode.OK, Thread.CurrentPrincipal.Identity.Name);
        //}

        // PUT: api/User/5
        [Authentication]
        [ResponseType(typeof(void)),Route("api/putUser"),Authentication]
        public async Task<IHttpActionResult> PutUserModel([FromBody]ModifyUserModel modifyUserModel, [FromUri]int id) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //if (id != userModel.username)
            //{
            //    return BadRequest();
            //}
            var user = db.User.Find(id);
            if (user.password == modifyUserModel.curPassword) {
                user.password = modifyUserModel.newPassword;
            } else {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }

            //db.Entry(modifyUserModel).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!UserModelExists(modifyUserModel.username)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/User
        //[Route("api/postUser")]
        [ResponseType(typeof(User)), Route("api/postUser",Name = "postUser")]
        public async Task<IHttpActionResult> PostUserModel(User userModel) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.User.Add(userModel);

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (UserModelExists(userModel.username)) {
                    return Conflict();
                } else {
                    throw;
                }
            }

            return CreatedAtRoute("postUser", new { id = userModel.username }, userModel);
        }

        //// DELETE: api/User/5
        //[ResponseType(typeof(UserModel))]
        //public async Task<IHttpActionResult> DeleteUserModel(string id)
        //{
        //    UserModel userModel = await db.UserModels.FindAsync(id);
        //    if (userModel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserModels.Remove(userModel);
        //    await db.SaveChangesAsync();

        //    return Ok(userModel);
        //}

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserModelExists(string usr) {
            return db.User.Count(e => e.username == usr) > 0;
        }
    }
}
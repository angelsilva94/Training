﻿using LoginRegister.Models;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    [RoutePrefix("users")]
    public class UserController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/User
        //[Authentication]
        //[Route("normal"), Authentication]
        //public IQueryable<User> GetUserModels() {
        //    return db.User;
        //}

        // GET: api/User
        //[Authentication]
        [Route("")]
        public async Task<HttpResponseMessage> GetUser(int _page, int _perPage) {
            var total = db.User.Count();
            var user = await db.User.Select(x => new {
                UserId = x.UserId,
                username = x.username,
                password = x.password,
                name = x.name,
                lastName = x.lastName,
                surname = x.surname,
                age = x.age,
                email = x.email,
                regDate = x.regDate,
                userMode = x.userMode,
                userInfo = new {
                    adress = x.UserInfo.adress,
                    city = x.UserInfo.city,
                    zip = x.UserInfo.zip,
                    country = x.UserInfo.country,
                    phone = x.UserInfo.phone
                }
            }).OrderBy(x=>x.UserId).Skip((_page-1) * _perPage).Take(_perPage).ToListAsync();
            var response = Request.CreateResponse(HttpStatusCode.OK, user);
            response.Headers.Add("X-Total-Count", db.User.Count().ToString());
            return response;
        }

        [Route("")]
        public async Task<IHttpActionResult> GetUser() {
            //var user = from x in db.User
            //           select new UserDTO() {
            //               UserId = x.UserId,
            //               username = x.username,
            //               password = x.password,
            //               name = x.name,
            //               lastName = x.lastName,
            //               surname = x.surname,
            //               age = x.age,
            //               email = x.email,
            //               regDate = x.regDate,
            //               userMode = x.userMode,
            //               userInfo =
            //                   new UserInfoDTO {
            //                       adress = x.UserInfo.adress,
            //                       city = x.UserInfo.city,
            //                       zip = x.UserInfo.zip,
            //                       country = x.UserInfo.country,
            //                       phone = x.UserInfo.phone,
            //                   }
            //                   //x.UserInfo.adress,
            //                   //x.UserInfo.city,
            //                   //x.UserInfo.zip,
            //                   //x.UserInfo.country,
            //                   //x.UserInfo.phone,
            //           };
            var user = await db.User.Select(x => new UserDTO {
                UserId = x.UserId,
                username = x.username,
                password = x.password,
                name = x.name,
                lastName = x.lastName,
                surname = x.surname,
                age = x.age,
                email = x.email,
                regDate = x.regDate,
                userMode = x.userMode,
                userInfo = new UserInfoDTO {
                    adress = x.UserInfo.adress,
                    city = x.UserInfo.city,
                    zip = x.UserInfo.zip,
                    country = x.UserInfo.country,
                    phone = x.UserInfo.phone,
                }
            }).ToListAsync();
            //string hola = "adsfdfa";
            //bool xyz= hola.Check();

            return Ok(user);
        }

        // GET: api/User/5
        [ResponseType(typeof(User)), Route("{id}")]
        //[Authentication]
        public async Task<IHttpActionResult> GetUserModel(int id) {
            //IQueryable<User> temp = db.User.Where(x => x.UserId == id).ToList<User>().AsQueryable();

            //var dto = new UserDTO {
            //    UserId= temp.Select(x=>x.UserId).Single(),
            //    age = temp.Select(x => x.age).Single(),
            //    username = temp.Select(x => x.username).Single(),
            //    name = temp.Select(x => x.name).Single(),
            //    password = temp.Select(x => x.password).Single(),
            //    email = temp.Select(x => x.email).Single(),
            //    lastName = temp.Select(x => x.lastName).Single(),
            //    regDate = temp.Select(x => x.regDate).Single(),
            //    surname= temp.Select(x => x.surname).Single(),
            //    userMode= temp.Select(x => x.userMode).Single(),
            //    userInfo = new UserInfoDTO {
            //        adress = temp.Select(x => x.UserInfo.adress).Single(),
            //        city = temp.Select(x => x.UserInfo.city).Single(),
            //        country = temp.Select(x => x.UserInfo.country).Single(),
            //        phone = temp.Select(x => x.UserInfo.phone).Single(),
            //        zip= temp.Select(x => x.UserInfo.zip).Single()
            //    }

            //};

            //IQueryable<User> aux =  db.User.Where(x => x.UserId == id);

            //var user = new UserDTO {
            //    UserId = aux.Select(x => x.UserId).FirstOrDefault(),

            //};

            //MORE EXPLICIT WAY OF INCLUIDING RELATIONSHIPS
            //var user = db.User.Include("UserInfo").Where(a => a.UserId == id).Select(x =>
            //  new UserDTO {
            //      UserId = x.UserId,
            //      username = x.username,
            //      password = x.password,
            //      name = x.name,
            //      lastName = x.lastName,
            //      surname = x.surname,
            //      age = x.age,
            //      email = x.email,
            //      regDate = x.regDate,
            //      userMode = x.userMode,
            //      userInfo = new UserInfoDTO {
            //          adress = x.UserInfo.adress,
            //          city = x.UserInfo.city,
            //          zip = x.UserInfo.zip,
            //          country = x.UserInfo.country,
            //          phone = x.UserInfo.phone
            //      }
            //  });

            //EAGER LOADING WITH LINQ METHOD SYNTAX "The right way"
            var user = await db.User.AsNoTracking().Select(x => new {
                UserId = x.UserId,
                username = x.username,
                password = x.password,
                name = x.name,
                lastName = x.lastName,
                surname = x.surname,
                age = x.age,
                email = x.email,
                regDate = x.regDate,
                userMode = x.userMode,
                userInfo = new {
                    adress = x.UserInfo.adress,
                    city = x.UserInfo.city,
                    zip = x.UserInfo.zip,
                    country = x.UserInfo.country,
                    phone = x.UserInfo.phone
                }
            }).SingleOrDefaultAsync(x => x.UserId == id);
            //var user = await db.User.Where(x => x.UserId == id).Select(x=> new {
            //    UserId = x.UserId,
            //    username = x.username,
            //    password = x.password,
            //    name = x.name,
            //    lastName = x.lastName,
            //    surname = x.surname,
            //    age = x.age,
            //    email = x.email,
            //    regDate = x.regDate,
            //    userMode = x.userMode,
            //    userInfo = new {
            //        adress = x.UserInfo.adress,
            //        city = x.UserInfo.city,
            //        zip = x.UserInfo.zip,
            //        country = x.UserInfo.country,
            //        phone = x.UserInfo.phone
            //    }

            //}).SingleOrDefaultAsync();
            if (user == null) {
                return NotFound();
            }

            //var aux = new UserDTO {
            //    UserId = test.Select(x=>x.UserId).FirstOrDefault()
            //};

            //EAGER LOADING WITH QUERY SYNTAX
            //var user = from x in db.User
            //           where x.UserId == id
            //           select new UserDTO() {
            //               UserId = x.UserId,
            //               username = x.username,
            //               password = x.password,
            //               name = x.name,
            //               lastName = x.lastName,
            //               surname = x.surname,
            //               age = x.age,
            //               email = x.email,
            //               regDate = x.regDate,
            //               userMode = x.userMode,
            //               userInfo =
            //                   new UserInfoDTO {
            //                       adress = x.UserInfo.adress,
            //                       city = x.UserInfo.city,
            //                       zip = x.UserInfo.zip,
            //                       country = x.UserInfo.country,
            //                       phone = x.UserInfo.phone,
            //                   }
            //                   //x.UserInfo.adress,
            //                   //x.UserInfo.city,
            //                   //x.UserInfo.zip,
            //                   //x.UserInfo.country,
            //                   //x.UserInfo.phone,
            //           };

            return Ok(user);
        }

        //[Authentication]
        //public HttpResponseMessage Get(string usr) {
        //    return Request.CreateResponse(HttpStatusCode.OK, Thread.CurrentPrincipal.Identity.Name);
        //}

        // PUT: api/User/5
        [Authentication]
        [ResponseType(typeof(void)), Route("{id}")]
        public async Task<IHttpActionResult> PutUserModel([FromBody]ModifyUserModel modifyUserModel, int id) {
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
        [ResponseType(typeof(User)), Route("api/User", Name = "postUser")]
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LoginRegister.Models;
using System.Threading;

namespace LoginRegister.Controllers
{
    public class UserController : ApiController
    {
        private UserDBContext db = new UserDBContext();

        // GET: api/User
        [Authentication]
        public IQueryable<UserModel> GetUserModels() {
            return db.UserModels;
        }

        //// GET: api/User/5
        //[ResponseType(typeof(UserModel))]
        //[Authentication]
        //public async Task<IHttpActionResult> GetUserModel(string id)
        //{
        //    UserModel userModel = await db.UserModels.FindAsync(id);
        //    if (userModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userModel);
        //}
        [Authentication]
        public HttpResponseMessage Get(string usr) {
            return Request.CreateResponse(HttpStatusCode.OK, Thread.CurrentPrincipal.Identity.Name);
        }



        // PUT: api/User/5
        [Authentication]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserModel(ModifyUserModel modifyUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != userModel.username)
            //{
            //    return BadRequest();
            //}
            var user = db.UserModels.Find(modifyUserModel.username);
            if (user.password == modifyUserModel.curPassword) {
                user.password = modifyUserModel.newPassword;
            } else {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
            

            //db.Entry(modifyUserModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(modifyUserModel.username))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/User
        [ResponseType(typeof(UserModel))]
        public async Task<IHttpActionResult> PostUserModel(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserModels.Add(userModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserModelExists(userModel.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userModel.username }, userModel);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserModelExists(string usr)
        {
            return db.UserModels.Count(e => e.username == usr) > 0;
        }
    }
}
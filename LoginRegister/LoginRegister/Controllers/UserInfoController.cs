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

namespace LoginRegister.Controllers
{
    public class UserInfoController : ApiController
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/UserInfo
        public IQueryable<UserInfo> GetUserInfoModel()
        {
            return db.UserInfo;
        }

        // GET: api/UserInfo/5
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> GetUserInfoModel(string id)
        {
            UserInfo userInfoModel = await db.UserInfo.FindAsync(id);
            if (userInfoModel == null)
            {
                return NotFound();
            }

            return Ok(userInfoModel);
        }

        // PUT: api/UserInfo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserInfoModel(string id, UserInfo userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfoModel.username)
            {
                return BadRequest();
            }

            db.Entry(userInfoModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserInfo
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> PostUserInfoModel(UserInfo userInfoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserInfo.Add(userInfoModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserInfoModelExists(userInfoModel.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userInfoModel.username }, userInfoModel);
        }

        // DELETE: api/UserInfo/5
        [ResponseType(typeof(UserInfo))]
        public async Task<IHttpActionResult> DeleteUserInfoModel(string id)
        {
            UserInfo userInfoModel = await db.UserInfo.FindAsync(id);
            if (userInfoModel == null)
            {
                return NotFound();
            }

            db.UserInfo.Remove(userInfoModel);
            await db.SaveChangesAsync();

            return Ok(userInfoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoModelExists(string id)
        {
            return db.UserInfo.Count(e => e.username == id) > 0;
        }
    }
}
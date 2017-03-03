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
using LoginRegister.Models.DTO;

namespace LoginRegister.Controllers
{
    public class UserInfoController : ApiController
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/UserInfo
        [Authentication]
        public IQueryable<UserInfo> GetUserInfoModel()
        {
            return db.UserInfo;
        }

        // GET: api/UserInfo/5
        [ResponseType(typeof(UserInfo))]
        [Authentication]
        public async Task<IHttpActionResult> GetUserInfoModel(int id)
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
        [Authentication]
        public async Task<IHttpActionResult> PutUserInfoModel([FromUri]int id, [FromBody]UserInfoDTO userInfoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != int.Parse(db.User.Find(id).ToString()))
            {
                return NotFound();
            }
            var user = db.User.Find(id);
            user.UserInfo.adress = userInfoDTO.adress;
            user.UserInfo.city = userInfoDTO.city;
            user.UserInfo.country = userInfoDTO.country;
            user.UserInfo.phone = userInfoDTO.phone;
            user.UserInfo.zip = userInfoDTO.zip;

            db.Entry(userInfoDTO).State = EntityState.Modified;

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
        [Authentication]
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
                if (UserInfoModelExists(userInfoModel.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userInfoModel.UserId }, userInfoModel);
        }

        //// DELETE: api/UserInfo/5
        //[ResponseType(typeof(UserInfo))]
        //public async Task<IHttpActionResult> DeleteUserInfoModel(string id)
        //{
        //    UserInfo userInfoModel = await db.UserInfo.FindAsync(id);
        //    if (userInfoModel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.UserInfo.Remove(userInfoModel);
        //    await db.SaveChangesAsync();

        //    return Ok(userInfoModel);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoModelExists(int id)
        {
            return db.UserInfo.Count(e => e.UserId == id) > 0;
        }
    }
}
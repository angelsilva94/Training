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
using Shop.Models.DBModel;
using LoginRegister;
using Shop.Models.DTO;
using Shop.Extensions;

namespace Shop.Controllers
{
    [RoutePrefix("userTypes")]
    public class UserTypesController : ApiController
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/UserTypes
        [Authentication,Route("api/getUserTypes")]
        public async Task<IHttpActionResult> GetUserTypes()
        {
            var userType = await db.UserTypes.Select(x=> new {
                x.type,
                x.typeDesc,
                x.UserTypeId

            }).ToListAsync();
            return Ok(userType);
        }

        // GET: api/UserTypes/5
        [ResponseType(typeof(UserType)),Route("api/getUserTypes")]
        public async Task<IHttpActionResult> GetUserType(int id)
        {
            //var userType =  await db.UserTypes.Where(x=>x.UserTypeId == id).Select(x=>new {
            //    x.UserTypeId,
            //    x.type,
            //    x.typeDesc,
            //    //x.User
            //}).SingleOrDefaultAsync();
            var userType = await db.UserTypes.Select(x=>new {
                x.typeDesc,
                x.UserTypeId,
                x.UserId
            }).SingleOrDefaultAsync(x=>x.UserTypeId == id );
            if (userType == null)
            {
                return NotFound();
            }
            
            return Ok(userType);
        }

        // PUT: api/UserTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserType(int id, UserTypeDTO userType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userType.UserTypeId)
            {
                return BadRequest();
            }
            var userTypeDb = db.UserTypes.Find(id);
            userType.CopyProperties(userTypeDb);

            db.Entry(userTypeDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(id))
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

        // POST: api/UserTypes
        [ResponseType(typeof(UserType)),Route("api/postUserType", Name = "postUserType")]
        public async Task<IHttpActionResult> PostUserType(UserTypeDTO userType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userTypeDb = new UserType();
            userType.CopyProperties(userTypeDb);
            db.UserTypes.Add(userTypeDb);
            await db.SaveChangesAsync();

            return CreatedAtRoute("postUserType", new { id = userType.UserTypeId }, userType);
        }

        // DELETE: api/UserTypes/5
        [ResponseType(typeof(UserType))]
        public async Task<IHttpActionResult> DeleteUserType(int id)
        {
            UserType userType = await db.UserTypes.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }

            db.UserTypes.Remove(userType);
            await db.SaveChangesAsync();

            return Ok(userType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTypeExists(int id)
        {
            return db.UserTypes.Count(e => e.UserTypeId == id) > 0;
        }
    }
}
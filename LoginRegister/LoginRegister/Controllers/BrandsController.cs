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
    public class BrandsController : ApiController
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/Brands
        public IQueryable<Brand> GetBrand()
        {
            return db.Brand;
        }

        // GET: api/Brands/5
        [ResponseType(typeof(Brand))]
        public async Task<IHttpActionResult> GetBrand(int id)
        {
            Brand brand = await db.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brand.BrandId)
            {
                return BadRequest();
            }

            db.Entry(brand).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brands
        [ResponseType(typeof(Brand))]
        public async Task<IHttpActionResult> PostBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brand.Add(brand);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = brand.BrandId }, brand);
        }

        // DELETE: api/Brands/5
        [ResponseType(typeof(Brand))]
        public async Task<IHttpActionResult> DeleteBrand(int id)
        {
            Brand brand = await db.Brand.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            db.Brand.Remove(brand);
            await db.SaveChangesAsync();

            return Ok(brand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int id)
        {
            return db.Brand.Count(e => e.BrandId == id) > 0;
        }
    }
}
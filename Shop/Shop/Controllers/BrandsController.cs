using LoginRegister.Models;
using Shop.Models.DBModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {
    [RoutePrefix("brands")]
    public class BrandsController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/Brands
        [Authentication,Route("api/getBrands")]
        public IQueryable<Brand> GetBrand() {
            return db.Brand;
        }

        // GET: api/Brands/5
        [ResponseType(typeof(Brand)),Authentication,Route("api/getBrands/search")]
        public async Task<IHttpActionResult> GetBrand(int id) {
            Brand brand = await db.Brand.FindAsync(id);
            if (brand == null) {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void)), Authentication, Route("api/putBrands")]
        public async Task<IHttpActionResult> PutBrand(int id, Brand brand) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != brand.BrandId) {
                return BadRequest();
            }

            db.Entry(brand).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!BrandExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Brands
        [ResponseType(typeof(Brand)), Authentication, Route("api/postBrands",Name = "postBrands")]
        public async Task<IHttpActionResult> PostBrand(Brand brand) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Brand.Add(brand);
            await db.SaveChangesAsync();

            return CreatedAtRoute("postBrands", new { id = brand.BrandId }, brand);
        }

        //// DELETE: api/Brands/5
        //[ResponseType(typeof(Brand))]
        //public async Task<IHttpActionResult> DeleteBrand(int id) {
        //    Brand brand = await db.Brand.FindAsync(id);
        //    if (brand == null) {
        //        return NotFound();
        //    }

        //    db.Brand.Remove(brand);
        //    await db.SaveChangesAsync();

        //    return Ok(brand);
        //}

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int id) {
            return db.Brand.Count(e => e.BrandId == id) > 0;
        }
    }
}
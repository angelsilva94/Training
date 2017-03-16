using LoginRegister.Models;
using Shop.Extensions;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using Shop.Models.DTO;
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
        [Authentication, Route("api/getBrands")]
        public async Task<IHttpActionResult> GetBrand() {
            var brand = await db.Brand.Select(x => new {
                brandDesc = x.brandDesc,
                BrandId = x.BrandId,
                brandLogoUrl = x.brandLogoUrl,
                brandName = x.brandName,
                Products = x.Products.Select(y => new {
                    productDesc = y.productDesc,
                    ProductId = y.ProductId,
                    productName = y.productName,
                    productPrice = y.productPrice,
                    y.productStock,
                    y.productStatus,
                    y.productModifyDate

                }).ToList()
            }).ToListAsync();
            return Ok(brand);
        }

        // GET: api/Brands/5
        [ResponseType(typeof(Brand)), Authentication, Route("api/getBrands/search")]
        public async Task<IHttpActionResult> GetBrand(int id) {
            var brand = await db.Brand.Select(x => new {
                brandDesc = x.brandDesc,
                BrandId = x.BrandId,
                brandLogoUrl = x.brandLogoUrl,
                brandName = x.brandName,
                Products = x.Products.Select(y => new {
                    //productDesc = y.productDesc,
                    //ProductId = y.ProductId,
                    //productName = y.productName,
                    //productPrice = y.productPrice,
                    y.productStock,
                    y.productStatus,
                    y.productModifyDate,
                    y.BrandId
                }).ToList()
            }).FirstOrDefaultAsync(x => x.BrandId == id);
            //var brand = await db.Brand.Select(x=> new {
            //    x.brandDesc,
            //    x.BrandId,
            //    x.brandLogoUrl,
            //    x.brandName,
            //    Product = x.Products.Select(y=>new {
            //        y.productDesc
            //    })
            //}).FirstOrDefaultAsync(x=>x.BrandId == id);
            if (brand == null) {
                return NotFound();
            }
           
            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void)), Authentication, Route("api/putBrands")]
        public async Task<IHttpActionResult> PutBrand(int id, BrandDTO brand) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != brand.BrandId) {
                return BadRequest();
            }


            var brandDB = await db.Brand.FindAsync(id);
            brand.CopyProperties(brandDB);

            db.Entry(brandDB).State = EntityState.Modified;

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
        [ResponseType(typeof(Brand)), Authentication, Route("api/postBrands", Name = "postBrands")]
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
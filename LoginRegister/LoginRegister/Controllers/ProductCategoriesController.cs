using LoginRegister.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    public class ProductCategoriesController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/ProductCategories
        public IQueryable<ProductCategory> GetProductCategory() {
            return db.ProductCategory;
        }

        // GET: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory))]
        public async Task<IHttpActionResult> GetProductCategory(int id) {
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null) {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // PUT: api/ProductCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductCategory(int id, ProductCategory productCategory) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != productCategory.CategoryId) {
                return BadRequest();
            }

            db.Entry(productCategory).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ProductCategoryExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductCategories
        [ResponseType(typeof(ProductCategory))]
        public async Task<IHttpActionResult> PostProductCategory(ProductCategory productCategory) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.ProductCategory.Add(productCategory);

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (ProductCategoryExists(productCategory.CategoryId)) {
                    return Conflict();
                } else {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productCategory.CategoryId }, productCategory);
        }

        // DELETE: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory))]
        public async Task<IHttpActionResult> DeleteProductCategory(int id) {
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null) {
                return NotFound();
            }

            db.ProductCategory.Remove(productCategory);
            await db.SaveChangesAsync();

            return Ok(productCategory);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoryExists(int id) {
            return db.ProductCategory.Count(e => e.CategoryId == id) > 0;
        }
    }
}
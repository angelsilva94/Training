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
    [RoutePrefix("reviewProducts")]
    public class ReviewProductsController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/ReviewProducts
        [Route("api/getReviewProducts")]
        public IQueryable<ReviewProduct> GetReviewProduct() {
            return db.ReviewProduct;
        }

        // GET: api/ReviewProducts/5
        [ResponseType(typeof(ReviewProduct)), Route("api/getReviewProducts/search")]
        public async Task<IHttpActionResult> GetReviewProduct(int id) {
            ReviewProduct reviewProduct = await db.ReviewProduct.FindAsync(id);
            if (reviewProduct == null) {
                return NotFound();
            }

            return Ok(reviewProduct);
        }

        // PUT: api/ReviewProducts/5
        [ResponseType(typeof(void)),Route("api/putReviewProducts"),Authentication]
        public async Task<IHttpActionResult> PutReviewProduct(int id, ReviewProduct reviewProduct) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != reviewProduct.ProductId) {
                return BadRequest();
            }

            db.Entry(reviewProduct).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ReviewProductExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReviewProducts
        [ResponseType(typeof(ReviewProduct)), Route("api/postReviewProducts",Name = "postReviewProducts"),Authentication]
        public async Task<IHttpActionResult> PostReviewProduct(ReviewProduct reviewProduct) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.ReviewProduct.Add(reviewProduct);

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (ReviewProductExists(reviewProduct.ProductId)) {
                    return Conflict();
                } else {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reviewProduct.ProductId }, reviewProduct);
        }

        //// DELETE: api/ReviewProducts/5
        //[ResponseType(typeof(ReviewProduct))]
        //public async Task<IHttpActionResult> DeleteReviewProduct(int id) {
        //    ReviewProduct reviewProduct = await db.ReviewProduct.FindAsync(id);
        //    if (reviewProduct == null) {
        //        return NotFound();
        //    }

        //    db.ReviewProduct.Remove(reviewProduct);
        //    await db.SaveChangesAsync();

        //    return Ok(reviewProduct);
        //}

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewProductExists(int id) {
            return db.ReviewProduct.Count(e => e.ProductId == id) > 0;
        }
    }
}
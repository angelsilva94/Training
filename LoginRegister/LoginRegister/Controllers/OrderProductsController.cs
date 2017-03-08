using LoginRegister.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    public class OrderProductsController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/OrderProducts
        public IQueryable<OrderProduct> GetOrderProduct() {
            return db.OrderProduct;
        }

        // GET: api/OrderProducts/5
        [ResponseType(typeof(OrderProduct))]
        public async Task<IHttpActionResult> GetOrderProduct(int id) {
            OrderProduct orderProduct = await db.OrderProduct.FindAsync(id);
            if (orderProduct == null) {
                return NotFound();
            }

            return Ok(orderProduct);
        }

        // PUT: api/OrderProducts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrderProduct(int id, OrderProduct orderProduct) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != orderProduct.OrderProductId) {
                return BadRequest();
            }

            db.Entry(orderProduct).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!OrderProductExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderProducts
        [ResponseType(typeof(OrderProduct))]
        public async Task<IHttpActionResult> PostOrderProduct(OrderProduct orderProduct) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.OrderProduct.Add(orderProduct);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = orderProduct.OrderProductId }, orderProduct);
        }

        // DELETE: api/OrderProducts/5
        [ResponseType(typeof(OrderProduct))]
        public async Task<IHttpActionResult> DeleteOrderProduct(int id) {
            OrderProduct orderProduct = await db.OrderProduct.FindAsync(id);
            if (orderProduct == null) {
                return NotFound();
            }

            db.OrderProduct.Remove(orderProduct);
            await db.SaveChangesAsync();

            return Ok(orderProduct);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderProductExists(int id) {
            return db.OrderProduct.Count(e => e.OrderProductId == id) > 0;
        }
    }
}
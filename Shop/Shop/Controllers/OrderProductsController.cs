//using LoginRegister.Models;
//using Shop.Models.DBModel;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;

//namespace LoginRegister.Controllers {

//    public class OrderProductsController : ApiController {
//        private ShopDBContext db = new ShopDBContext();

//        // GET: api/OrderDetails
//        public IQueryable<OrderDetail> GetOrderProduct() {
//            return db.OrderProduct;
//        }

//        // GET: api/OrderDetails/5
//        [ResponseType(typeof(OrderDetail))]
//        public async Task<IHttpActionResult> GetOrderProduct(int id) {
//            OrderDetail orderProduct = await db.OrderProduct.FindAsync(id);
//            if (orderProduct == null) {
//                return NotFound();
//            }

//            return Ok(orderProduct);
//        }

//        // PUT: api/OrderDetails/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutOrderProduct(int id, OrderDetail orderProduct) {
//            if (!ModelState.IsValid) {
//                return BadRequest(ModelState);
//            }

//            if (id != orderProduct.OrderDetailId) {
//                return BadRequest();
//            }

//            db.Entry(orderProduct).State = EntityState.Modified;

//            try {
//                await db.SaveChangesAsync();
//            } catch (DbUpdateConcurrencyException) {
//                if (!OrderProductExists(id)) {
//                    return NotFound();
//                } else {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/OrderDetails
//        [ResponseType(typeof(OrderDetail))]
//        public async Task<IHttpActionResult> PostOrderProduct(OrderDetail orderProduct) {
//            if (!ModelState.IsValid) {
//                return BadRequest(ModelState);
//            }

//            db.OrderProduct.Add(orderProduct);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = orderProduct.OrderDetailId }, orderProduct);
//        }

//        // DELETE: api/OrderDetails/5
//        [ResponseType(typeof(OrderDetail))]
//        public async Task<IHttpActionResult> DeleteOrderProduct(int id) {
//            OrderDetail orderProduct = await db.OrderProduct.FindAsync(id);
//            if (orderProduct == null) {
//                return NotFound();
//            }

//            db.OrderProduct.Remove(orderProduct);
//            await db.SaveChangesAsync();

//            return Ok(orderProduct);
//        }

//        protected override void Dispose(bool disposing) {
//            if (disposing) {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool OrderProductExists(int id) {
//            return db.OrderProduct.Count(e => e.OrderDetailId == id) > 0;
//        }
//    }
//}
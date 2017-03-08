using LoginRegister.Models;
using LoginRegister.Models.DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    public class OrdersController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        //// GET: api/Orders
        //public IQueryable<Order> GetOrder()
        //{
        //    return db.Order;
        //}

        // GET: api/Orders/5
        //[ResponseType(typeof(Order))]
        [Authentication]
        [Route("api/getOrder")]
        //public async Task<IHttpActionResult> GetOrder(int id)
        //{
        //    Order order = await db.Order.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //
        public async Task<IHttpActionResult> GetOrder() {
            var order = from x in db.Order
                        select new OrderDTO {
                            OrderId = x.OrderId,
                            UserId = x.UserId,
                            orderStatusCode = x.orderStatusCode,
                            //OrderProducts = x.OrderProducts.Select(x=>
                            //new OrderProductDTO { }
                            //)
                            OrderProducts = new List<OrderProductDTO> {
                                new OrderProductDTO {
                                    OrderId = x.OrderProducts.Select(y =>y.OrderId).FirstOrDefault(),
                                    OrderProductId = x.OrderProducts.Select(y =>y.OrderProductId).FirstOrDefault(),
                                    ProductId = x.OrderProducts.Select(y =>y.ProductId).FirstOrDefault(),
                                    Product = new ProductDTO() {
                                        productDesc = x.OrderProducts.Select(y =>y.Product.productDesc).FirstOrDefault(),
                                        ProductId = x.OrderProducts.Select(y =>y.Product.ProductId).FirstOrDefault(),
                                        productName = x.OrderProducts.Select(y =>y.Product.productName).FirstOrDefault(),
                                        productPrice = x.OrderProducts.Select(y =>y.Product.productPrice).FirstOrDefault(),
                                    }
                                }
                            },
                            purchaseDate = x.purchaseDate,
                            quantityOrder = x.quantityOrder,
                            totalOrderPrice = x.totalOrderPrice,
                            User = new UserDTO {
                                UserId = x.UserId,
                                username = x.User.username,
                                userInfo = new UserInfoDTO {
                                    adress = x.User.UserInfo.adress,
                                    city = x.User.UserInfo.city,
                                    country = x.User.UserInfo.country,
                                    zip = x.User.UserInfo.zip
                                }
                            }
                        };
            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Order order) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId) {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!OrderExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            db.Order.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id) {
            Order order = await db.Order.FindAsync(id);
            if (order == null) {
                return NotFound();
            }

            db.Order.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id) {
            return db.Order.Count(e => e.OrderId == id) > 0;
        }
    }
}
using LoginRegister.Models;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {
    [RoutePrefix("Orders")]
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
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> GetOrder() {
            var order = from x in db.Order
                        select new OrderDTO {
                            OrderId = x.OrderId,
                            UserId = x.UserId,
                            orderStatusCode = x.orderStatusCode,
                            //OrderDetails = x.OrderDetails.Select(x=>
                            //new OrderProductDTO { }
                            //)
                            //OrderDetails = new List<OrderProductDTO> {
                            //    new OrderProductDTO {
                            //        OrderId = x.OrderDetails.Select(y =>y.OrderId).FirstOrDefault(),
                            //        OrderDetailId = x.OrderDetails.Select(y =>y.OrderDetailId).FirstOrDefault(),
                            //        ProductId = x.OrderDetails.Select(y =>y.ProductId).FirstOrDefault(),
                            //        Product = new ProductDTO() {
                            //            productDesc = x.OrderDetails.Select(y =>y.Product.productDesc).FirstOrDefault(),
                            //            ProductId = x.OrderDetails.Select(y =>y.Product.ProductId).FirstOrDefault(),
                            //            productName = x.OrderDetails.Select(y =>y.Product.productName).FirstOrDefault(),
                            //            productPrice = x.OrderDetails.Select(y =>y.Product.productPrice).FirstOrDefault(),
                            //        }
                            //    }
                            //}
                            OrderDetails = x.OrderDetails.Select(op => new OrderDetailDTO {
                                OrderId = op.OrderId,
                                OrderDetailId = op.OrderDetailId,
                                ProductId = op.ProductId,
                                Product = new ProductDTO {
                                    productDesc = op.Product.productDesc,
                                    ProductId = op.Product.ProductId,
                                    productName = op.Product.productName,
                                    productPrice = op.Product.productPrice
                                }
                                //etc
                            }).ToList(),
                            purchaseDate = x.purchaseDate,
                            quantityOrder = x.quantityOrder,
                            totalOrderPrice = x.totalOrderPrice,
                            User = new UserDTO {
                                UserId = x.UserId,
                                age = x.User.age,
                                username = x.User.username,
                                regDate = x.User.regDate,
                                userInfo = new UserInfoDTO {
                                    adress = x.User.UserInfo.adress,
                                    city = x.User.UserInfo.city,
                                    country = x.User.UserInfo.country,
                                    zip = x.User.UserInfo.zip,
                                    phone = x.User.UserInfo.phone
                                }
                            }
                        };
            return Ok(order);
        }

        [Authentication]
        [Route("api/getOrder/search")]
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> GetOrder(int id) {
            var order = await db.Order.Include(x => x.OrderId).Select(x =>
              new OrderDTO {
                  OrderId = x.OrderId,
                  OrderDetails = x.OrderDetails.Select(op => new OrderDetailDTO {
                      OrderId = op.OrderId,
                      OrderDetailId = op.OrderDetailId,
                      Product = new ProductDTO {
                          productDesc = op.Product.productDesc,
                          ProductId = op.Product.ProductId,
                          productName = op.Product.productName,
                          productPrice = op.Product.productPrice
                      }
                      //etc
                  }).ToList(),
                  orderStatusCode = x.orderStatusCode,
                  purchaseDate = x.purchaseDate,
                  quantityOrder = x.quantityOrder,
                  totalOrderPrice = x.totalOrderPrice,
                  User = new UserDTO {
                      UserId = x.UserId,
                      username = x.User.username,
                      userInfo = new UserInfoDTO {
                          phone = 23.ToString(),
                          adress = x.User.UserInfo.adress,
                          city = x.User.UserInfo.city,
                          country = x.User.UserInfo.country,
                          zip = x.User.UserInfo.zip,
                      }
                  }
              }).SingleOrDefaultAsync(x => x.OrderId == id);

            if (order == null) {
                return NotFound();
            } else {
                return Ok(order);
            }
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
        //[Authentication]
        [Route("api/submit")]
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
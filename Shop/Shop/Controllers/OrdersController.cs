using LoginRegister.Models;
using Shop.Extensions;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    [RoutePrefix("orders"), Authentication]
    public class OrdersController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        //// GET: api/Orders
        //public IQueryable<Order> GetOrder()
        //{
        //    return db.Order;
        //}

        // GET: api/Orders/5
        //[ResponseType(typeof(Order))]
        //[Authentication]
        //[Route("api/getOrder"), Authentication]
        //public async Task<IHttpActionResult> GetOrder(int id)
        //{
        //    Order order = await db.Order.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //
        [ResponseType(typeof(OrderDTO)), Route("api/orders")]
        //public  IQueryable<OrderDto> GetOrder() { check which is better
        public async Task<IHttpActionResult> GetOrder() {
            //linq method way
            var order = await db.Order.Select(x => new {
                OrderId = x.OrderId,
                UserId = x.UserId,
                orderStatusCode = x.orderStatusCode,

                OrderDetails = x.OrderDetails.Select(y => new /*  ANONYMOUS TYPE OrderDetailDTO*/ {
                    OrderId = y.OrderId,
                    OrderDetailId = y.OrderDetailId,
                    quantityOrder = y.quantityOrder,
                    ProductId = y.ProductId,
                    Product = new {
                        productDesc = y.Product.productDesc,
                        ProductId = y.Product.ProductId,
                        productName = y.Product.productName,
                        productPrice = y.Product.productPrice
                    }
                }).ToList(),
                purchaseDate = x.purchaseDate,
                //quantityOrder = x.quantityOrder,
                totalOrderPrice = x.totalOrderPrice,
                User = new {
                    UserId = x.UserId,
                    age = x.User.age,
                    username = x.User.username,
                    regDate = x.User.regDate,
                    //x.User.username igual se puede usar
                    userInfo = new {
                        adress = x.User.UserInfo.adress,
                        city = x.User.UserInfo.city,
                        country = x.User.UserInfo.country,
                        zip = x.User.UserInfo.zip,
                        phone = x.User.UserInfo.phone
                    }
                }
            }).AsNoTracking().ToListAsync();

            //query syntax way
            //var order = from x in db.Order
            //            select new OrderDTO {
            //                OrderId = x.OrderId,
            //                UserId = x.UserId,
            //                orderStatusCode = x.orderStatusCode,
            //                //OrderDetails = x.OrderDetails.Select(x=>
            //                //new OrderProductDTO { }
            //                //)
            //                //OrderDetails = new List<OrderProductDTO> {
            //                //    new OrderProductDTO {
            //                //        OrderId = x.OrderDetails.Select(y =>y.OrderId).FirstOrDefault(),
            //                //        OrderDetailId = x.OrderDetails.Select(y =>y.OrderDetailId).FirstOrDefault(),
            //                //        ProductId = x.OrderDetails.Select(y =>y.ProductId).FirstOrDefault(),
            //                //        Product = new ProductDTO() {
            //                //            productDesc = x.OrderDetails.Select(y =>y.Product.productDesc).FirstOrDefault(),
            //                //            ProductId = x.OrderDetails.Select(y =>y.Product.ProductId).FirstOrDefault(),
            //                //            productName = x.OrderDetails.Select(y =>y.Product.productName).FirstOrDefault(),
            //                //            productPrice = x.OrderDetails.Select(y =>y.Product.productPrice).FirstOrDefault(),
            //                //        }
            //                //    }
            //                //}
            //                OrderDetails = x.OrderDetails.Select(op => new OrderDetailDTO {
            //                    OrderId = op.OrderId,
            //                    OrderDetailId = op.OrderDetailId,
            //                    ProductId = op.ProductId,
            //                    Product = new ProductDTO {
            //                        productDesc = op.Product.productDesc,
            //                        ProductId = op.Product.ProductId,
            //                        productName = op.Product.productName,
            //                        productPrice = op.Product.productPrice
            //                    }
            //                    //etc
            //                }).ToList(),
            //                purchaseDate = x.purchaseDate,
            //                quantityOrder = x.quantityOrder,
            //                totalOrderPrice = x.totalOrderPrice,
            //                User = new UserDTO {
            //                    UserId = x.UserId,
            //                    age = x.User.age,
            //                    username = x.User.username,
            //                    regDate = x.User.regDate,
            //                    userInfo = new UserInfoDTO {
            //                        adress = x.User.UserInfo.adress,
            //                        city = x.User.UserInfo.city,
            //                        country = x.User.UserInfo.country,
            //                        zip = x.User.UserInfo.zip,
            //                        phone = x.User.UserInfo.phone
            //                    }
            //                }
            //            };
            return Ok(order);
        }

        //[Authentication]
        //[Route("api/getOrder/search")]
        [ResponseType(typeof(OrderDTO)), Route("api/orders")]
        public async Task<IHttpActionResult> GetOrder(int id) {
            var order = await db.Order.Select(x => new OrderDTO {
                OrderId = x.OrderId,
                orderStatusCode = x.orderStatusCode,
                purchaseDate = x.purchaseDate,
                //quantityOrder = x.quantityOrder,
                totalOrderPrice = x.totalOrderPrice,
                UserId = x.UserId,
                User = new UserDTO {
                    UserId = x.User.UserId,
                    username = x.User.username,
                    password = x.User.password,
                    name = x.User.name,
                    lastName = x.User.lastName,
                    surname = x.User.surname,
                    age = x.User.age,
                    email = x.User.email,
                    regDate = x.User.regDate,
                    userMode = x.User.userMode,
                    userInfo = new UserInfoDTO {
                        adress = x.User.UserInfo.adress,
                        city = x.User.UserInfo.city,
                        zip = x.User.UserInfo.zip,
                        country = x.User.UserInfo.country,
                        phone = x.User.UserInfo.phone,
                    }
                },
                OrderDetails = x.OrderDetails.Select(y => new OrderDetailDTO {
                    OrderDetailId = y.OrderDetailId,
                    OrderId = y.OrderId,
                    ProductId = y.ProductId,
                    quantityOrder = y.quantityOrder,
                    Product = new ProductDTO {
                        productDesc = y.Product.productDesc,
                        ProductId = y.Product.ProductId,
                        productName = y.Product.productName,
                        productPrice = y.Product.productPrice
                    }
                }).ToList()
            }).SingleOrDefaultAsync(x => x.OrderId == id);
            //

            //var order = await db.Order.Include(x => x.OrderId).Select(x =>
            //  new OrderDTO {
            //      OrderId = x.OrderId,
            //      OrderDetails = x.OrderDetails.Select(y => new OrderDetailDTO {
            //          OrderId = y.OrderId,
            //          OrderDetailId = y.OrderDetailId,
            //          Product = new ProductDTO {
            //              productDesc = y.Product.productDesc,
            //              ProductId = y.Product.ProductId,
            //              productName = y.Product.productName,
            //              productPrice = y.Product.productPrice
            //          }
            //          //etc
            //      }).ToList(),
            //      orderStatusCode = x.orderStatusCode,
            //      purchaseDate = x.purchaseDate,
            //      quantityOrder = x.quantityOrder,
            //      totalOrderPrice = x.totalOrderPrice,
            //      User = new UserDTO {
            //          UserId = x.UserId,
            //          username = x.User.username,
            //          userInfo = new UserInfoDTO {
            //              phone = 23.ToString(),
            //              adress = x.User.UserInfo.adress,
            //              city = x.User.UserInfo.city,
            //              country = x.User.UserInfo.country,
            //              zip = x.User.UserInfo.zip,
            //          }
            //      }
            //  }).SingleOrDefaultAsync(x => x.OrderId == id);

            if (order == null) {
                return NotFound();
            } else {
                return Ok(order);
            }
            //IQueryable<Order> temp = db.Order.Where(x => x.OrderId == id).ToList<Order>().AsQueryable();
            //var order = new OrderDTO {
            //    OrderId = temp.Select(x=>x.OrderId).First(),
            //    orderStatusCode= temp.Select(x => x.orderStatusCode).First(),
            //    purchaseDate = temp.Select(x => x.purchaseDate).First(),
            //    quantityOrder = temp.Select(x => x.quantityOrder).First(),
            //    totalOrderPrice = temp.Select(x => x.totalOrderPrice).First(),
            //    User = new UserDTO {
            //        UserId = temp.Select(x => x.User.UserId).First(),
            //        username = temp.Select(x => x.User.username).First(),
            //        email = temp.Select(x => x.User.email).First()
            //    },
            //    //x.OrderDetails.Select(y => new OrderDetailDTO
            //    OrderDetails = temp.Select(x => new OrderDetailDTO {
            //        OrderDetailId= x.OrderDetails.Select(y=>y.OrderDetailId).First(),
            //        //ProductId= x.OrderDetails.Select(y => y.ProductId).Single(),
            //        Product = new ProductDTO {
            //            ProductId = x.OrderDetails.Select(y => y.Product.ProductId).First(),
            //            productDesc= x.OrderDetails.Select(y => y.Product.productDesc).First(),
            //            productName= x.OrderDetails.Select(y => y.Product.productName).First(),
            //            productPrice= x.OrderDetails.Select(y => y.Product.productPrice).First(),
            //        }
            //    } ).ToList()
            //};
            //return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void)), Route("api/orders")]
        public async Task<IHttpActionResult> PutOrder(int id, OrderDTO order) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId) {
                return BadRequest();
            }
            var orderDb = db.Order.Find(id);
            orderDb.purchaseDate = order.purchaseDate.Equals(DateTime.MinValue) ? orderDb.purchaseDate : order.purchaseDate;
            //orderDb.quantityOrder = order.quantityOrder.Equals(null) ? orderDb.quantityOrder : order.quantityOrder;
            orderDb.totalOrderPrice = order.totalOrderPrice.Equals(null) ? orderDb.totalOrderPrice : order.totalOrderPrice;

            var aux = 10;
            db.Entry(orderDb).State = EntityState.Modified;

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
        [ResponseType(typeof(Order)), Route("api/orders", Name = "postOrders")]
        //[Authentication]
        //[Route("api/submit",Name = "orderPost")]
        public async Task<IHttpActionResult> PostOrder(OrderDTO order) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var orderDb = new Order();
            order.CopyProperties(orderDb);

            db.Order.Add(orderDb);
            await db.SaveChangesAsync();

            return CreatedAtRoute("postOrders", new { id = orderDb.OrderId }, orderDb);
        }

        //// DELETE: api/Orders/5
        //[ResponseType(typeof(Order))]
        //public async Task<IHttpActionResult> DeleteOrder(int id) {
        //    Order order = await db.Order.FindAsync(id);
        //    if (order == null) {
        //        return NotFound();
        //    }

        //    db.Order.Remove(order);
        //    await db.SaveChangesAsync();

        //    return Ok(order);
        //}

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
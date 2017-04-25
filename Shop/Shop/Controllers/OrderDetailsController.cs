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
using Shop.Models.DBModel;
using LoginRegister;
using Shop.Models.DBModel.DTO;
using Shop.Extensions;

namespace Shop.Controllers
{
    [RoutePrefix("orderDetail"),Authentication]
    public class OrderDetailsController : ApiController
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/OrderDetails
        [ResponseType(typeof(OrderDetail)), Authentication, Route("api/orderDetail")]
        public async Task <IHttpActionResult> GetOrderDetails()
        {
            var orderDetail = await db.OrderDetails.Select(x=>new {
                x.OrderDetailId,
                x.quantityOrder,
                Product = new {
                    x.Product.ProductId,
                    x.Product.productName,
                    x.Product.productPrice,
                    x.Product.productUrl,
                    x.Product.productDesc,
                    x.Product.Brand.brandName,
                    x.Product.Brand.brandDesc
                },
                Order = new {
                    x.Order.OrderId,
                    x.Order.OrderStatus.orderStatusCod,
                    x.Order.OrderStatus.orderStatusDesc,
                    x.Order.purchaseDate,
                    //x.Order.quantityOrder,
                    x.Order.totalOrderPrice,
                }
            }).ToListAsync();
            return Ok(orderDetail);
        }

        // GET: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail)), Authentication,Route("api/orderDetail")]
        public async Task<IHttpActionResult> GetOrderDetail(int id)
        {
            var orderDetail = await db.OrderDetails.Select(x=>new {
                x.OrderDetailId,
                x.quantityOrder,
                Product = new {
                    x.Product.ProductId,
                    x.Product.productName,
                    x.Product.productPrice,
                    x.Product.productUrl,
                    x.Product.productDesc,
                    x.Product.Brand.brandName,
                    x.Product.Brand.brandDesc
                },
                Order = new {
                    x.Order.OrderId,
                    x.Order.OrderStatus.orderStatusCod,
                    x.Order.OrderStatus.orderStatusDesc,
                    x.Order.purchaseDate,
//                    x.Order.quantityOrder,
                    x.Order.totalOrderPrice,
                }
            }).SingleOrDefaultAsync();

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // PUT: api/OrderDetails/5
        [ResponseType(typeof(void)),Route("api/orderDetail"),Authentication]
        public async Task<IHttpActionResult> PutOrderDetail(int id, OrderDetailDTO orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.OrderDetailId)
            {
                return BadRequest();
            }
            var orderDetailDb = db.OrderDetails.Find(id);
            orderDetail.CopyProperties(orderDetailDb);
            db.Entry(orderDetailDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetails
        
        [Route("api/orderDetail", Name = "OrderDetail"), Authentication, ResponseType(typeof(OrderDetail))]
        public async Task<IHttpActionResult> PostOrderDetail(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderDetails.Add(orderDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("OrderDetail", new { id = orderDetail.OrderDetailId }, orderDetail);
        }

        //// DELETE: api/OrderDetails/5
        //[ResponseType(typeof(OrderDetail))]
        //public async Task<IHttpActionResult> DeleteOrderDetail(int id)
        //{
        //    OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
        //    if (orderDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.OrderDetails.Remove(orderDetail);
        //    await db.SaveChangesAsync();

        //    return Ok(orderDetail);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderDetailExists(int id)
        {
            return db.OrderDetails.Count(e => e.OrderDetailId == id) > 0;
        }
    }
}
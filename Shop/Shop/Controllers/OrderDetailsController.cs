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

namespace Shop.Controllers
{
    [RoutePrefix("orderDetail")]
    public class OrderDetailsController : ApiController
    {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/OrderDetails
        [ResponseType(typeof(OrderDetail)), Authentication, Route("getOrderDetails")]
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            return db.OrderDetails;
        }

        // GET: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail)), Authentication,Route("getOrderDetails/search")]
        public async Task<IHttpActionResult> GetOrderDetail(int id)
        {
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // PUT: api/OrderDetails/5
        [ResponseType(typeof(void)),Route("api/Put"),Authentication]
        public async Task<IHttpActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.OrderDetailId)
            {
                return BadRequest();
            }

            db.Entry(orderDetail).State = EntityState.Modified;

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
        
        [Route("api/Post",Name = "OrderDetail"), Authentication, ResponseType(typeof(OrderDetail))]
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
using LoginRegister.Models;
using Shop.Extensions;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {
    [RoutePrefix("products")]
    public class ProductsController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/Products
        [ResponseType(typeof(Product)), Authentication, Route("api/getProducts")]
        public async Task<IHttpActionResult> GetProduct() {
            var product = await  db.Product.AsNoTracking().Select(x => new ProductDTO {
                productDesc = x.productDesc,
                ProductId = x.ProductId,
                productName = x.productName,
                productPrice = x.productPrice,
                productStatus = x.productStatus,
                productStock = x.productStock,
                productModifyDate = x.productModifyDate
            }).ToListAsync();

            return Ok(product);
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductDTO)),Authentication,Route("api/getProducts/search")]
        public async Task<IHttpActionResult> GetProduct(int id) {
            var product = await db.Product.Select(x => new ProductDTO {
                productDesc = x.productDesc,
                ProductId = x.ProductId,
                productName = x.productName,
                productPrice = x.productPrice,
                productModifyDate = x.productModifyDate,
                productStatus = x.productStatus,
                productStock = x.productStock
            }).SingleOrDefaultAsync(x => x.ProductId == id);
            //var temp = await db.Product.FindAsync(id);
            //ProductDTO product = new ProductDTO();
            //temp.CopyProperties(product);
            //var product = db.Product.Project().To<ProductDTO>().SingleOrDefault(x=> x.ProductId == id );

            if (product == null) {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void)),Authentication,Route("api/putProducts")]
        public async Task<IHttpActionResult> PutProduct(int id, ProductDTO product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId) {
                return BadRequest();
            }

            var productDb = db.Product.Find(id);
            product.CopyProperties(productDb);
            //productDb.productName = product.productName;
            //productDb.productDesc = product.productDesc;
            //productDb.productPrice = product.productPrice;
            //productDb.productModifyDate = product.productModifyDate;
            //productDb.productStatus = product.productStatus;
            //productDb.productStock = productDb.productStock;
            //productDb.BrandId = productDb.BrandId;

            db.Entry(productDb).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ProductExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(ProductDTO)),Authentication,Route("postProduct", Name = "postProduct")]
        public async Task<IHttpActionResult> PostProduct(ProductDTO product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            Product productDb = new Product();
            product.CopyProperties(productDb);

            db.Product.Add(productDb);
            await db.SaveChangesAsync();

            return CreatedAtRoute("postProduct", new { id = product.ProductId }, product);
        }

        //// DELETE: api/Products/5
        //[ResponseType(typeof(Product))]
        //public async Task<IHttpActionResult> DeleteProduct(int id) {
        //    Product product = await db.Product.FindAsync(id);
        //    if (product == null) {
        //        return NotFound();
        //    }

        //    db.Product.Remove(product);
        //    await db.SaveChangesAsync();

        //    return Ok(product);
        //}

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id) {
            return db.Product.Count(e => e.ProductId == id) > 0;
        }
    }
}
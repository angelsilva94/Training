using LoginRegister.Models;
using Shop.Extensions;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {

    [RoutePrefix("products")]
    public class ProductsController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        [ResponseType(typeof(Product)), Route("search")]
        public async Task<HttpResponseMessage> GetProduct(string criteria) {
            var product = await db.Product.Select(x => new {
                productDesc = x.productDesc,
                ProductId = x.ProductId,
                productName = x.productName,
                productPrice = x.productPrice,
                productStatus = x.productStatus,
                productStock = x.productStock,
                productModifyDate = x.productModifyDate,
                productUrl = x.productUrl,
                ReviewProducts = x.ReviewProducts.Select(y => new {
                    y.ratingReview,
                    y.reviewDesc,
                    y.ReviewProductIdNumber,
                    User = new {
                        y.User.username,
                        y.User.UserId,
                        y.User.name,
                        y.User.lastName
                    }
                })
            }).Where(x => x.productName.Contains(criteria) && x.productStatus==true).ToListAsync();

            var response = Request.CreateResponse(HttpStatusCode.OK, product);
            response.Headers.Add("X-Total-Count", db.Product.Count().ToString());
            

            if (product == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return response;
        }

        [ResponseType(typeof(Product)), Route("")]
        public async Task<HttpResponseMessage> GetProduct(int _page, int _perPage,string _sortDir,string _sortField) {
            var product = await db.Product.AsNoTracking().Select(x => new {
                productDesc = x.productDesc,
                ProductId = x.ProductId,
                productName = x.productName,
                productPrice = x.productPrice,
                productStatus = x.productStatus,
                productStock = x.productStock,
                productModifyDate = x.productModifyDate,
                productUrl = x.productUrl,
                ReviewProducts = x.ReviewProducts.Select(y => new {
                    y.ratingReview,
                    y.reviewDesc,
                    y.ReviewProductIdNumber,
                    User = new {
                        y.User.username,
                        y.User.UserId,
                        y.User.name,
                        y.User.lastName
                    }
                })
            }).OrderBy(x => x.ProductId).Skip((_page - 1) * _perPage).Take(_perPage).ToListAsync();
            var response = Request.CreateResponse(HttpStatusCode.OK, product);
            response.Headers.Add("X-Total-Count", db.Product.Count().ToString());
            return response;
            
        }
        // GET: api/Products
        [ResponseType(typeof(Product)), Route("")]
        public async Task<HttpResponseMessage> GetProduct([FromUri]int _page, [FromUri]int _perPage) {
            var product = await db.Product.AsNoTracking().Select(x => new {
                productDesc = x.productDesc,
                ProductId = x.ProductId,
                productName = x.productName,
                productPrice = x.productPrice,
                productStatus = x.productStatus,
                productStock = x.productStock,
                productModifyDate = x.productModifyDate,
                productUrl = x.productUrl,
                ReviewProducts = x.ReviewProducts.Select(y => new {
                    y.ratingReview,
                    y.reviewDesc,
                    y.ReviewProductIdNumber,
                    User = new {
                        y.User.username,
                        y.User.UserId,
                        y.User.name,
                        y.User.lastName
                    }
                })
            }).OrderBy(x => x.ProductId).Where(x => x.productStatus == true).ToListAsync();

            var response = Request.CreateResponse(HttpStatusCode.OK, product.Skip(_perPage * (_page )).Take(_perPage));

            //AQUI ME QUEDE
            response.Headers.Add("X-Total-Count", product.Count().ToString());
            return response;
        }

        // GET: api/Products/5
        [ResponseType(typeof(ProductDTO)), Route("{id}")]
        public async Task<IHttpActionResult> GetProduct(int id) {
            var product = await db.Product.Select(x => new {
                productDesc = x.productDesc,
                ProductId = x.ProductId,
                productName = x.productName,
                productPrice = x.productPrice,
                productStatus = x.productStatus,
                productStock = x.productStock,
                productModifyDate = x.productModifyDate,
                productUrl = x.productUrl,
                ReviewProducts = x.ReviewProducts.Select(y => new {
                    y.ratingReview,
                    y.reviewDesc,
                    y.ReviewProductIdNumber,
                    User = new {
                        y.User.username,
                        y.User.UserId,
                        y.User.name,
                        y.User.lastName
                    }
                })
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
        [ResponseType(typeof(void)), Route("{id}")]
        public async Task<IHttpActionResult> PutProduct(int id, ProductDTO product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId) {
                return BadRequest();
            }
            product.productModifyDate = DateTime.Now;
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
        [ResponseType(typeof(ProductDTO)), Route("", Name = "postProduct")]
        public async Task<IHttpActionResult> PostProduct(Product product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            //var productDb = new Product();
            product.productModifyDate=DateTime.Now;
            product.BrandId = 1;
            //product.CopyProperties(productDb);
            //productDb.productName = product.productName;
            //productDb.productPrice = product.productPrice;
            //productDb.productModifyDate = product.productModifyDate;
            //productDb.productStatus = product.productStatus;

            db.Product.Add(product);

            try {
                await db.SaveChangesAsync();
            } catch (Exception e) {
                Console.WriteLine("error:" + e);
            }

            

            return CreatedAtRoute("postProduct", new { id = product.ProductId }, product.ProductId);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product)), Route("{id}")]
        public async Task<IHttpActionResult> DeleteProduct(int id) {
            Product product = await db.Product.FindAsync(id);
            if (product == null) {
                return NotFound();
            }

            db.Product.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

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
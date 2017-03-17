using LoginRegister.Models;
using Shop.Extensions;
using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using Shop.Models.DTO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoginRegister.Controllers {
    [RoutePrefix("productCategories")]    
    public class ProductCategoriesController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        // GET: api/ProductCategories
        [ResponseType(typeof(ProductCategory)), Route("api/getProductCategories")]
        public async Task<IHttpActionResult> GetProductCategory() {
            //var productCategory = await db.ProductCategory.Select(x => new  {
            //    CategoryId = x.CategoryId,
            //    Product = new  {
            //        productDesc = x.Product.productDesc,
            //        ProductId = x.Product.ProductId,
            //        productName = x.Product.productName,
            //        productPrice = x.Product.productPrice
            //    },
            //    Category = new  {
            //        categoryDesc = x.Category.categoryDesc,
            //        CategoryId = x.Category.CategoryId,
            //        categoryImage = x.Category.categoryImage,
            //        categoryName = x.Category.categoryName,
            //        //categoryParent = new CategoryDTO {
            //        //    categoryDesc = x.Category.categoryParent.categoryDesc,
            //        //    CategoryId = x.Category.categoryParent.CategoryId,
            //        //    categoryImage = x.Category.categoryParent.categoryImage,
            //        //    categoryName = x.Category.categoryParent.categoryName,
            //        //    ProductCategories = x.Category.ProductCategories.Select(y => new ProductCategoryDTO {
            //        //        CategoryId = y.CategoryId,
            //        //        ProductId = y.ProductId,


            //        //    }).ToList()
            //        //},
            //        ProductCategories = x.Category.ProductCategories.Select(y => new ProductCategoryDTO {
            //            CategoryId = y.CategoryId,
            //            ProductId = y.ProductId,
            //            Product = new ProductDTO {
            //                productDesc = y.Product.productDesc,
            //                ProductId = y.Product.ProductId,
            //                productName = y.Product.productName,
            //                productPrice = y.Product.productPrice
            //            },
            //            Category = new CategoryDTO {
            //                categoryDesc = x.Category.categoryDesc,
            //                CategoryId = x.Category.CategoryId,
            //                categoryImage = x.Category.categoryImage,
            //                categoryName = x.Category.categoryName
            //            }
            //        }).ToList(),
            //        categoryParent = new CategoryDTO {
            //            categoryDesc = x.Category.categoryDesc,
            //            CategoryId = x.Category.CategoryId,
            //            categoryImage = x.Category.categoryImage,
            //            categoryName = x.Category.categoryName,
            //        }
            //    }
            //}).ToListAsync() ;

            var productCategory = db.ProductCategory.Select(x=>new {
                x.Category,
                x.CategoryId,
                x.Product
            });
            return Ok(productCategory);
        }

        // GET: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory)),Route("api/getProductCategories/search")]
        public async Task<IHttpActionResult> GetProductCategory(int id) {
            ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
            if (productCategory == null) {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // PUT: api/ProductCategories/5
        [ResponseType(typeof(void)),Authentication, Route("api/putProductCategories")]
        public async Task<IHttpActionResult> PutProductCategory(int id, ProductCategory productCategory) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != productCategory.CategoryId) {
                return BadRequest();
            }

            db.Entry(productCategory).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!ProductCategoryExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductCategories
        [ResponseType(typeof(ProductCategory)), Authentication, Route("api/postProductCategories", Name = "postProductCategories")]
        public async Task<IHttpActionResult> PostProductCategory(ProductCategoryDTO productCategory) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var productCategoryDb = new ProductCategory();
            productCategory.CopyProperties(productCategoryDb);
            db.ProductCategory.Add(productCategoryDb);

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (ProductCategoryExists(productCategory.CategoryId)) {
                    return Conflict();
                } else {
                    throw;
                }
            }

            return CreatedAtRoute("postProductCategories", new { id = productCategory.CategoryId }, productCategory);
        }

        //// DELETE: api/ProductCategories/5
        //[ResponseType(typeof(ProductCategory))]
        //public async Task<IHttpActionResult> DeleteProductCategory(int id) {
        //    ProductCategory productCategory = await db.ProductCategory.FindAsync(id);
        //    if (productCategory == null) {
        //        return NotFound();
        //    }

        //    db.ProductCategory.Remove(productCategory);
        //    await db.SaveChangesAsync();

        //    return Ok(productCategory);
        //}

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoryExists(int id) {
            return db.ProductCategory.Count(e => e.CategoryId == id) > 0;
        }
    }
}
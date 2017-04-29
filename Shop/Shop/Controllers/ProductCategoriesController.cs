using LoginRegister.Models;
using Shop.Extensions;
using Shop.Models.DBModel;
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
        [ResponseType(typeof(ProductCategory)), Route("api/productCategory")]
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

            var productCategory = db.ProductCategory.Select(x => new {
                x.ProductCategoryId,
                x.CategoryId,
                x.ProductId,
                Product = new {
                    x.Product.ProductId,
                    x.Product.productName,
                    x.Product.productPrice,
                    x.Product.productPublishDate,
                    x.Product.productUrl,
                    //x.Product.BrandId,
                    Brand = new {
                        x.Product.Brand.BrandId,
                        x.Product.Brand.brandDesc,
                        x.Product.Brand.brandLogoUrl,
                        x.Product.Brand.brandName,
                    }
                },
                Category = new {
                    x.Category.CategoryId,
                    x.Category.categoryDesc,
                    x.Category.categoryName,
                    x.Category.categoryParent,
                    x.Category.categoryParentId,
                    x.Category.categoryImage
                }

                //x.Product
            });
            return Ok(productCategory);
        }

        // GET: api/ProductCategories/5
        [ResponseType(typeof(ProductCategory)), Route("api/productCategory")]
        public async Task<IHttpActionResult> GetProductCategory(int id) {
            var productCategory = await db.ProductCategory.Select(x => new {
                x.ProductCategoryId,
                x.Category.CategoryId,
                product = new {
                    x.Product.Brand.BrandId,
                    x.Product.Brand.brandDesc,
                    x.Product.Brand.brandLogoUrl,
                    x.Product.Brand.brandName,
                    x.Product.productUrl,
                    x.Product.productStock,
                    x.Product.productName,
                    x.Product.productPrice,
                    x.Product.productDesc,
                    x.Product.ProductId,
                    x.Product.productPublishDate,
                    x.Product.productModifyDate,
                    ReviewProducts = x.Product.ReviewProducts.Select(y => new {
                        y.ratingReview,
                    })
                },
                //category = new {
                //    x.Category.CategoryId,
                //    x.Category.categoryDesc
                //},
            }).Where(x => x.CategoryId == id).ToListAsync();
            if (productCategory == null) {
                return NotFound();
            }

            return Ok(productCategory);
        }

        // PUT: api/ProductCategories/5
        [ResponseType(typeof(void)), Authentication, Route("api/productCategory")]
        public async Task<IHttpActionResult> PutProductCategory(int id, ProductCategoryDTO productCategory) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != productCategory.ProductCategoryId) {
                return BadRequest();
            }
            var productCategoryDb = db.ProductCategory.Find(productCategory.ProductCategoryId);
            productCategory.CopyProperties(productCategoryDb);
            db.Entry(productCategoryDb).State = EntityState.Modified;

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
        [ResponseType(typeof(ProductCategory)), Authentication, Route("api/productCategory", Name = "productCategory")]
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

            return CreatedAtRoute("productCategory", new { id = productCategory.CategoryId }, productCategory);
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
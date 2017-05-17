using LoginRegister.Models;
using Shop.Models.DBModel;
using Shop.Models.DTO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Shop.Controllers {

    [RoutePrefix("category")]
    public class CategoriesController : ApiController {
        private ShopDBContext db = new ShopDBContext();

        [Route("")]
        public async Task<HttpResponseMessage> GetCategory(int _page, int _perPage, string _sortDir, string _sortField) {
            var category = await db.Category.Select(x => new {
                x.categoryDesc,
                x.CategoryId,
                x.categoryImage,
                x.categoryName,
                x.categoryParent
            }).OrderBy(x => x.CategoryId).Skip((_page - 1) * _perPage).Take(_perPage).ToListAsync();
            var response = Request.CreateResponse(HttpStatusCode.OK, category);
            response.Headers.Add("X-Total-Count", db.Category.Count().ToString());
            return response;
        }



        [Route("")]
        public async Task<IHttpActionResult> GetCategory() {
            var category = await db.Category.Select(x => new {
                x.categoryDesc,
                x.CategoryId,
                x.categoryImage,
                x.categoryName,
                x.categoryParent,
                ProductCategories = x.ProductCategories.Select(y=>new {
                    y.CategoryId,
                    y.Product.ProductId
                }) 
            }).Where(x=>x.CategoryId == x.ProductCategories.Select(y=>y.CategoryId).FirstOrDefault()).ToListAsync();
            return Ok(category);
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category)), Route("{id}")]
        public async Task<IHttpActionResult> GetCategory(int id) {
            //var category = await db.Category.Where(x => x.CategoryId == id).Select(x => new {
            //    x.categoryDesc,
            //    x.CategoryId,
            //    x.categoryImage,
            //    x.categoryName,
            //    //x.categoryParentId,
            //    //x.ProductCategories,
            //    //categoryParent= new {
            //    //    x.categoryParent.CategoryId
            //    //},
            //    //categoryParent = new {
            //    //    x.categoryParent.categoryParentId,
            //    //    x.categoryParent.ProductCategories
            //    //}
            //    //x.childrenCategory
            //    x.categoryParent
            //}).SingleOrDefaultAsync();
            var category = await db.Category.Select(x => new {
                x.categoryDesc,
                x.CategoryId,
                x.categoryImage,
                x.categoryName,
                x.categoryParent
            }).SingleOrDefaultAsync(x => x.CategoryId == id);
            if (category == null) {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void)), Route("{id}")]
        public async Task<IHttpActionResult> PutCategory(int id, Category category) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId) {
                return BadRequest();
            }

            var categoryDb = db.Category.Find(id);
            //categoryDb.categoryParentId = category.categoryParentId;
            categoryDb.categoryDesc = category.categoryDesc;
            categoryDb.categoryName = category.categoryName;
            categoryDb.categoryImage = category.categoryImage;
            db.Entry(categoryDb).State = EntityState.Modified;

            try {
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CategoryExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(Category)), Route("", Name = "postCategory")]
        public async Task<IHttpActionResult> PostCategory(CategoryDTO category) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var categoryDb = new Category {
                categoryName = category.categoryName,
                categoryDesc = category.categoryDesc,
                categoryImage = category.categoryImage,
                categoryParentId = category.categoryParentId.HasValue ? category.categoryParentId : null
            };

            //category.CopyProperties(categoryDb);
            db.Category.Add(categoryDb);
            await db.SaveChangesAsync();

            return CreatedAtRoute("postCategory", new { id = category.CategoryId }, category);
        }

        //// DELETE: api/Categories/5
        //[ResponseType(typeof(Category))]
        //public async Task<IHttpActionResult> DeleteCategory(int id) {
        //    var category = await db.Category.FindAsync(id);
        //    if (category == null) {
        //        return NotFound();
        //    }

        //    db.Category.Remove(category);
        //    await db.SaveChangesAsync();

        //    return Ok(category);
        //}

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id) {
            return db.Category.Count(e => e.CategoryId == id) > 0;
        }
    }
}
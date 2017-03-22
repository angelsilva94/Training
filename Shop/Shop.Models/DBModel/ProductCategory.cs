using Shop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.DBModel {

    public class ProductCategory : IProductCategory {


        public int ProductCategoryId { set; get; }

        [Required]
        //[Key]
        [ForeignKey("Category")]
        [Column(Order = 1)]
        public int CategoryId { set; get; }

        [Required]
        //[Key]
        [ForeignKey("Product")]
        [Column(Order = 2)]
        public int ProductId { set; get; }

        //1..N ProductModel-ProductCategoryModel

        public virtual Product Product { set; get; }
        //1..N ProductCategoryModel-CategoryModel

        public virtual Category Category { set; get; }
    }
}
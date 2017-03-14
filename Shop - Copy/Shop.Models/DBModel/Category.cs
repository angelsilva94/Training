using Shop.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class Category : ICategory {

        [Required]
        //[Key]
        public int CategoryId { set; get; }

        [Required]
        public string categoryName { set; get; }

        [Required]
        public string categoryDesc { set; get; }

        [Required]
        public string categoryImage { set; get; }

        [Required]
        //[ForeignKey("categoryParent")]
        public int categoryParentId { set; get; }

        //1..N ProductCategoryModel-CategoryModel
        public virtual ICollection<ProductCategory> ProductCategories { set; get; }

        //1-1 Category-Category
        public virtual Category categoryParent { set; get; }
    }
}
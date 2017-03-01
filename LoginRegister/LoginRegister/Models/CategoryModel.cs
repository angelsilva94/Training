using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class CategoryModel {
        [Required]
        [Key]
        public int categoryId { set; get; }
        [Required]
        public string categoryName { set; get; }
        [Required]
        public string categoryDesc { set; get; }
        [Required]
        public string categoryImage { set; get; }
        [Required]
        [ForeignKey("categoryModel")]
        public int categoryParentId { set; get; }
        //1..N ProductCategoryModel-CategoryModel
        public virtual ICollection<ProductCategoryModel> ProductCategoryModels { set; get; }
        //1-1 Category-Category
        public virtual CategoryModel categoryModel { set; get; }
    }
}
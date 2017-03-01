using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ProductCategoryModel {
        [Required]
        [Key]
        [ForeignKey("CategoryModel")]
        [Column(Order = 1)]
        public int categoryId { set; get; }
        [Required]
        [Key]
        [ForeignKey("ProductModel")]
        [Column(Order = 2)]
        public int productId { set; get; }
        //1..N ProductModel-ProductCategoryModel
        
        public virtual ProductModel ProductModel { set; get; }
        //1..N ProductCategoryModel-CategoryModel
        
        public virtual CategoryModel CategoryModel { set; get; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ProductModel {
        [Required]
        [Key]
        public int productId { set; get; }
        [Required]
        public string productName { set; get; }
        [Required]
        public string productDesc { set; get; }
        [Required]
        public double productPrice { set; get; }
        [Required]
        public string productUrl { set; get; }
        [Required]
        public DateTime productPublishDate { set; get; }
        [Required]
        public DateTime productModifyDate { set; get; }
        [Required]
        public bool productStatus { set; get; }
        [Required]
        public int productStock { set; get; }
        [Required]
        [ForeignKey("BrandModel")]
        public int productBrandId { set; get; }

        //N-1 ReviewModel-ProductModel
        public virtual ICollection<ReviewProductModel> ReviewProductModels { set; get; }

        //N-1 ProductModel-BrandModel
        //[ForeignKey("productBrandId")]
        public virtual BrandModel BrandModel { set; get; }
        //1..N ProductModel-ProductCategoryModel
        public virtual ICollection<ProductCategoryModel> ProductCategoryModels { set; get; }
        //1-N ProductModel-OrderProductModel
        public virtual ICollection<OrderProductModel> OrderProductModels { set; get; }

    }
}
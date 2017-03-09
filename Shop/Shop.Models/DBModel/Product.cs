using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginRegister.Models {

    public class Product : IProduct {

        [Required]
        //[Key]
        public int ProductId { set; get; }

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
        //[ForeignKey("Brand")]
        public int BrandId { set; get; }

        //N-1 ReviewModel-ProductModel
        public virtual ICollection<ReviewProduct> ReviewProducts { set; get; }

        //N-1 ProductModel-BrandModel
        //[ForeignKey("productBrandId")]
        public virtual Brand Brand { set; get; }

        //1..N ProductModel-ProductCategoryModel
        public virtual ICollection<ProductCategory> ProductCategories { set; get; }

        //1-N ProductModel-OrderProductModel
        public virtual ICollection<OrderProduct> OrderProducts { set; get; }
    }
}
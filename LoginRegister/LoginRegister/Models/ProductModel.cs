using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ProductModel {
        [Required]
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
        public int productBrand { set; get; }

        //N-1 ReviewModel-ProductModel
        public virtual ICollection<ReviewProductModel> ReviewProductModel { set; get; }

        //N-1 ProductModel-BrandModel
        public virtual BrandModel BrandModel { set; get; }
    }
}
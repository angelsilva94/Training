using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class BrandModel {
        [Required]
        public int brandId { set; get; }
        [Required]
        public string brandName { set; get; }
        [Required]
        public string brandLogoUrl { set; get; }
        [Required]
        public string brandDesc { set; get; }

        //N-1 ProductModel-BrandModel
        public virtual ICollection<ProductModel> ProductModel { set; get; }
    }
}
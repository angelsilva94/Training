using Shop.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class Brand : IBrand {

        //[Required]
        //[Key]
        public int BrandId { set; get; }

        [Required]
        public string brandName { set; get; }

        [Required]
        public string brandLogoUrl { set; get; }

        [Required]
        public string brandDesc { set; get; }

        //N-1 ProductModel-BrandModel
        //public virtual ICollection<Product> Products { set; get; }
    }
}
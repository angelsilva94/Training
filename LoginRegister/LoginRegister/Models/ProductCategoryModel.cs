using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ProductCategoryModel {
        [Required]
        string categoryName { set; get; }
        [Required]
        string productId { set; get; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class CategoryModel {
        [Required]
        string categoryName { set; get; }
        [Required]
        string categoryDesc { set; get; }
        [Required]
        string categoryImage { set; get; }
        [Required]
        string categoryParent { set; get; }
    }
}
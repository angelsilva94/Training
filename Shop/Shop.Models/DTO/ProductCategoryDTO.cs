using Shop.Models.DBModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DTO {
    public class ProductCategoryDTO {
        public int ProductCategoryId { set; get; }
        public int CategoryId { set; get; }
        public int ProductId { set; get; }
        //public ProductDTO Product { set; get; }
        //public CategoryDTO Category { set; get; }
    }
}

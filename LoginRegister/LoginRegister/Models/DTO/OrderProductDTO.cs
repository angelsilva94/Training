using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRegister.Models.DTO {
    public class OrderProductDTO {
        public int OrderProductId { set; get; }
        public int ProductId { set; get; }
        public int OrderId { set; get; }
        public /*ICollection<ProductDTO>*/ ProductDTO Product { set; get; }
    }
}
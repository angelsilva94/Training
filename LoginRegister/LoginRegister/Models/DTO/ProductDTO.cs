using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRegister.Models.DTO {
    public class ProductDTO {
        public int ProductId { set; get; }
        public string productName { set; get; }
        public string productDesc { set; get; }
        public double productPrice { set; get; }
    }
}
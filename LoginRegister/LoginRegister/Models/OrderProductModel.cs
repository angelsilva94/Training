using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderProductModel {
        [Required]
        public int orderProductId { set; get; }
        //fk key
        [Required]
        public int productId { set; get; }
        [Required]
        //fk
        public int OrderId { set; get; }    

    }
}
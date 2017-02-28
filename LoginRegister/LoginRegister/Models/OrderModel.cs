using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderModel {
        [Required]
        public int orderId { set; get; }
        [Required]
        public DateTime purchaseDate { set; get; }
        [Required]
        public int orderStatusCode{ set; get; }
        [Required]
        public int quantityOrder { set; get; }
        [Required]
        public int totalOrderPrice { set; get; }
    }
}
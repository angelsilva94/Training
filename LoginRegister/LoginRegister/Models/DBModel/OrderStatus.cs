using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderStatus {
        [Required]
        //[Key]
        public int OrderStatusId { set; get; }
        [Required]
        public int orderStatusCod{ set; get; }
        [Required]
        public string orderStatusDesc { set; get; }

        //N-1 OrderModel-OrderProductModel

        public virtual ICollection<Order> Orders { set; get; }
    }
}
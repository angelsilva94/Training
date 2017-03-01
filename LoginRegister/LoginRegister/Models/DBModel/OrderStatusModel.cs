using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderStatusModel {
        [Required]
        [Key]
        public int orderStatusCod{ set; get; }
        public string orderStatusDesc { set; get; }

        //N-1 OrderModel-OrderProductModel

        public virtual ICollection<OrderModel> OrderModels { set; get; }
    }
}
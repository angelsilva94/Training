using Shop.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class OrderStatus : IOrderStatus {

        //[Required]
        ////[Key]
        //public int OrderStatusId { set; get; }
        [Required, Key]
        public int orderStatusCod { set; get; }

        [Required]
        public string orderStatusDesc { set; get; }

        //N-1 OrderModel-OrderProductModel

        public virtual ICollection<Order> Orders { set; get; }
    }
}
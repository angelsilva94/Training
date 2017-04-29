using Shop.Models.DBModel;
using System;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {

    public interface IOrder {
        int OrderId { get; set; }
        ICollection<OrderDetail> OrderDetails { get; set; }
        OrderStatus OrderStatus { get; set; }
        int orderStatusCode { get; set; }
        DateTime purchaseDate { get; set; }

        //int quantityOrder { get; set; }
        double totalOrderPrice { get; set; }

        User User { get; set; }
        int UserId { get; set; }
    }
}
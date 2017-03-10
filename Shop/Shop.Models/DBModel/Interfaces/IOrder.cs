using System;
using System.Collections.Generic;

namespace LoginRegister.Models {

    public interface IOrder {
        int OrderId { get; set; }
        ICollection<OrderProduct> OrderProducts { get; set; }
        OrderStatus OrderStatus { get; set; }
        int orderStatusCode { get; set; }
        DateTime purchaseDate { get; set; }
        int quantityOrder { get; set; }
        double totalOrderPrice { get; set; }
        User User { get; set; }
        int UserId { get; set; }
    }
}
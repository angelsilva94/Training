using Shop.Models.DBModel;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {

    public interface IOrderStatus {
        ICollection<Order> Orders { get; set; }
        int orderStatusCod { get; set; }
        string orderStatusDesc { get; set; }
    }
}
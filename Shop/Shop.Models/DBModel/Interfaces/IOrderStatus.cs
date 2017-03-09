using System.Collections.Generic;

namespace LoginRegister.Models {
    public interface IOrderStatus {
        ICollection<Order> Orders { get; set; }
        int orderStatusCod { get; set; }
        string orderStatusDesc { get; set; }
    }
}
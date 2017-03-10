using System;
using System.Collections.Generic;

namespace Shop.Models.DBModel.DTO {

    public class OrderDTO {
        public int OrderId { set; get; }
        public int UserId { set; get; }

        public DateTime purchaseDate { set; get; }

        public int orderStatusCode { set; get; }

        public int quantityOrder { set; get; }

        public double totalOrderPrice { set; get; }

        //public int UserId { set; get; }

        public ICollection<OrderProductDTO> OrderProducts { set; get; }

        public UserDTO User { set; get; }
    }
}
using System.Collections.Generic;

namespace Shop.Models.DBModel.Interfaces {
    interface IAddress {
        int AddressId { get; set; }
        string adress { get; set; }
        string city { get; set; }
        string country { get; set; }
        string street { get; set; }
        string zip { get; set; }
        ICollection<Order> Orders { set; get; }

    }
}
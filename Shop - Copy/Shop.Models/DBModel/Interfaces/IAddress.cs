using Shop.Models.DBModel;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {
    public interface IAddress {
        int AddressId { get; set; }
        string adress { get; set; }
        string city { get; set; }
        string country { get; set; }
        ICollection<Order> Orders { get; set; }
        string street { get; set; }
        User User { get; set; }
        int UserId { get; set; }
        string zip { get; set; }
    }
}
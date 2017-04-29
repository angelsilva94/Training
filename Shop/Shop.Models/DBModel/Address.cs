using Shop.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class Address : IAddress {
        public int AddressId { set; get; }

        [Required]
        public string street { set; get; }

        [Required]
        public string adress { set; get; }

        [Required]
        public string country { set; get; }

        [Required]
        public string city { set; get; }

        [Required]
        public string zip { set; get; }

        [Required]
        public int UserId { set; get; }

        public virtual User User { set; get; }

        public virtual ICollection<Order> Orders { set; get; }
    }
}
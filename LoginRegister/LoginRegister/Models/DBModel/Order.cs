using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class Order {
        [Required]
        //[Key]
        public int OrderId { set; get; }
        [Required]
        public DateTime purchaseDate { set; get; }
        [Required]
        public int orderStatusCode{ set; get; }
        [Required]
        public int quantityOrder { set; get; }
        [Required]
        public int totalOrderPrice { set; get; }
        [Required]
        //[ForeignKey("User")]
        public int UserId { set; get; }
        [Required]
        public string orderUsername{ set; get; }
        //N-1 OrderModel-OrderProductModel
        public virtual ICollection<OrderProduct> OrderProducts { set; get; }
        //1-N UserModel-OrderModel
        //[ForeignKey("orderUsername")]
        public virtual User User { set; get; }
    }
}
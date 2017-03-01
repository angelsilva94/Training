using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderModel {
        [Required]
        [Key]
        public int orderId { set; get; }
        [Required]
        public DateTime purchaseDate { set; get; }
        [Required]
        public int orderStatusCode{ set; get; }
        [Required]
        public int quantityOrder { set; get; }
        [Required]
        public int totalOrderPrice { set; get; }
        [Required]
        [ForeignKey("UserModel")]
        public string orderUsername{ set; get; }
        //N-1 OrderModel-OrderProductModel
        public virtual ICollection<OrderProductModel> OrderProductModels { set; get; }
        //1-N UserModel-OrderModel
        //[ForeignKey("orderUsername")]
        public virtual UserModel UserModel { set; get; }
    }
}
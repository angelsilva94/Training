using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class OrderProductModel {
        [Required]
        [Key]
        public int orderProductId { set; get; }
        //fk key
        [Required]
        [ForeignKey("ProductModel")]
        public int productId { set; get; }
        [Required]
        [ForeignKey("OrderModel")]
        //fk
        public int orderId { set; get; }

        //1-N ProductModel-OrderProductModel
        //[ForeignKey("productId")]
        public virtual ProductModel ProductModel { set; get; }

        //1-N OrderModel-OrderProductModel
        //[ForeignKey("orderId")]
        public virtual OrderModel OrderModel { set; get; }

    }
}
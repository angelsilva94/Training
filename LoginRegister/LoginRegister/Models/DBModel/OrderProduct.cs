using System.ComponentModel.DataAnnotations;

namespace LoginRegister.Models {

    public class OrderProduct {

        //[Required]
        //[Key]
        public int OrderProductId { set; get; }

        //fk key
        [Required]
        //[ForeignKey("Product")]
        public int ProductId { set; get; }

        [Required]
        //[ForeignKey("Order")]
        //fk
        public int OrderId { set; get; }

        //1-N ProductModel-OrderProductModel
        //[ForeignKey("productId")]
        public virtual Product Product { set; get; }

        //1-N OrderModel-OrderProductModel
        //[ForeignKey("orderId")]
        public virtual Order Order { set; get; }
    }
}
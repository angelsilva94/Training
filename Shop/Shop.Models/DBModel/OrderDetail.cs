using Shop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class OrderDetail : IOrderDetail {

        //[Required]
        //[Key]
        public int OrderDetailId { set; get; }

        //fk key
        [Required]
        //[ForeignKey("Product")]
        public int ProductId { set; get; }

        [Required]
        //[ForeignKey("Order")]
        //fk
        public int OrderId { set; get; }

        [Required]
        public int quantityOrder { set; get; }

        //1-N ProductModel-OrderProductModel
        //[ForeignKey("productId")]
        public virtual Product Product { set; get; }

        //1-N OrderModel-OrderProductModel
        //[ForeignKey("orderId")]
        public virtual Order Order { set; get; }
    }
}
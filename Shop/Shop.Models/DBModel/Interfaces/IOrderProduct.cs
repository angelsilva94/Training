using Shop.Models.DBModel;

namespace Shop.Models.Interfaces {

    public interface IOrderProduct {
        Order Order { get; set; }
        int OrderId { get; set; }
        int OrderProductId { get; set; }
        Product Product { get; set; }
        int ProductId { get; set; }
    }
}
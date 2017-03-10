using Shop.Models.DBModel;

namespace Shop.Models.Interfaces {

    public interface IOrderDetail {
        Order Order { get; set; }
        int OrderId { get; set; }
        int OrderDetailId { get; set; }
        Product Product { get; set; }
        int ProductId { get; set; }
    }
}
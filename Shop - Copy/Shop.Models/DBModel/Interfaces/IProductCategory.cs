using Shop.Models.DBModel;

namespace Shop.Models.Interfaces {

    public interface IProductCategory {
        Category Category { get; set; }
        int CategoryId { get; set; }
        Product Product { get; set; }
        int ProductId { get; set; }
    }
}
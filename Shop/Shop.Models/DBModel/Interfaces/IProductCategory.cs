namespace LoginRegister.Models {

    public interface IProductCategory {
        Category Category { get; set; }
        int CategoryId { get; set; }
        Product Product { get; set; }
        int ProductId { get; set; }
    }
}
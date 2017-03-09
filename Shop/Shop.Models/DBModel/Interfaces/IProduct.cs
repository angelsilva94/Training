using System;
using System.Collections.Generic;

namespace LoginRegister.Models {
    public interface IProduct {
        Brand Brand { get; set; }
        int BrandId { get; set; }
        ICollection<OrderProduct> OrderProducts { get; set; }
        ICollection<ProductCategory> ProductCategories { get; set; }
        string productDesc { get; set; }
        int ProductId { get; set; }
        DateTime productModifyDate { get; set; }
        string productName { get; set; }
        double productPrice { get; set; }
        DateTime productPublishDate { get; set; }
        bool productStatus { get; set; }
        int productStock { get; set; }
        string productUrl { get; set; }
        ICollection<ReviewProduct> ReviewProducts { get; set; }
    }
}
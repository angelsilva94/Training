using Shop.Models.DBModel;
using System;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {

    public interface IProduct {
        Brand Brand { get; set; }
        int BrandId { get; set; }
        ICollection<OrderDetail> OrderDetails { get; set; }
        //ICollection<ProductCategory> ProductCategories { get; set; }
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
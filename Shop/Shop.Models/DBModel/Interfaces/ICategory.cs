using Shop.Models.DBModel;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {

    public interface ICategory {
        string categoryDesc { get; set; }
        int CategoryId { get; set; }
        string categoryImage { get; set; }
        string categoryName { get; set; }
        Category categoryParent { get; set; }
        int categoryParentId { get; set; }
        ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
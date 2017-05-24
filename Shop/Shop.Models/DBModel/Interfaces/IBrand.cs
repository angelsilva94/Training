using Shop.Models.DBModel;
using System.Collections.Generic;

namespace Shop.Models.Interfaces {

    public interface IBrand {
        string brandDesc { get; set; }
        int BrandId { get; set; }
        string brandLogoUrl { get; set; }
        string brandName { get; set; }
        //ICollection<Product> Products { get; set; }
    }
}
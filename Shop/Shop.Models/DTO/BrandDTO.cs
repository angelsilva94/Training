using Shop.Models.DBModel.DTO;
using System.Collections.Generic;

namespace Shop.Models.DTO {

    public class BrandDTO {
        public int BrandId { set; get; }
        public string brandName { set; get; }
        public string brandLogoUrl { set; get; }
        public string brandDesc { set; get; }
        public ICollection<ProductDTO> Products { set; get; }
    }
}
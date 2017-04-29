using System.Collections.Generic;

namespace Shop.Models.DTO {

    public class CategoryDTO {
        public int CategoryId { set; get; }
        public string categoryName { set; get; }
        public string categoryDesc { set; get; }
        public string categoryImage { set; get; }
        public int? categoryParentId { set; get; }
        public ICollection<ProductCategoryDTO> ProductCategories { set; get; }
        public CategoryDTO categoryParent { set; get; }
    }
}
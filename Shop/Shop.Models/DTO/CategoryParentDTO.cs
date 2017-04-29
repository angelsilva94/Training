using System.Collections.Generic;

namespace Shop.Models.DTO {

    internal class CategoryParentDTO {
        public int categoryParentId { set; get; }
        public ICollection<ProductCategoryDTO> ProductCategories { set; get; }
        public CategoryDTO categoryParent { set; get; }
        public ICollection<CategoryDTO> childrenCategory { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DTO {
    class CategoryParentDTO {
        public int categoryParentId { set; get; }
        public ICollection<ProductCategoryDTO> ProductCategories { set; get; }
        public CategoryDTO categoryParent { set; get; }
        public ICollection<CategoryDTO> childrenCategory { get; set; }
    }
}

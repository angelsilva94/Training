using Shop.Models.DBModel;
using Shop.Models.DBModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DTO {
    public class ReviewProductDTO {
        public ProductDTO Product { set; get; }
        public int ProductId { set; get; }
        public double ratingReview { set; get; }
        public string reviewDesc { set; get; }
        public int ReviewProductIdNumber { set; get; }
        public UserDTO User { set; get; }
        public int UserId { set; get; }
    }
}

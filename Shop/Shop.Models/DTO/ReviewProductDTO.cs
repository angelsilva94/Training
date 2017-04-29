using Shop.Models.DBModel.DTO;

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
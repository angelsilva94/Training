using Shop.Models.DBModel;

namespace Shop.Models.Interfaces {

    public interface IReviewProduct {
        Product Product { get; set; }
        int ProductId { get; set; }
        double ratingReview { get; set; }
        string reviewDesc { get; set; }
        int ReviewProductIdNumber { get; set; }
        User User { get; set; }
        int UserId { get; set; }
    }
}
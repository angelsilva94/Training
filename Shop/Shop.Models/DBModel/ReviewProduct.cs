using Shop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.DBModel {

    public class ReviewProduct : IReviewProduct {

        [Key]
        public int ReviewProductIdNumber { set; get; }

        [Required]
        [ForeignKey("Product")]
        [Column(Order = 1)]
        public int ProductId { set; get; }

        [Required]
        public double ratingReview { set; get; }

        [Required]
        [ForeignKey("User")]
        [Column(Order = 2)]
        public int UserId { set; get; }

        //[Required]
        //public string reviewUsername { set; get; }
        [Required]
        public string reviewDesc { set; get; }

        //1-N UserModel-ReviewModel
        //[ForeignKey("reviewUsername")]
        public virtual User User { set; get; }

        //N-1 ReviewModel-ProductModel
        //[ForeignKey("productId")]
        public virtual Product Product { set; get; }
    }
}
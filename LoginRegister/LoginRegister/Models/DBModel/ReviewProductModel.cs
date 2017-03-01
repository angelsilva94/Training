using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ReviewProductModel {
        [Required]
        public int reviewId { set; get; }
        [Required]
        [Key]
        [ForeignKey("ProductModel")]
        [Column(Order = 1)]
        public int productId { set; get; }
        [Required]
        public int ratingReview { set; get; }
        [Required]
        [Key]
        [ForeignKey("UserModel")]
        [Column(Order = 2)]
        public string reviewUsername { set; get; }
        [Required]
        public string reviewDesc { set; get; }
        //1-N UserModel-ReviewModel
        //[ForeignKey("reviewUsername")]
        public virtual UserModel UserModel { set; get; }
        //N-1 ReviewModel-ProductModel
        //[ForeignKey("productId")]
        public virtual ProductModel ProductModel { set; get; }
    }
}
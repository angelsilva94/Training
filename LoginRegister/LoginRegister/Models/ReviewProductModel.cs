using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ReviewProductModel {
        [Required]
        public int reviewId { set; get; }
        [Required]
        public int productId { set; get; }
        [Required]
        public int ratingReview { set; get; }
        [Required]
        public string reviewUsername { set; get; }
        [Required]
        public string reviewDesc { set; get; }

        //1-N UserModel-ReviewModel
        public virtual UserModel UserModel { set; get; }
        //N-1 ReviewModel-ProductModel
        public virtual ProductModel ProductModel { set; get; }
    }
}
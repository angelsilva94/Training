using Shop.Models.DBModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginRegister.Models {

    public class User : IUser {
        public int UserId { set; get; }

        [Required]
        public string username { set; get; }

        [Required]
        public string password { set; get; }

        [Required]
        public string name { set; get; }

        [Required]
        public string email { set; get; }

        [Required]
        public string surname { set; get; }

        [Required]
        public string lastName { set; get; }

        [Required]
        public int age { set; get; }

        [Required]
        public DateTime regDate { set; get; }

        [Required]
        public bool userType { set; get; }

        //we define our relationships
        //1-1 UserModel-UserInfo
        public virtual UserInfo UserInfo { set; get; }

        //1-N UserModel-ReviewModel
        public virtual ICollection<ReviewProduct> ReviewProducts { get; set; }

        //1-N UserModel-OrderModel
        public virtual ICollection<Order> Orders { get; set; }
    }
}
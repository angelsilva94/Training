using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginRegister.Models {
    public class UserModel {
        [Key]
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
    }
}
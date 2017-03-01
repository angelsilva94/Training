using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class UserInfoModel {
        [Key,ForeignKey("UserModel")]
        [Required]
        public string username { set; get; }
        [Required]
        public string phone{ set; get; }
        [Required]
        public string adress { set; get; }
        [Required]
        public string country { set; get; }
        [Required]
        public string city { set; get; }
        [Required]
        public string zip { set; get; }

        //we define our relationships 
        //1-1 UserModel-UserInfo
        
        public virtual UserModel UserModel { set; get; }
    }
}
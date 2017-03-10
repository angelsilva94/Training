using Shop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.DBModel {

    public class UserInfo : IUserInfo {

        //public int UserInfoId { set; get; }
        //[ForeignKey("User")]
        [Key, ForeignKey("User")]
        public int UserId { set; get; }

        //[Required]
        //public string username { set; get; }
        [Required]
        public string phone { set; get; }

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

        public virtual User User { set; get; }
    }
}
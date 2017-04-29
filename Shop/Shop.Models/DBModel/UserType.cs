using Shop.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class UserType : IUserType {
        public int UserTypeId { set; get; }

        [Required]
        public string type { set; get; }

        [Required]
        public string typeDesc { set; get; }

        public int UserId { set; get; }

        public virtual User User { set; get; }
    }
}
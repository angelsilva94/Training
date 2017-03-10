using System.ComponentModel.DataAnnotations;

namespace Shop.Models.DBModel {

    public class UserCredentials {
        public int UserCredentialsId { set; get; }

        [Required]
        public string username { set; get; }

        [Required]
        public string password { set; get; }

        public virtual User User { set; get; }
    }
}
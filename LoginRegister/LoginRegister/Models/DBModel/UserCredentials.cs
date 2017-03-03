using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginRegister.Models.DBModel {
    public class UserCredentials {
        public int UserCredentialsId { set; get; } 
        [Required]
        public string username { set; get; }
        [Required]
        public string password { set; get; }

        public virtual User User { set; get; }
    }
}
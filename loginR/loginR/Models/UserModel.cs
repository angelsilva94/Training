using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace loginR.Models {
    public class UserModel {
        [Key]
        string Username { set; get; }
        string Pwd { set; get; }
        string Name { set; get; }
        string Email { set; get; }
        string Surname { set; get; }
        string LastName { set; get; }
        int Age { set; get; }
        DateTime RegDate { set; get; }
        bool UserType { set; get; }
    }
}
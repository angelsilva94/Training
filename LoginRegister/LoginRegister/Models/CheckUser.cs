using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class CheckUser {
        public bool login(string usr,string pwd) {
            using (ShopDBContext db = new ShopDBContext()) {
                return db.UsersModel.Any(user =>
                user.username.Equals(usr) && user.password == pwd);
            }
          
        }
    }
}
using Shop.Authentication;
using Shop.DAL;
using System.Linq;

namespace LoginRegister.Models {

    public class CheckUser : ICheckUser {

        public bool login(string usr, string pwd) {
            using (ShopDBContext db = new ShopDBContext()) {
                return db.User.Any(user => user.username.Equals(usr) && user.password == pwd);
            }
        }
    }
}
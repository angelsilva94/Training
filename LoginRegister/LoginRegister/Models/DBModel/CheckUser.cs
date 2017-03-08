using System.Linq;

namespace LoginRegister.Models {

    public class CheckUser {

        public bool login(string usr, string pwd) {
            using (ShopDBContext db = new ShopDBContext()) {
                return db.User.Any(user =>
                user.username.Equals(usr) && user.password == pwd);
            }
        }
    }
}
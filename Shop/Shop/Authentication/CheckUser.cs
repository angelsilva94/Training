using Shop.Authentication;
using System.Linq;

namespace LoginRegister.Models {

    public class CheckUser : ICheckUser {

        public bool login(string usr, string pwd) {
            using (ShopDBContext db = new ShopDBContext()) {
                return db.User.Any(user => user.username.Equals(usr) && user.password == pwd);
            }
        }

        public object idUser(string usr) {
            using (ShopDBContext db = new ShopDBContext()) {
                return db.User.Where(x => x.username == usr).Select(x => new { x.UserId,x.name,x.surname,x.lastName,x.regDate}).FirstOrDefault();
            }
        }
    }
}
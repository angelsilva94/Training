using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DBModel {
    public interface IUser {
        int UserId { set; get; }
        string username { set; get; }
        string password { set; get; }
        string name { set; get; }
        string email { set; get; }
        string surname { set; get; }
        string lastName { set; get; }
        int age { set; get; }
        DateTime regDate { set; get; }
        bool userType { set; get; }
        UserInfo UserInfo { set; get; }
        ICollection<ReviewProduct> ReviewProducts { get; set; }
        ICollection<Order> Orders { get; set; }
    }
}

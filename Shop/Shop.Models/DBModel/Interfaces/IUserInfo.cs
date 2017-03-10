using LoginRegister.Models;

namespace Shop.Models.DBModel.Interfaces {

    public interface IUserInfo {
        int UserId { set; get; }
        string phone { set; get; }
        string adress { set; get; }
        string country { set; get; }
        string city { set; get; }
        string zip { set; get; }
        User User { set; get; }
    }
}
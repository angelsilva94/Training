using Shop.Models.DBModel;

namespace Shop.Models.Interfaces {

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
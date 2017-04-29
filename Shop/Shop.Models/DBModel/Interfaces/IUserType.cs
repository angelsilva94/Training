using Shop.Models.DBModel;

namespace Shop.Models.Interfaces {

    public interface IUserType {
        string type { get; set; }
        string typeDesc { get; set; }
        User User { get; set; }
        int UserTypeId { get; set; }
    }
}
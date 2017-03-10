namespace Shop.Models.Interfaces {

    public interface IModifyUserModel {
        string curPassword { get; set; }
        string newPassword { get; set; }
        string username { get; set; }
    }
}
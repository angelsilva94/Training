namespace LoginRegister.Models {
    public interface IAddUserInfo {
        string adress { get; set; }
        string city { get; set; }
        string country { get; set; }
        string phone { get; set; }
        string username { get; set; }
        string zip { get; set; }
    }
}
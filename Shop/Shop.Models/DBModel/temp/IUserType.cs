namespace Shop.Models.DBModel.Interfaces {
    public interface IUserType {
        string type { get; set; }
        string typeDesc { get; set; }
        User User { get; set; }
        int UserId { get; set; }
        
    }
}
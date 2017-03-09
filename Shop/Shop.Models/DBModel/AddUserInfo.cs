namespace LoginRegister.Models {

    public class AddUserInfo : IAddUserInfo {
        public string username { set; get; }
        public string phone { set; get; }
        public string adress { set; get; }
        public string country { set; get; }
        public string city { set; get; }
        public string zip { set; get; }
    }
}
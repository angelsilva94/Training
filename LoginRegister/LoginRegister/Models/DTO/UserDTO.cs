using System;

namespace LoginRegister.Models.DTO {

    public class UserDTO {
        public int UserId { set; get; }

        public string username { set; get; }

        public string password { set; get; }

        public string name { set; get; }

        public string email { set; get; }

        public string surname { set; get; }

        public string lastName { set; get; }

        public int age { set; get; }

        public DateTime regDate { set; get; }

        public bool userType { set; get; }
        public UserInfoDTO userInfo { set; get; }
    }
}
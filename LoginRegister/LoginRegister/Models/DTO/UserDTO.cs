using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRegister.Models.DTO {
    public class UserDTO {
        public int id { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string name { set; get; }
        public string email { set; get; }
        public string surname { set; get; }
        public string lastName { set; get; }
        public int age { set; get; }
        public DateTime regDate { set; get; }
        public bool userType { set; get; }
        public ICollection<UserInfoDTO> userInfo { set; get; }
        
    }
}
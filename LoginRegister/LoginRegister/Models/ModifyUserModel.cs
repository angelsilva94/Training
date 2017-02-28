using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class ModifyUserModel {
        public string curPassword { set; get; }
        public string newPassword { set; get; }
        public string username { set; get; }
    }
}
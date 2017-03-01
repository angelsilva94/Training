using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginRegister.Models {
    public class AddUserInfoModel {
       
        public string username { set; get; }
        
        public string phone { set; get; }
        
        public string adress { set; get; }
        
        public string country { set; get; }
        
        public string city { set; get; }
        
        public string zip { set; get; }
    }
}
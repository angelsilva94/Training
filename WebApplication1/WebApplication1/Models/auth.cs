using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models {
    public class auth {
        String usernameId { set; get; }
        String pwd { set; get; }
        String email { set; get; }
        DateTime registerDate { set; get; }
        bool userType { set; get; }
    }
}
using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DBModel.Interfaces {
    interface IUserInfo {
        int UserId { set; get; }
        string phone { set; get; }
        string adress { set; get; }
        string country { set; get; }
        string city { set; get; }
        string zip { set; get; }
        User User { set; get; }
    }
}

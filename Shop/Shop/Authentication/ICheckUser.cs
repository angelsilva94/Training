using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Authentication {
    interface ICheckUser {
        bool login(string usr, string pwd);
    }
}

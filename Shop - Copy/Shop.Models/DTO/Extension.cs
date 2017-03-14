using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.DTO {
   public static class Extension {
        public static bool Check(this string s) {
            return s.Length > 10 ? true:false;
        }
    }
}

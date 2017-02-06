using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Libraries {
    public class ValidatorBin : IProblem {
        public int number { set; get; }
        public bool Val(out ErrorDispose e) {
            e = new ErrorDispose();
            if (number > 2147483647) {
                e.ErrorCode = 1;
                e.ErrorDesc = "numero muy grande";
                return false;
            }else if (number < 0) {
                e.ErrorCode = 1;
                e.ErrorDesc = "no puedes poner 0";
                return false;
            } else {
                e = null;
                return true;
            }
        }
    }
}

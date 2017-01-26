using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threeN.Validator{
    public class Validator{
        public int i { set; get; }
        public int j { set; get; }
        public Validator(int x, int y) {
            this.i = x;
            this.j = y;
            Val();
        }
        public Boolean Val() {
            if (i < 1 || i>10000 || j<1  || j>10000) {
                return false;
            }
            return true;
        }
        
    }
}

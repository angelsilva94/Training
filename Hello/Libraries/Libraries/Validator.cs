using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace threeN.Validator{
    public class Validator{
        public int i { set; get; }
        public int j { set; get; }
        public Validator(int x, int y) {
            this.i = x;
            this.j = y;
        }
        public Boolean Val(out ErrorDispose e) {
            e = new ErrorDispose();
            if (i < 1 ) {
                e.ErrorCode = 1;
                e.ErrorDesc = "Error en la I";
                return false;
            } else if (i > 10000) {
                e.ErrorCode = 2;
                e.ErrorDesc = "Error en la I>";
                return false;
            } else if (j < 1) {
                e.ErrorCode = 3;
                e.ErrorDesc = "Error en la J";
                return false;
                e.ErrorCode = 2;
            } else if (j > 10000) {
                e.ErrorCode = 4;
                e.ErrorDesc = "Error en la J>";
                return false;
                e.ErrorCode = 2;
            } 
            else {
                e = null;
                return true;
            }
            
        }
        
    }
}

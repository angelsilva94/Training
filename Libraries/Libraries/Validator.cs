using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threeN.Validator{
    public class Validator{
        public int i { set; get; }
        public int j { set; get; }
        public Validator() {
            Val();
        }
        public Boolean Val() {
            if(i >10000 || j > 10000 || i<0 || j<0) {
                return false;
            }
            return true;
        }
        public void Ask(int x,int y) {
            Console.WriteLine("Give me the first number and second number :");
            i = int.Parse(Console.ReadLine());
            j =  int.Parse(Console.ReadLine());
        }

    }
}

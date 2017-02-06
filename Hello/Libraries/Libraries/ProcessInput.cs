using Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threeN.Process {
    public class ProcessInput : IProcessInput {
        public List<int> result = new List<int>();
        int i { set; get; }
        int j { set; get; }
        public ProcessInput(int x, int y) {
            this.i = x;
            this.j = y;
        }

        public int Process() {
            int cont = 0;
            do {
                if (j != 1) {
                    result.Add(j);

                    if (j % 2 != 0) {
                        j = (j * 3) + 1;
                    } else {
                        j /= 2;
                    }
                    cont++;

                }
            } while (j != 1);
            result.Add(j);
            return cont;
        }
        public override string ToString() {
            return "test";
        }


    }
}

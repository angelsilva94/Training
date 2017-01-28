using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinPacking {
    public class Rec {
        int[] brown, green, clear;
        int sum = 0, min = 0;
        public char[] bottles = new char[3];
        public Rec(int[] b, int[] c, int[] g) {
            this.brown = b;
            this.clear = c;
            this.green = g;
            max();
        }

        private void max() {
            for (int i = 0; i < 3; i++) {
                sum += brown[i] + clear[i] + green[i];
                for (int j = 0; j < 3; j++) {
                    for (int k = 0; k < 3; k++) {
                        if (i == j || j == k || k == i) {
                            continue;
                        }
                        if (brown[i] + clear[j] + green[k] > min) {
                            min = brown[i] + clear[j] + green[k];
                            bottles[i] = 'B'; bottles[j] = 'C'; bottles[k] = 'G';
                        }
                    }
                }
            }
        }
        public int getM() {
            return sum - min;
        }
    }
}

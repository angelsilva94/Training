using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinPacking;

namespace Bin_Packing {
    class Program {
        static void Main(string[] args) {
            // 3!=6 comb BCG,BGC,CBG,CGB,GBC,GCB
            int[] brown = new int[3];
            int[] clear = new int[3];
            int[] green = new int[3];
            for (int i = 0; i < 3; i++) {
                brown[i] = int.Parse(Console.ReadLine());
                clear[i] = int.Parse(Console.ReadLine());
                green[i] = int.Parse(Console.ReadLine());
            }
            Rec r = new Rec(brown, clear, green);
            foreach(char c in r.bottles) {
                Console.Write(c);
            }
            Console.WriteLine(r.getM());
            Console.ReadKey();
        }       
    }
}



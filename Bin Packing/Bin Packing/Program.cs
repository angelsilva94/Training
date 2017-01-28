using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin_Packing {
    class Program {
        static void Main(string[] args) {
            int [] brown = new int[3];
            int [] green = new int[3];
            int [] clear = new int[3];
            for(int i = 0; i < 3; i++) {
                brown[i] = int.Parse(Console.ReadLine());
                green[i] = int.Parse(Console.ReadLine());
                clear[i] = int.Parse(Console.ReadLine());
            }

            Rec r= new Rec(brown,green,clear);
            r.getBottles();
            Console.WriteLine(r.getMost());
            Console.ReadKey();
        }
    }
}

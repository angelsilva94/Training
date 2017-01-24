using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//

namespace Bin_Packing {
    class Program {
        static String res = "";
        static int min ;
        static int aux ;
        static int[] B = new int[3];
        static int[] C = new int[3];
        static int[] G = new int[3];
        static void Main(string[] args) {
            ///*
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
            r.getSol();
            Console.WriteLine(r.getMost());
            Console.ReadKey();//*/
        }

            /* manual testing*/

            /*
            

            for (int i = 0; i < 3; i++) {
                B[i] = int.Parse(Console.ReadLine());
                C[i] = int.Parse(Console.ReadLine());
                G[i] = int.Parse(Console.ReadLine());
            }
            //Sol();
            Console.ReadKey();
        }
        public static void Sol() {
            //BCG
            min = B[1] + B[2] + C[0] + C[2] + G[0] + G[1];
            res = "BCG";
            aux = B[1] + B[2] + G[0] + G[2] + C[0] + C[1];
            //BGC
            if (min > aux) {
                min = aux;
                res = "BGC";
            }
            aux = C[1] + C[2] + B[0] + B[2] + G[0] + G[1]; 
            // CBG
            if (min > aux) {
                min = aux;
                res = "CBG";
            }
            aux = C[1] + C[2] + G[0] + G[2] + B[0] + B[1]; 
            // CGB
            if (min > aux) {
                min = aux;
                res = "CGB";
            }
            aux = G[1] + G[2] + B[0] + B[2] + C[0] + C[1]; 
            // GBC
            if (min > aux) {
                min = aux;
                res = "GBC";
            }
            aux = G[1] + G[2] + C[0] + C[2] + B[0] + B[1]; 
            // GCB
            if (min > aux) {
                min = aux;
                res = "GCB";
            }
            Console.WriteLine(min+" "+res);
        }*/
        
    }
}



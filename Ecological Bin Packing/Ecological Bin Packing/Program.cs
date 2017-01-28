using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecological_Bin_Packing {

    /*
     *
     * brown glass, green glass, and clear glass, 3 reclycing bins with the amount of bottles, you need to move them so each bin only 
     * contains one color 
     * */
    class Program {
        static void Main(string[] args) {
            String chain;
            int min;
            Bin bin1 = new Bin();
            Bin bin2 = new Bin();
            Bin bin3 = new Bin();
            Console.WriteLine("Give me all the bottles of the 3 bins");
            chain = Console.ReadLine();
            string[] tokens = chain.Split(' ');
            int[] numbers = Array.ConvertAll(tokens, int.Parse);

            bin1.brown = numbers[0];
            bin1.green = numbers[1];
            bin1.clear = numbers[2];

            bin2.brown = numbers[3];
            bin2.green = numbers[4];
            bin2.clear = numbers[5];

            bin3.brown = numbers[6];
            bin3.green = numbers[7];
            bin3.clear = numbers[8];

            Console.WriteLine(bin2.brown);
            Console.ReadKey();
            string[] comb = new string[] { "BCG", "BGC", "CBG","CGB", "GBC", "GCB" };
            min = bin2.brown+bin3.brown+bin1.clear+ bin1.green+bin2.green//BCG
            
            //smallest = B[1] + B[2] + C[0] + C[2] + G[0] + G[1]; // BCG
            first = 'B'; second = 'C'; third = 'G';
            tmp = B[1] + B[2] + G[0] + G[2] + C[0] + C[1]; // BGC
            if (tmp < smallest) {
                smallest = tmp;
                first = 'B'; second = 'G'; third = 'C';
            }






        }

    }
}

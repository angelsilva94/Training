using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3n_1{
    class Program{
        static void Main(string[] args){
            int numb;
            int cont = 0;
            Console.WriteLine("Give me a number:");
            numb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The number is: " + numb);
            do {
                if (numb != 1) {
                    if (numb % 2 != 0) {
                        numb = (numb * 3) + 1;
                        //numb *= 3 + 1;
                    } else {
                        numb /= 2;
                    }
                    cont++;
                    
                }

            } while (numb != 1);
            Console.WriteLine("The number is: " + cont);
            Console.WriteLine("Pres any key to exit");
            Console.ReadKey();
        }
    }
}

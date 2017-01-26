using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using threeN.Validator;
using threeN.Process;
using Models;
namespace _3n_1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Give me the first number and second number :");
            Validator val = new Validator(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            ErrorDispose errorResponse;
            if (val.Val(out errorResponse)) {
                ProcessInput PI = new ProcessInput(val.i, val.j);
                int res = PI.ProcessNumber();
                Console.WriteLine(val.i + " " + val.j + " " + res);
                foreach (var l in PI.result) {
                    Console.WriteLine(l);
                }
            } else {
                Console.WriteLine("El codigo del error es: " + errorResponse.ErrorCode + " " + errorResponse.ErrorDesc);
            }
            Console.ReadKey();
        }
    }
}

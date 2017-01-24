using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks_Problem {
    class Program {
        static void Main(string[] args) {
            int op;
            Console.WriteLine("Welcome");
            Console.WriteLine("Give me the lenght of the block:");
            //numb = int.Parse(Console.ReadLine());
            Block obj = new Block(int.Parse(Console.ReadLine()));
            do {
                Console.WriteLine("What do you wanna do?");
                Console.WriteLine("Move a onto b....press 1");
                Console.WriteLine("Move a over b....press 2");
                Console.WriteLine("Pile a onto b....press 3");
                Console.WriteLine("Pile a over b....press 4");
                Console.WriteLine("Quit.............press 5");
                op = int.Parse(Console.ReadLine());
                switch (op) {
                    case 1:
                        obj.Ask();
                        obj.MoveOnto();
                        break;
                    case 2:
                        obj.Ask();
                        obj.MoveOver();
                        break;
                    case 3:
                        obj.Ask();
                        obj.PileOnto();
                        break;
                    case 4:
                        obj.Ask();
                        obj.PileOver();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (op != 5);
            for (int i = 0; i < obj.length; i++) {
                Console.WriteLine(obj.Sol(i));
            }
            Console.ReadKey();
        }
    }
}


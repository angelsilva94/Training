using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlocksProblem;
namespace Blocks_Problem {
    
    class Program {
        static int a, b;
        static void Main(string[] args) {
            Console.WriteLine("Welcome");
            Console.WriteLine("Give me the lenght of the block ");
            Block obj = new Block(int.Parse(Console.ReadLine()));
            Menu(obj);
            for (int i = 0; i < obj.length; i++) {
                Console.WriteLine(obj.Print(i));
            }
            Console.ReadKey();
        }


        public static void Ask() {
            Console.WriteLine("Give me A and B:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
        }


        public static void Menu(Block obj) {
            int op;
            do {
                Console.WriteLine("What do you wanna do?");
                Console.WriteLine("Move A onto B....press 1");
                Console.WriteLine("Move A over B....press 2");
                Console.WriteLine("Pile A onto B....press 3");
                Console.WriteLine("Pile A over B....press 4");
                Console.WriteLine("QUIT.............press 5");
                op = int.Parse(Console.ReadLine());
                switch (op) {
                    case 1:
                        Ask();
                        obj.MoveOnto(a, b);
                        break;
                    case 2:
                        Ask();
                        obj.MoveOver(a,b);
                        break;
                    case 3:
                        Ask();
                        obj.PileOnto(a, b);
                        break;
                    case 4:
                        Ask();
                        obj.PileOver(a, b);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (op != 5);
        }

    }
}


10, move A over B,move A into B


[a,b,moveinto],[a,b,pileover]


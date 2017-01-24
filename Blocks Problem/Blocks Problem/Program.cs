using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks_Problem {




    
    class Program {
        static int a, b;
        public static Stack<int>[] Blocks;
        public static int[] pos;
        static void Main(string[] args) {
            int numb,op;
            
            Console.WriteLine("Welcome");
            Console.WriteLine("Give me the lenght of the block:");
            numb = int.Parse(Console.ReadLine());
            pos = new int[numb];
            Blocks = new Stack<int>[numb];
            for (int i = 0; i < numb; i++) {
                Blocks[i] = new Stack<int>();
                Blocks[i].Push(i);
                pos[i] = i;
            }
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
                        Menu();
                        MoveOnto(a,b);
                        break;
                    case 2:
                        Menu();
                        MoveOver(a,b);
                        break;
                    case 3:
                        Menu();
                        PileOnto(a,b);
                        break;
                    case 4:
                        Menu();
                        PileOver(a,b);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            } while (op != 5);

            for (int i = 0; i < Blocks.Length; i++) {
                Console.WriteLine(Sol(i));
            }
                

            Console.ReadKey();

        }
        public static void Menu() {
            Console.WriteLine("Give me A and B:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
        }
        public static void MoveOnto(int a, int b) {
            Clear(b);
            Clear(a);
            Blocks[pos[b]].Push(Blocks[pos[a]].Pop());
            pos[a] = pos[b];

        }
        public static void Clear(int Block) {
            while(Blocks[pos[Block]].Peek() != Block) {
                Initial(Blocks[pos[Block]].Pop());
            }
        }
        public static void Initial(int Block) {   
            while(Blocks[Block].Count()>0) {
                Initial(Blocks[Block].Pop());
            }
            Blocks[Block].Push(Block);
            pos[Block] = Block;
        }
        public static void MoveOver(int a, int b) {
            Clear(a);
            Blocks[pos[b]].Push(Blocks[pos[a]].Pop());
            pos[a] = pos[b];
        }
        public static void PileOnto(int a, int b) {
            Clear(b);
            PileOver(a, b);
        }
        public static void PileOver(int a, int b) {
            Stack<int> Pile = new Stack<int>();
            while (Blocks[pos[a]].Peek() != a) {
                Pile.Push(Blocks[pos[a]].Pop());
            }
            Pile.Push(Blocks[pos[a]].Pop());
            while (Pile.Count>0) {
                int aux = Pile.Pop();
                Blocks[pos[b]].Push(aux);
                pos[aux] = pos[b];
            }
        }
        public static String Sol(int index) {
            String res = "";
            while (Blocks[index].Count>0)
                res = " " + Blocks[index].Pop() + res;
                res = index + ":" + res;
            return res;
        }

    }
}

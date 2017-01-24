using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks_Problem {
    class Block {
        int a { set; get; }
        int b { set; get; }
        Stack<int>[] Blocks;
        int[] pos;
        public int length { set; get; }

        public Block(int n) {
            this.length = n;
            Blocks = new Stack<int>[length];
            pos = new int[n];
            fillBlocks();
        }

        public void fillBlocks() {
            for (int i = 0; i < length; i++) {
                Blocks[i] = new Stack<int>();
                Blocks[i].Push(i);
                pos[i] = i;
            }
        }
        public void Ask() {
            Console.WriteLine("Give me A and B:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
        }
        public void MoveOnto() {
            Clear(b);
            Clear(a);
            Blocks[pos[b]].Push(Blocks[pos[a]].Pop());
            pos[a] = pos[b];
        }
        public void Clear(int Block) {
            while (Blocks[pos[Block]].Peek() != Block) {
                Initial(Blocks[pos[Block]].Pop());
            }
        }
        public void Initial(int Block) {
            while (Blocks[Block].Count() > 0) {
                Initial(Blocks[Block].Pop());
            }
            Blocks[Block].Push(Block);
            pos[Block] = Block;
        }
        public void MoveOver() {
            Clear(a);
            Blocks[pos[b]].Push(Blocks[pos[a]].Pop());
            pos[a] = pos[b];
        }
        public void PileOnto() {
            Clear(b);
            PileOver();
        }
        public void PileOver() {
            Stack<int> Pile = new Stack<int>();
            while (Blocks[pos[a]].Peek() != a) {
                Pile.Push(Blocks[pos[a]].Pop());
            }
            Pile.Push(Blocks[pos[a]].Pop());
            while (Pile.Count > 0) {
                int aux = Pile.Pop();
                Blocks[pos[b]].Push(aux);
                pos[aux] = pos[b];
            }
        }
        public String Sol(int index) {
            String res = "";
            while (Blocks[index].Count > 0)
                res = " " + Blocks[index].Pop() + res;
            res = "Position ["+index +"] : "+ res;
            return res;
        }
    }
}

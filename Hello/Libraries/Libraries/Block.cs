using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksProblem {
    public class Block {
        int a { set; get; }
        int b { set; get; }
        public Stack<int>[] Blocks;
        int[] pos;
        public int leng { set; get; }

        public Block(int n) {
            this.leng = n;
            Blocks = new Stack<int>[leng];
            pos = new int[n];
            fillBlocks();
        }
        public void fillBlocks() {
            for (int i = 0; i < leng; i++) {
                Blocks[i] = new Stack<int>();
                Blocks[i].Push(i);
                pos[i] = i;
            }
        }
        
        public void MoveOnto(int a,int b) {
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
        public void MoveOver(int a, int b) {
            Clear(a);
            Blocks[pos[b]].Push(Blocks[pos[a]].Pop());
            pos[a] = pos[b];
        }
        public void PileOnto(int a, int b) {
            Clear(b);
            PileOver(a , b);
        }
        public void PileOver(int a, int b) {
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
        public String Print(int index) {
            String res = "";
            while (Blocks[index].Count > 0)
                res = " " + Blocks[index].Pop() + res;
            res = "Position [" + index + "] : " + res;
            return res;
        }
    }
}

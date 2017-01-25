using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3n_1
{
    public class ProcessInput
    {
        public List<int> ProcessPair(int i, int j)
        {
            List<int> result = new List<int>();

            result.Add(i);
            result.Add(j);
            result.Add(this.ProcessNumber(i) + this.ProcessNumber(j) + 2);
            return result;


        }

        private int ProcessNumber(int x)
        {
            int cont = 0;
            do
            {
                if (x != 1)
                {
                    if (x % 2 != 0)
                    {
                        x = (x * 3) + 1;

                    }
                    else
                    {
                        x /= 2;
                    }
                    cont++;

                }
            } while (x != 1);
            return cont;
        }
    }
}

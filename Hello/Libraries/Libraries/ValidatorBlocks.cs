using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Libraries
{
    public class ValidatorBlocks : IProblem
    {
        public int number { set; get; }

        public bool Val(out ErrorDispose e)
        {
            e = new ErrorDispose();
            if (number < 0)
            {
                e.ErrorCode = 1;
                e.ErrorDesc = "numero menor a 0 ";
                return false;
            }else if (number>25)
            {
                e.ErrorCode = 2;
                e.ErrorDesc = "numero mayor a 25 ";
                return false;
            }

            else
            {
                e = null;
                return true;
            }
            
        }
    }
}

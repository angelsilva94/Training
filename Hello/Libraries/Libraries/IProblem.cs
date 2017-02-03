using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries {
    public interface IProblem {
        Boolean Val(out ErrorDispose e);
    }
}

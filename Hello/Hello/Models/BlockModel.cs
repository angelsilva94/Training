using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hello.Models {
    public class BlockModel {
        public List<Instructions> instructions { set; get; }
        public int length { set; get; }
    }
}
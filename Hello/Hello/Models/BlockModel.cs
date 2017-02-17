using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hello.Models {
    public class BlockModel {
        public List<Instructions> instructions { set; get; }// = new List<Instructions>();
        public int leng { set; get; }
        public string res { set; get; }
    }
}